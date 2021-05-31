using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Composition;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Text;

using NuGet.Versioning;

using RoslynPad.Build;
using RoslynPad.NuGet;
using RoslynPad.Roslyn;
using RoslynPad.Roslyn.Rename;
using RoslynPad.Runtime;
using RoslynPad.Utilities;
using System.Diagnostics;
using Microsoft.CodeAnalysis.Scripting;

namespace RoslynPad.UI {
    public class MainViewModelBase : NotificationObject {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAppDispatcher _dispatcher;
        private readonly ITelemetryProvider _telemetryProvider;
        private readonly IPlatformsFactory _platformsFactory;
        private readonly ICommandProvider _commands;
        public IApplicationSettings Settings { get; }
        private static readonly Version _currentVersion = new Version(16, 0);
        private static readonly string _currentVersionVariant = "";
        public const string NuGetPathVariableName = "$NuGet";

        private IExecutionHost _executionHost;
        private ExecutionHostParameters _executionHostParameters;
        private ObservableCollection<IResultObject> _results;
        private CancellationTokenSource? _runCts;
        private CancellationTokenSource? _restoreCts;
        private ExecutionPlatform _platform;
        private double? _reportedProgress;
        private bool _isRunning;
        private IReadOnlyList<ExecutionPlatform>? _availablePlatforms;
        private bool _isRestoring;
        private bool _restoreSuccessful;
        private bool _isLiveMode;
        private Timer? _liveModeTimer;

        private bool _isDirty;
        private bool _isSaving;
        private Action<ExceptionResultObject?>? _onError;
        private Func<TextSpan>? _getSelection;

        private DocumentViewModel? _document;
        private DocumentViewModel _documentRootFolder;
        private DocumentId? _documentId;
        private DocumentWatcher _documentWatcher;
        private readonly DocumentFileWatcher _documentFileWatcher;

        private double _editorFontSize;
        private bool _isInitialized;
        private bool _isDocInitialized;

        public RoslynHost RoslynHost { get; private set; }
        public ImmutableArray<MetadataReference> DefaultReferences { get; private set; }
        public ImmutableArray<MetadataReference> DefaultReferencesCompat50 { get; private set; }

        public IDelegateCommand OpenBuildPathCommand { get; }
        public IDelegateCommand RunCommand { get; }
        public IDelegateCommand RestartHostCommand { get; }
        public IDelegateCommand NewDocumentCommand { get; }
        public IDelegateCommand OpenFileCommand { get; }
        public IDelegateCommand SaveCommand { get; }
        public IDelegateCommand EditUserDocumentPathCommand { get; }
        public IDelegateCommand CloseCurrentDocumentCommand { get; }
        public IDelegateCommand FormatDocumentCommand { get; }
        public IDelegateCommand CommentSelectionCommand { get; }
        public IDelegateCommand UncommentSelectionCommand { get; }
        public IDelegateCommand RenameSymbolCommand { get; }
        public IDelegateCommand ToggleLiveModeCommand { get; }

        public string Id { get; private set; }
        public string BuildPath { get; private set; }
        public NuGetViewModel NuGet { get; }
        public NuGetDocumentViewModel NuGetDoc { get; private set; }


        public MainViewModelBase(IServiceProvider serviceProvider, ITelemetryProvider telemetryProvider, ICommandProvider commands, IAppDispatcher appDispatcher, IApplicationSettings settings, NuGetViewModel nugetViewModel, DocumentFileWatcher documentFileWatcher) {
            _serviceProvider = serviceProvider;
            _telemetryProvider = telemetryProvider;
            _platformsFactory = serviceProvider.GetService<IPlatformsFactory>();
            _commands = commands;
            _documentFileWatcher = documentFileWatcher;
            _dispatcher = appDispatcher;

            settings.LoadDefault();
            Settings = settings;
            _telemetryProvider.Initialize(_currentVersion.ToString(), settings);
            _telemetryProvider.LastErrorChanged += () => {
                OnPropertyChanged(nameof(LastError));
                OnPropertyChanged(nameof(HasError));
            };
            NuGet = nugetViewModel;

            DocumentRootFolder = CreateDocumentRoot();
            RunCommand = commands.CreateAsync(Run, () => !IsRunning && RestoreSuccessful && Platform != null);
            RestartHostCommand = commands.CreateAsync(RestartHost, () => Platform != null);
            NewDocumentCommand = _commands.Create(CreateNewDocument);
            OpenFileCommand = _commands.CreateAsync(OpenFile);
            SaveCommand = _commands.CreateAsync(() => Save(promptSave: false));
            ClearErrorCommand = _commands.Create(() => _telemetryProvider.ClearLastError());
            EditUserDocumentPathCommand = _commands.Create(EditUserDocumentPath);
            FormatDocumentCommand = _commands.CreateAsync(() => FormatDocument());
            CommentSelectionCommand = _commands.CreateAsync(() => CommentUncommentSelection(CommentAction.Comment));
            UncommentSelectionCommand = _commands.CreateAsync(() => CommentUncommentSelection(CommentAction.Uncomment));
            RenameSymbolCommand = _commands.CreateAsync(RenameSymbol);
            ToggleLiveModeCommand = commands.Create(() => IsLiveMode = !IsLiveMode);

            _editorFontSize = Settings.EditorFontSize;
        }

        public async Task Initialize() {
            if (IsInitialized) return;
            try {
                await InitializeInternal().ConfigureAwait(true);
                IsInitialized = true;
            } catch (Exception e) {
                _telemetryProvider.ReportError(e);
            }
        }
        private async Task InitializeInternal() {
            RoslynHost = await Task.Run(() => new RoslynHost(CompositionAssemblies,
                RoslynHostReferences.NamespaceDefault.With(typeNamespaceImports: new[] { typeof(Runtime.ObjectExtensions) }),
                disabledDiagnostics: ImmutableArray.Create("CS1701", "CS1702")))
                .ConfigureAwait(true);

            var runtimeAssemblyPath = typeof(Runtime.ObjectExtensions).Assembly.Location;
            DefaultReferences = RoslynHost.DefaultReferences;
            DefaultReferencesCompat50 = DefaultReferences.Add(MetadataReference.CreateFromFile(
                Path.Combine(Path.GetDirectoryName(runtimeAssemblyPath)!, "RoslynPad.Runtime.Compat50.dll")));
            CreateNewDocument();
        }
        internal void DocumentConstructor() {
            // Constructor
            Id = Guid.NewGuid().ToString("n");
            BuildPath = Path.Combine(Path.GetTempPath(), "roslynpad", "build", Id);
            Directory.CreateDirectory(BuildPath);

            _results = new ObservableCollection<IResultObject>();
            _restoreSuccessful = true; // initially set to true so we can immediately start running and wait for restore

            NuGetDoc = _serviceProvider.GetService<NuGetDocumentViewModel>();
            _platformsFactory.Changed += InitializePlatforms;

            _executionHostParameters = new ExecutionHostParameters(
                BuildPath,
                _serviceProvider.GetService<NuGetViewModel>().ConfigPath,
                RoslynHost.DefaultImports,
                RoslynHost.DisabledDiagnostics,
                WorkingDirectory);
            _executionHost = new ExecutionHost(_executionHostParameters, RoslynHost);

            _executionHost.Dumped += ExecutionHostOnDump;
            _executionHost.Error += ExecutionHostOnError;
            _executionHost.ReadInput += ExecutionHostOnInputRequest;
            _executionHost.CompilationErrors += ExecutionHostOnCompilationErrors;
            _executionHost.RestoreStarted += OnRestoreStarted;
            _executionHost.RestoreCompleted += OnRestoreCompleted;
            _executionHost.RestoreMessage += AddResult;
            _executionHost.ProgressChanged += p => ReportedProgress = p.Progress;

            InitializePlatforms();
        }

        internal void InitializeDocument(DocumentId documentId,
            Action<ExceptionResultObject?> onError,
            Func<TextSpan> getSelection) {
            _onError = onError;
            _getSelection = getSelection;
            DocumentId = documentId;
            _isDocInitialized = true;

            Platform = AvailablePlatforms.FirstOrDefault(p => p.Name == Settings.DefaultPlatformName) ??
                       AvailablePlatforms.FirstOrDefault();
            UpdatePackages();
            RestartHostCommand?.Execute();
        }

        public DocumentViewModel DocumentRootFolder {
            get => _documentRootFolder;
            private set => SetProperty(ref _documentRootFolder, value);
        }
        public DocumentViewModel? Document {
            get => _document;
            private set {
                if (value == null) return;
                if (_document != value) {
                    SetProperty(ref _document, value);

                    if (_executionHost != null && value != null) {
                       _executionHost.Name = value.Name;
                    }
                }
            }
        }
        public DocumentId DocumentId {
            get => _documentId ?? throw new ArgumentNullException(nameof(_documentId));
            private set => _documentId = value;
        }
        public event EventHandler DocumentChanged;

        public bool IsDirty {
            get => _isDirty;
            private set => SetProperty(ref _isDirty, value);
        }
        public bool IsInitialized {
            get => _isInitialized;
            private set {
                SetProperty(ref _isInitialized, value);
                //OnPropertyChanged(nameof(HasNoOpenDocument));
            }
        }
        protected virtual ImmutableArray<Assembly> CompositionAssemblies => ImmutableArray.Create(typeof(MainViewModelBase).Assembly);
        public string WorkingDirectory => Document != null
            ? Path.GetDirectoryName(Document.Path)!
            : DocumentRootFolder.Path;
        public string WindowTitle {
            get {
                var title = "RoslynPad ";
                return title;
            }
        }
        public string Title => Document != null ? Document.Name : "New";
        //public bool HasNoOpenDocument => IsInitialized && Document == null;
        public double MinimumEditorFontSize => 8;
        public double MaximumEditorFontSize => 72;
        public double EditorFontSize {
            get => _editorFontSize; set {
                if (value < MinimumEditorFontSize || value > MaximumEditorFontSize) return;
                if (SetProperty(ref _editorFontSize, value)) {
                    Settings.EditorFontSize = value;
                    EditorFontSizeChanged?.Invoke(value);
                }
            }
        }
        public event Action<double> EditorFontSizeChanged;


        //public OpenDocumentViewModel? CurrentOpenDocument {
        //    get => _currentOpenDocument;
        //    set {
        //        if (value == null) return; // prevent binding from clearing the value
        //        SetProperty(ref _currentOpenDocument, value);
        //    }
        //}

        private DocumentViewModel CreateDocumentRoot() {
            _documentWatcher?.Dispose();
            var root = DocumentViewModel.CreateRoot(Settings.EffectiveDocumentPath);
            _documentWatcher = new DocumentWatcher(_documentFileWatcher, root);
            return root;
        }
        private void GetOpenDocumentViewModel(DocumentViewModel? documentViewModel = null) {
            DocumentConstructor();
            SetDocument(documentViewModel);
        }
        public void CreateNewDocument() {
            GetOpenDocumentViewModel(null);
        }

        public void SetDocument(DocumentViewModel? document = null) {
            Document = document == null ? null : DocumentViewModel.FromPath(document.Path);
            IsDirty = document?.IsAutoSave == true;
            _executionHost.Name = Document?.Name ?? "Untitled";
            DocumentChanged.Invoke(this, EventArgs.Empty);
        }
        public void OpenDocument(DocumentViewModel document) {
            if (document.IsFolder) return;
            GetOpenDocumentViewModel(document);
        }
        public async Task OpenFile() {
            if (!IsInitialized) return;

            var dialog = _serviceProvider.GetService<IOpenFileDialog>();
            dialog.AllowMultiple = false;
            dialog.Filter = new FileDialogFilter("C# Scripts", "cs", "csx");
            var fileName = await dialog.ShowAsync().ConfigureAwait(true);
            if (fileName == null) {
                return;
            }
            // make sure we use the normalized path, in case the user used the wrong capitalization on Windows
            var filePath = IOUtilities.NormalizeFilePath(fileName.First());
            var document = DocumentViewModel.FromPath(filePath);
            if (!document.IsAutoSave) {
                var autoSavePath = document.GetAutoSavePath();
                if (File.Exists(autoSavePath)) {
                    document = DocumentViewModel.FromPath(autoSavePath);
                }
            }
            OpenDocument(document);
        }
        public DocumentViewModel AddDocument(string documentName) {
            return DocumentRootFolder.CreateNew(documentName);
        }
        private void OnDocumentUpdated() {
            DocumentUpdated?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler? DocumentUpdated;
        public async Task<string> LoadText() {
            if (Document == null) {
                return string.Empty;
            }
            using var fileStream = File.OpenText(Document.Path);
            return await fileStream.ReadToEndAsync().ConfigureAwait(false);
        }
        public event EventHandler? EditorFocus;
        private void OnEditorFocus() {
            EditorFocus?.Invoke(this, EventArgs.Empty);
        }
        public void OnTextChanged() {
            IsDirty = true;
        }
        public async Task AutoSave() {
            if (!IsDirty) return;
            var document = Document;
            if (document == null) {
                var index = 1;
                string path;
                do {
                    path = Path.Combine(WorkingDirectory, DocumentViewModel.GetAutoSaveName("Program" + index++));
                }
                while (File.Exists(path));
                document = DocumentViewModel.FromPath(path);
            }
            Document = document;
            await SaveDocument(Document.GetAutoSavePath()).ConfigureAwait(false);
        }
        public async Task<SaveResult> Save(bool promptSave) {
            if (_isSaving) return SaveResult.Cancel;
            if (!IsDirty && promptSave) return SaveResult.Save;
            _isSaving = true;
            try {
                var result = SaveResult.Save;
                if (Document == null) {
                    var dialog = _serviceProvider.GetService<ISaveDocumentDialog>();
                    dialog.ShowDontSave = promptSave;
                    dialog.AllowNameEdit = true;
                    dialog.FilePathFactory = s => DocumentViewModel.GetDocumentPathFromName(WorkingDirectory, s);
                    await dialog.ShowAsync();
                    result = dialog.Result;
                    if (result == SaveResult.Save && dialog.DocumentName != null) {
                        Document?.DeleteAutoSave();
                        Document = AddDocument(dialog.DocumentName);
                        OnPropertyChanged(nameof(Title));
                    }
                } else if (promptSave) {
                    var dialog = _serviceProvider.GetService<ISaveDocumentDialog>();
                    dialog.ShowDontSave = true;
                    dialog.DocumentName = Document.Name;
                    await dialog.ShowAsync();
                    result = dialog.Result;
                }
                if (result == SaveResult.Save && Document != null) {
                    // ReSharper disable once PossibleNullReferenceException
                    await SaveDocument(Document.GetSavePath()).ConfigureAwait(true);
                    IsDirty = false;
                }
                if (result != SaveResult.Cancel) {
                    Document?.DeleteAutoSave();
                }
                return result;
            } finally {
                _isSaving = false;
            }
        }
        private async Task SaveDocument(string path) {
            if (!_isDocInitialized) return;
            var document = RoslynHost.GetDocument(DocumentId);
            if (document == null) {
                return;
            }
            var text = await document.GetTextAsync().ConfigureAwait(false);
            using var writer = File.CreateText(path);
            for (int lineIndex = 0; lineIndex < text.Lines.Count - 1; ++lineIndex) {
                var lineText = text.Lines[lineIndex].ToString();
                await writer.WriteLineAsync(lineText).ConfigureAwait(false);
            }
            await writer.WriteAsync(text.Lines[text.Lines.Count - 1].ToString()).ConfigureAwait(false);
        }
        public void EditUserDocumentPath() {
            var dialog = _serviceProvider.GetService<IFolderBrowserDialog>();
            dialog.ShowEditBox = true;
            dialog.SelectedPath = Settings.EffectiveDocumentPath;

            if (dialog.Show() == true) {
                string documentPath = dialog.SelectedPath;
                if (!DocumentRootFolder.Path.Equals(documentPath, StringComparison.OrdinalIgnoreCase)) {
                    Settings.DocumentPath = documentPath;
                    DocumentRootFolder = CreateDocumentRoot();
                }
            }
        }

        public async Task OnExit() {
            await Save(false).ConfigureAwait(false);
            IOUtilities.PerformIO(() => Directory.Delete(Path.Combine(Path.GetTempPath(), "RoslynPad"), recursive: true));
        }
        public Exception? LastError {
            get {
                var exception = _telemetryProvider.LastError;
                var aggregateException = exception as AggregateException;
                return aggregateException?.Flatten() ?? exception;
            }
        }
        public bool HasError => LastError != null;
        public IDelegateCommand ClearErrorCommand { get; }
        public bool SendTelemetry {
            get => Settings.SendErrors; set {
                Settings.SendErrors = value;
                OnPropertyChanged(nameof(SendTelemetry));
            }
        }


        #region Execution
        public IEnumerable<object> Results => _results;
        internal IEnumerable<IResultObject> ResultsInternal => _results;
        private void AddResult(object o) {
            _dispatcher.InvokeAsync(() => {
                _results.Add(ResultObject.Create(o, DumpQuotas.Default));
                ResultsAvailable?.Invoke();
            }, AppDispatcherPriority.Low);
        }
        public event Action? ReadInput;
        public event Action? ResultsAvailable;
        private void ExecutionHostOnInputRequest() {
            _dispatcher.InvokeAsync(() => {
                ReadInput?.Invoke();
            }, AppDispatcherPriority.Low);
        }
        private void ExecutionHostOnDump(ResultObject result) {
            AddResult(result);
        }
        private void ExecutionHostOnError(ExceptionResultObject errorResult) {
            _dispatcher.InvokeAsync(() => {
                _onError?.Invoke(errorResult);
                if (errorResult != null) {
                    _results.Add(errorResult);

                    ResultsAvailable?.Invoke();
                }
            }, AppDispatcherPriority.Low);
        }
        private void ExecutionHostOnCompilationErrors(IList<CompilationErrorResultObject> errors) {
            _dispatcher.InvokeAsync(() => {
                foreach (var error in errors) {
                    _results.Add(error);
                }

                ResultsAvailable?.Invoke();
            });
        }
        private void ClearResults(Func<IResultObject, bool> filter) {
            _dispatcher.InvokeAsync(() => {
                foreach (var result in _results.Where(filter).ToArray()) {
                    _results.Remove(result);
                }
            });
        }
        
        private IEnumerable<string> GetReferencePaths(IEnumerable<MetadataReference> references) {
            return references.OfType<PortableExecutableReference>().Select(x => x.FilePath).Where(x => x != null)!;
        }
        public void OpenBuildPath() {
            Task.Run(() => {
                try {
                    Process.Start(new ProcessStartInfo(new Uri("file://" + BuildPath).ToString()) { UseShellExecute = true });
                } catch (Exception ex) {
                    _telemetryProvider.ReportError(ex);
                }
            });
        }

        public void SendInput(string input) {
            _executionHost?.SendInputAsync(input);
        }
        private async Task<string> GetCode(CancellationToken cancellationToken) {
            var document = RoslynHost.GetDocument(DocumentId);
            if (document == null) {
                return string.Empty;
            }

            return (await document.GetTextAsync(cancellationToken)
                .ConfigureAwait(false)).ToString();
        }
        private void Reset() {
            if (_runCts != null) {
                _runCts.Cancel();
                _runCts.Dispose();
            }
            _runCts = new CancellationTokenSource();
        }
        public ExecutionPlatform? Platform {
            get => _platform;
            set {
                if (value == null) throw new InvalidOperationException();

                if (SetProperty(ref _platform, value)) {
                    _executionHost.Platform = value;
                    UpdatePackages();
                }
                RunCommand.RaiseCanExecuteChanged();
                RestartHostCommand.RaiseCanExecuteChanged();

                if (_isDocInitialized) {
                    RestartHostCommand.Execute();
                }
            }
        }
        private async Task RestartHost() {
            Reset();
            try {
                await Task.Run(() => _executionHost?.TerminateAsync()).ConfigureAwait(false);
            } catch (Exception e) {
                _telemetryProvider.ReportError(e);
                throw;
            } finally {
                SetIsRunning(false);
            }
        }
        private void SetIsRunning(bool value) {
            _dispatcher.InvokeAsync(() => IsRunning = value);
        }
        public bool IsRunning {
            get => _isRunning;
            private set {
                if (SetProperty(ref _isRunning, value)) {
                    _dispatcher.InvokeAsync(() => RunCommand.RaiseCanExecuteChanged());
                }
            }
        }
        private async Task Run() {
            if (IsRunning) return;
            ReportedProgress = null;
            Reset();
            SetIsRunning(true);
            StartExec();
            var cancellationToken = _runCts!.Token;
            try {
                var code = await GetCode(cancellationToken).ConfigureAwait(true);
                if (_executionHost != null) {
                    // Make sure the execution working directory matches the current script path
                    // which may have changed since we loaded.
                    if (_executionHostParameters.WorkingDirectory != WorkingDirectory)
                        _executionHostParameters.WorkingDirectory = WorkingDirectory;

                    await _executionHost.ExecuteAsync(code, false, OptimizationLevel).ConfigureAwait(true);
                }
            } catch (CompilationErrorException ex) {
                foreach (var diagnostic in ex.Diagnostics) {
                    _results.Add(ResultObject.Create(diagnostic, DumpQuotas.Default));
                }
            } catch (Exception ex) {
                AddResult(ex);
            } finally {
                SetIsRunning(false);
                ReportedProgress = null;
            }
        }
        private void StartExec() {
            ClearResults(t => !(t is RestoreResultObject));

            _onError?.Invoke(null);
        }
        private OptimizationLevel OptimizationLevel => Settings.OptimizeCompilation ? OptimizationLevel.Release : OptimizationLevel.Debug;
        private void UpdatePackages() {
            _restoreCts?.Cancel();
            _restoreCts = new CancellationTokenSource();
            _ = UpdatePackagesAsync(_restoreCts.Token);
            async Task UpdatePackagesAsync(CancellationToken cancellationToken) {
                var document = RoslynHost.GetDocument(DocumentId);
                if (document == null) {
                    return;
                }
                var syntaxRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
                var libraries = ParseReferences(syntaxRoot!);
                var defaultReferences = Platform?.FrameworkVersion?.Major < 5
                    ? DefaultReferencesCompat50
                    : DefaultReferences;
                if (defaultReferences.Length > 0) {
                    libraries.AddRange(GetReferencePaths(defaultReferences).Select(p => LibraryRef.Reference(p)));
                }
                _executionHost.UpdateLibraries(libraries);
            }
        }
        private List<LibraryRef> ParseReferences(SyntaxNode syntaxRoot) {
            const string NuGetPrefix = "nuget:";
            const string LegacyNuGetPrefix = "$NuGet\\";
            const string FxPrefix = "framework:";
            var libraries = new List<LibraryRef>();
            if (!(syntaxRoot is Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax compilation)) {
                return libraries;
            }
            foreach (var directive in compilation.GetReferenceDirectives()) {
                var value = directive.File.ValueText;
                string? id, version;
                if (HasPrefix(FxPrefix, value)) {
                    libraries.Add(LibraryRef.FrameworkReference(
                        value.Substring(FxPrefix.Length, value.Length - FxPrefix.Length)));
                    continue;
                }
                if (HasPrefix(NuGetPrefix, value)) {
                    (id, version) = ParseNuGetReference(NuGetPrefix, value);
                } else if (HasPrefix(LegacyNuGetPrefix, value)) {
                    (id, version) = ParseLegacyNuGetReference(value);
                    if (id == null) {
                        continue;
                    }
                } else {
                    libraries.Add(LibraryRef.Reference(value));

                    continue;
                }
                VersionRange versionRange;
                if (version == string.Empty) {
                    versionRange = VersionRange.All;
                } else if (!VersionRange.TryParse(version, out versionRange)) {
                    continue;
                }
                libraries.Add(LibraryRef.PackageReference(id, version ?? string.Empty));
            }
            return libraries;
            // local functions
            static bool HasPrefix(string prefix, string value) {
                return value.Length > prefix.Length &&
                       value.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase);
            }
            static (string id, string version) ParseNuGetReference(string prefix, string value) {
                string id, version;
                var indexOfSlash = value.IndexOf('/');
                if (indexOfSlash >= 0) {
                    id = value.Substring(prefix.Length, indexOfSlash - prefix.Length);
                    version = indexOfSlash != value.Length - 1 ? value.Substring(indexOfSlash + 1) : string.Empty;
                } else {
                    id = value.Substring(prefix.Length);
                    version = string.Empty;
                }
                return (id, version);
            }
            static (string? id, string? version) ParseLegacyNuGetReference(string value) {
                var split = value.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length >= 3) {
                    return (split[1], split[2]);
                }
                return (null, null);
            }
        }

        public double? ReportedProgress {
            get => _reportedProgress;
            private set {
                if (_reportedProgress != value) {
                    SetProperty(ref _reportedProgress, value);
                    OnPropertyChanged(nameof(HasReportedProgress));
                }
            }
        }
        public bool HasReportedProgress => ReportedProgress.HasValue;
        public IReadOnlyList<ExecutionPlatform> AvailablePlatforms {
            get => _availablePlatforms ?? throw new ArgumentNullException(nameof(_availablePlatforms));
            private set => SetProperty(ref _availablePlatforms, value);
        }
        private void InitializePlatforms() {
            AvailablePlatforms = _platformsFactory.GetExecutionPlatforms().ToImmutableArray();
            _executionHost.DotNetExecutable = _platformsFactory.DotNetExecutable;
        }
        private void OnRestoreStarted() {
            IsRestoring = true;
        }
        private void OnRestoreCompleted(RestoreResult restoreResult) {
            IsRestoring = false;
            ClearResults(t => t is RestoreResultObject);
            if (restoreResult.Success) {
                var host = RoslynHost;
                var document = host.GetDocument(DocumentId);
                if (document == null) {
                    return;
                }
                var project = document.Project;
                project = project
                    .WithMetadataReferences(_executionHost.MetadataReferences)
                    .WithAnalyzerReferences(_executionHost.Analyzers);
                document = project.GetDocument(DocumentId);
                host.UpdateDocument(document!);
                OnDocumentUpdated();
            } else {
                foreach (var error in restoreResult.Errors) {
                    AddResult(new RestoreResultObject(error, "Error"));
                }
            }
            RestoreSuccessful = restoreResult.Success;
        }
        public bool IsRestoring {
            get => _isRestoring;
            private set => SetProperty(ref _isRestoring, value);
        }
        public bool RestoreSuccessful {
            get => _restoreSuccessful;
            private set {
                if (SetProperty(ref _restoreSuccessful, value)) {
                    _dispatcher.InvokeAsync(() => RunCommand.RaiseCanExecuteChanged());
                }
            }
        }
        public bool IsLiveMode {
            get => _isLiveMode;
            private set {
                if (!SetProperty(ref _isLiveMode, value)) return;
                RunCommand.RaiseCanExecuteChanged();
                if (value) {
                    // ReSharper disable once UnusedVariable
                    _ = Run();
                    if (_liveModeTimer == null) {
                        _liveModeTimer = new Timer(o => _dispatcher.InvokeAsync(() => {
                            // ReSharper disable once UnusedVariable
                            var runTask = Run();
                        }), null, Timeout.Infinite, Timeout.Infinite);
                    }
                }
            }
        }

        #endregion

        public enum CommentAction {
            Comment,
            Uncomment
        }
        public async Task CommentUncommentSelection(CommentAction action) {
            const string singleLineCommentString = "//";

            var document = RoslynHost.GetDocument(DocumentId);
            if (document == null) {
                return;
            }

            if (_getSelection == null) {
                return;
            }

            var selection = _getSelection();

            var documentText = await document.GetTextAsync().ConfigureAwait(false);
            var changes = new List<TextChange>();
            var lines = documentText.Lines.SkipWhile(x => !x.Span.IntersectsWith(selection))
                .TakeWhile(x => x.Span.IntersectsWith(selection)).ToArray();

            if (action == CommentAction.Comment) {
                foreach (var line in lines) {
                    if (!string.IsNullOrWhiteSpace(documentText.GetSubText(line.Span).ToString())) {
                        changes.Add(new TextChange(new TextSpan(line.Start, 0), singleLineCommentString));
                    }
                }
            } else if (action == CommentAction.Uncomment) {
                foreach (var line in lines) {
                    var text = documentText.GetSubText(line.Span).ToString();
                    if (text.TrimStart().StartsWith(singleLineCommentString, StringComparison.Ordinal)) {
                        changes.Add(new TextChange(new TextSpan(
                            line.Start + text.IndexOf(singleLineCommentString, StringComparison.Ordinal),
                            singleLineCommentString.Length), string.Empty));
                    }
                }
            }

            if (changes.Count == 0) return;

            RoslynHost.UpdateDocument(document.WithText(documentText.WithChanges(changes)));
            if (action == CommentAction.Uncomment && Settings.FormatDocumentOnComment) {
                await FormatDocument().ConfigureAwait(false);
            }
        }
        public async Task FormatDocument() {
            var document = RoslynHost.GetDocument(DocumentId);
            var formattedDocument = await Formatter.FormatAsync(document!).ConfigureAwait(false);
            RoslynHost.UpdateDocument(formattedDocument);
        }
        public async Task RenameSymbol() {
            var host = RoslynHost;
            var document = host.GetDocument(DocumentId);
            if (document == null || _getSelection == null) {
                return;
            }

            var symbol = await RenameHelper.GetRenameSymbol(document, _getSelection().Start).ConfigureAwait(true);
            if (symbol == null) return;

            var dialog = _serviceProvider.GetService<IRenameSymbolDialog>();
            dialog.Initialize(symbol.Name);
            await dialog.ShowAsync();
            if (dialog.ShouldRename) {
                var newSolution = await Renamer.RenameSymbolAsync(document.Project.Solution, symbol, dialog.SymbolName ?? string.Empty,
                    document.Project.Solution.Options).ConfigureAwait(true);
                var newDocument = newSolution.GetDocument(DocumentId);
                // TODO: possibly update entire solution
                host.UpdateDocument(newDocument!);
            }
            OnEditorFocus();
        }

        #region Document Watcher

        private class DocumentWatcher : IDisposable {
            private static readonly char[] PathSeparators = { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };

            private readonly DocumentViewModel _documentRoot;
            private readonly IDisposable _subscription;

            public DocumentWatcher(DocumentFileWatcher watcher, DocumentViewModel documentRoot) {
                _documentRoot = documentRoot;
                watcher.Path = documentRoot.Path;
                _subscription = watcher.Subscribe(OnDocumentFileChanged);
            }

            public void Dispose() => _subscription.Dispose();

            private void OnDocumentFileChanged(DocumentFileChanged data) {
                var pathParts = data.Path.Substring(_documentRoot.Path.Length)
                    .Split(PathSeparators, StringSplitOptions.RemoveEmptyEntries);

                DocumentViewModel? current = _documentRoot;

                for (var index = 0; index < pathParts.Length; index++) {
                    if (!current.IsChildrenInitialized) {
                        break;
                    }

                    var part = pathParts[index];
                    var isLast = index == pathParts.Length - 1;

                    var parent = current;
                    current = current.InternalChildren[part];

                    // the current part is not in the tree
                    if (current == null) {
                        if (data.Type != DocumentFileChangeType.Deleted) {
                            var currentPath = isLast && data.Type == DocumentFileChangeType.Renamed
                                ? data.NewPath
                                : Path.Combine(_documentRoot.Path, Path.Combine(pathParts.Take(index + 1).ToArray()));

                            var newDocument = DocumentViewModel.FromPath(currentPath!);
                            if (!newDocument.IsAutoSave &&
                                IsRelevantDocument(newDocument)) {
                                parent.AddChild(newDocument);
                            }
                        }

                        break;
                    }

                    // it's the last part - the actual file
                    if (isLast) {
                        switch (data.Type) {
                            case DocumentFileChangeType.Renamed:
                                if (data.NewPath != null) {
                                    current.ChangePath(data.NewPath);
                                    // move it to the correct place
                                    parent.InternalChildren.Remove(current);
                                    if (IsRelevantDocument(current)) {
                                        parent.AddChild(current);
                                    }
                                }
                                break;
                            case DocumentFileChangeType.Deleted:
                                parent.InternalChildren.Remove(current);
                                break;
                        }
                    }
                }
            }

            private static bool IsRelevantDocument(DocumentViewModel document) {
                return document.IsFolder || string.Equals(Path.GetExtension(document.OriginalName),
                           DocumentViewModel.DefaultFileExtension, StringComparison.OrdinalIgnoreCase);
            }
        }

        #endregion
    }
}
