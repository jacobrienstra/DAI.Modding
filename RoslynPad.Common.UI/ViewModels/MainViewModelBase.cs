using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;

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

        #region PrivateFields

        #region Providers
        private readonly IServiceProvider _serviceProvider;
        private readonly IAppDispatcher _dispatcher;
        private readonly ITelemetryProvider _telemetryProvider;
        private readonly IPlatformFactory _platformFactory;
        private readonly ICommandProvider _commands;
        #endregion

        #region ExecutionHost
        private IExecutionHost _executionHost;
        private ExecutionHostParameters _executionHostParameters;
        private CancellationTokenSource? _runCts;
        private CancellationTokenSource? _restoreCts;
        //private IReadOnlyList<ExecutionPlatform>? _availablePlatforms;
        private ExecutionPlatform _platform;
        private double? _reportedProgress; 
        private bool _isRunning;
        private bool _isRestoring;
        private bool _restoreSuccessful;
        //private bool _isLiveMode;
        //private Timer? _liveModeTimer;
        private ObservableCollection<IResultObject> _results;
        #endregion

        #region Document
        private bool _isDirty;
        private bool _isSaving;
        private Action<ExceptionResultObject?>? _onError;
        private Func<TextSpan>? _getSelection;

        private DocumentViewModel? _currentDocument;
        private DocumentViewModel _documentRootFolder;
        private DocumentId? __currentDocumentId;
        private DocumentWatcher _documentWatcher;
        private readonly DocumentFileWatcher _documentFileWatcher;

        private bool _isDocInitialized;
        #endregion

        private double _editorFontSize;
        private bool _isInitialized;

        #endregion

        #region PublicProperties

        public bool IsInitialized {
            get => _isInitialized;
            private set {
                SetProperty(ref _isInitialized, value);
                //OnPropertyChanged(nameof(HasNoOpenDocument));
            }
        }
        public IApplicationSettings Settings { get; }
        public string WorkingDirectory => CurrentDocument != null
           ? Path.GetDirectoryName(CurrentDocument.Path)!
           : DocumentRootFolder.Path;
        public string WindowTitle {
            get {
                var title = "RoslynPad ";
                return title;
            }
        }
        public string Title => CurrentDocument != null ? CurrentDocument.Name : "New";
        //public bool HasNoOpenDocument => IsInitialized && Document == null;

        #region Build
        public RoslynHost RoslynHost { get; private set; }
        public ImmutableArray<MetadataReference> DefaultReferences { get; private set; }
        public ImmutableArray<MetadataReference> DefaultReferencesCompat50 { get; private set; }
        public string Id { get; private set; }
        public string BuildPath { get; private set; }
        public NuGetViewModel NuGet { get; }
        public NuGetDocumentViewModel NuGetDoc { get; private set; }
        //public IReadOnlyList<ExecutionPlatform> AvailablePlatforms
        //{
        //    get => _availablePlatforms ?? throw new ArgumentNullException(nameof(_availablePlatforms));
        //    private set => SetProperty(ref _availablePlatforms, value);
        //}
        public ExecutionPlatform? Platform
        {
            get => _platform;
            set
            {
                if (value == null) throw new InvalidOperationException();

                if (SetProperty(ref _platform, value))
                {
                    _executionHost.Platform = value;
                    UpdatePackages();
                }
                //RunCommand.RaiseCanExecuteChanged();
                RestartHostCommand.RaiseCanExecuteChanged();

                if (_isDocInitialized)
                {
                    RestartHostCommand.Execute();
                }
            }
        }
        public bool IsRunning
        {
            get => _isRunning;
            private set
            {
                if (SetProperty(ref _isRunning, value))
                {
                    //_dispatcher.InvokeAsync(() => RunCommand.RaiseCanExecuteChanged());
                }
            }
        }
        private OptimizationLevel OptimizationLevel => Settings.OptimizeCompilation ? OptimizationLevel.Release : OptimizationLevel.Debug;
        #endregion

        #region Commands
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
        #endregion

        #region Document
        public DocumentViewModel DocumentRootFolder {
            get => _documentRootFolder;
            private set => SetProperty(ref _documentRootFolder, value);
        }
        public DocumentViewModel? CurrentDocument {
            get => _currentDocument;
            private set {
                if (value == null) return;
                if (_currentDocument != value) {
                    SetProperty(ref _currentDocument, value);

                    if (_executionHost != null && value != null)
                    {
                        _executionHost.Name = value.Name;
                    }
                }
            }
        }
        public DocumentId CurrentDocumentId {
            get => __currentDocumentId ?? throw new ArgumentNullException(nameof(__currentDocumentId));
            private set => __currentDocumentId = value;
        }
        public bool IsDirty {
            get => _isDirty;
            private set => SetProperty(ref _isDirty, value);
        }
        #endregion

        #region Editor
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
        #endregion

        #endregion

        #region Events
        public event EventHandler DocumentChanged;
        public event EventHandler? DocumentUpdated;
        public event Action<double> EditorFontSizeChanged;
        public event EventHandler? EditorFocus;
        public event Action? ReadInput;
        public event Action? ResultsAvailable;
        #endregion

        #region Contructors_Initializers
        public MainViewModelBase(IServiceProvider serviceProvider, ITelemetryProvider telemetryProvider, ICommandProvider commands, IAppDispatcher appDispatcher, IApplicationSettings settings, NuGetViewModel nugetViewModel, DocumentFileWatcher documentFileWatcher) {
            _serviceProvider = serviceProvider;
            _telemetryProvider = telemetryProvider;
            _platformFactory = serviceProvider.GetService<IPlatformFactory>();
            _commands = commands;
            _documentFileWatcher = documentFileWatcher;
            _dispatcher = appDispatcher;

            settings.LoadDefault();
            Settings = settings;
            _telemetryProvider.Initialize(settings);
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
            //ToggleLiveModeCommand = commands.Create(() => IsLiveMode = !IsLiveMode);

            _editorFontSize = Settings.EditorFontSize;
        }

        protected virtual ImmutableArray<Assembly> CompositionAssemblies => ImmutableArray.Create(typeof(MainViewModelBase).Assembly);

        protected virtual ImmutableArray<Type> TypeReferences => ImmutableArray.Create<Type>();

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
            RoslynHost = await Task.Run(() => new RoslynHost(
                CompositionAssemblies,
                RoslynHostReferences.NamespaceDefault.With(
                    typeNamespaceImports: TypeReferences.Add(
                        typeof(ObjectExtensions)
                    )
                ),
                disabledDiagnostics: ImmutableArray.Create("CS1701", "CS1702"))
            )
                .ConfigureAwait(true);

            string runtimeAssemblyPath = typeof(ObjectExtensions).Assembly.Location;
            DefaultReferences = RoslynHost.DefaultReferences;
            DefaultReferencesCompat50 = DefaultReferences.Add(MetadataReference.CreateFromFile(
                Path.Combine(Path.GetDirectoryName(runtimeAssemblyPath)!, "RoslynPad.Runtime.Compat50.dll")));
            CreateNewDocument();
        }

        internal void SetupDocument(DocumentViewModel? documentViewModel = null) {
            Id = Guid.NewGuid().ToString("n");
            BuildPath = Path.Combine(Path.GetTempPath(), "roslynpad", "build", Id);
            Directory.CreateDirectory(BuildPath);

            _results = new ObservableCollection<IResultObject>();
            _restoreSuccessful = true; // initially set to true so we can immediately start running and wait for restore

            NuGetDoc = _serviceProvider.GetService<NuGetDocumentViewModel>();
            _platformFactory.Changed += InitializePlatforms;

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
            if (__currentDocumentId != null)
            {
                RoslynHost.CloseDocument(__currentDocumentId);
            }
            CurrentDocument = documentViewModel == null ? null : DocumentViewModel.FromPath(documentViewModel.Path);
            IsDirty = documentViewModel?.IsAutoSave == true;
            _executionHost.Name = CurrentDocument?.Name ?? "Untitled";
            DocumentChanged.Invoke(this, EventArgs.Empty);
        }

        internal void InitializeDocument(DocumentId documentId,
            Action<ExceptionResultObject?> onError,
            Func<TextSpan> getSelection) {
            _onError = onError;
            _getSelection = getSelection;
            CurrentDocumentId = documentId;
            _isDocInitialized = true;

            Platform = _platformFactory.GetExecutionPlatform();
            UpdatePackages();
            RestartHostCommand?.Execute();
        }
        #endregion

        #region DocumentHandling

        public void EditUserDocumentPath() {
            IFolderBrowserDialog dialog = _serviceProvider.GetService<IFolderBrowserDialog>();
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
        private DocumentViewModel CreateDocumentRoot() {
            _documentWatcher?.Dispose();
            DocumentViewModel root = DocumentViewModel.CreateRoot(Settings.EffectiveDocumentPath);
            _documentWatcher = new DocumentWatcher(_documentFileWatcher, root);
            return root;
        }
        public void CreateNewDocument() {
            SetupDocument(null);
        }
        public async Task OpenFile() {
            if (!IsInitialized) return;

            IOpenFileDialog dialog = _serviceProvider.GetService<IOpenFileDialog>();
            dialog.AllowMultiple = false;
            dialog.Filter = new FileDialogFilter("C# Scripts", "cs", "csx");
            string[] fileName = await dialog.ShowAsync().ConfigureAwait(true);
            if (fileName == null) {
                return;
            }
            // make sure we use the normalized path, in case the user used the wrong capitalization on Windows
            string filePath = IOUtilities.NormalizeFilePath(fileName.First());
            DocumentViewModel document = DocumentViewModel.FromPath(filePath);
            if (!document.IsAutoSave) {
                string autoSavePath = document.GetAutoSavePath();
                if (File.Exists(autoSavePath)) {
                    document = DocumentViewModel.FromPath(autoSavePath);
                }
            }
            OpenDocument(document);
        }
        public void OpenDocument(DocumentViewModel document) {
            if (document.IsFolder) return;
            SetupDocument(document);
        }
        public async Task<string> LoadText() {
            if (CurrentDocument == null) {
                return string.Empty;
            }
            using StreamReader fileStream = File.OpenText(CurrentDocument.Path);
            return await fileStream.ReadToEndAsync().ConfigureAwait(false);
        }
        public async Task AutoSave() {
            if (!IsDirty) return;
            DocumentViewModel document = CurrentDocument;
            if (document == null) {
                int index = 1;
                string path;
                do {
                    path = Path.Combine(WorkingDirectory, DocumentViewModel.GetAutoSaveName("Program" + index++));
                }
                while (File.Exists(path));
                document = DocumentViewModel.FromPath(path);
            }
            CurrentDocument = document;
            await SaveDocument(CurrentDocument.GetAutoSavePath()).ConfigureAwait(false);
        }
        public async Task<SaveResult> Save(bool promptSave) {
            if (_isSaving) return SaveResult.Cancel;
            if (!IsDirty && promptSave) return SaveResult.Save;
            _isSaving = true;
            try {
                SaveResult result = SaveResult.Save;
                if (CurrentDocument == null) {
                    ISaveDocumentDialog dialog = _serviceProvider.GetService<ISaveDocumentDialog>();
                    dialog.ShowDontSave = promptSave;
                    dialog.AllowNameEdit = true;
                    dialog.FilePathFactory = s => DocumentViewModel.GetDocumentPathFromName(WorkingDirectory, s);
                    await dialog.ShowAsync();
                    result = dialog.Result;
                    if (result == SaveResult.Save && dialog.DocumentName != null) {
                        CurrentDocument?.DeleteAutoSave();
                        CurrentDocument = AddDocument(dialog.DocumentName);
                        OnPropertyChanged(nameof(Title));
                    }
                } else if (promptSave) {
                    ISaveDocumentDialog dialog = _serviceProvider.GetService<ISaveDocumentDialog>();
                    dialog.ShowDontSave = true;
                    dialog.DocumentName = CurrentDocument.Name;
                    await dialog.ShowAsync();
                    result = dialog.Result;
                }
                if (result == SaveResult.Save && CurrentDocument != null) {
                    // ReSharper disable once PossibleNullReferenceException
                    await SaveDocument(CurrentDocument.GetSavePath()).ConfigureAwait(true);
                    IsDirty = false;
                }
                if (result != SaveResult.Cancel) {
                    CurrentDocument?.DeleteAutoSave();
                }
                return result;
            } finally {
                _isSaving = false;
            }
        }
        private async Task SaveDocument(string path) {
            if (!_isDocInitialized) return;
            Document document = RoslynHost.GetDocument(CurrentDocumentId);
            if (document == null) {
                return;
            }
            SourceText text = await document.GetTextAsync().ConfigureAwait(false);
            using StreamWriter writer = File.CreateText(path);
            for (int lineIndex = 0; lineIndex < text.Lines.Count - 1; ++lineIndex) {
                string lineText = text.Lines[lineIndex].ToString();
                await writer.WriteLineAsync(lineText).ConfigureAwait(false);
            }
            await writer.WriteAsync(text.Lines[text.Lines.Count - 1].ToString()).ConfigureAwait(false);
        }
        public DocumentViewModel AddDocument(string documentName) {
            return DocumentRootFolder.CreateNew(documentName);
        }
        private void OnDocumentUpdated() {
            DocumentUpdated?.Invoke(this, EventArgs.Empty);
        }
        private void OnEditorFocus() {
            EditorFocus?.Invoke(this, EventArgs.Empty);
        }
        public void OnTextChanged() {
            IsDirty = true;
            CancellationToken cancellationToken = _runCts!.Token;
            UpdatePackages();
        }

        #endregion

        public bool SendTelemetry {
            get => Settings.SendErrors; set {
                Settings.SendErrors = value;
                OnPropertyChanged(nameof(SendTelemetry));
            }
        }
        public async Task OnExit() {
            await Save(false).ConfigureAwait(false);
            IOUtilities.PerformIO(() => Directory.Delete(Path.Combine(Path.GetTempPath(), "RoslynPad"), recursive: true));
        }

        #region Execution
        public Exception? LastError {
            get {
                Exception exception = _telemetryProvider.LastError;
                AggregateException aggregateException = exception as AggregateException;
                return aggregateException?.Flatten() ?? exception;
            }
        }
        public bool HasError => LastError != null;
        public IDelegateCommand ClearErrorCommand { get; }
        public IEnumerable<object> Results => _results;
        internal IEnumerable<IResultObject> ResultsInternal => _results;
        private void AddResult(object o) {
            _dispatcher.InvokeAsync(() => {
                _results.Add(ResultObject.Create(o, DumpQuotas.Default));
                ResultsAvailable?.Invoke();
            }, AppDispatcherPriority.Low);
        }
        private void ClearResults(Func<IResultObject, bool> filter) {
            _dispatcher.InvokeAsync(() => {
                foreach (IResultObject result in _results.Where(filter).ToArray()) {
                    _results.Remove(result);
                }
            });
        }
        private void Reset() {
            if (_runCts != null) {
                _runCts.Cancel();
                _runCts.Dispose();
            }
            _runCts = new CancellationTokenSource();
        }
        //public bool IsLiveMode {
        //    get => _isLiveMode;
        //    private set {
        //        if (!SetProperty(ref _isLiveMode, value)) return;
        //        //RunCommand.RaiseCanExecuteChanged();
        //        if (value) {
        //            // ReSharper disable once UnusedVariable
        //            _ = Run();
        //            if (_liveModeTimer == null) {
        //                _liveModeTimer = new Timer(o => _dispatcher.InvokeAsync(() => {
        //                    // ReSharper disable once UnusedVariable
        //                    var runTask = Run();
        //                }), null, Timeout.Infinite, Timeout.Infinite);
        //            }
        //        }
        //    }
        //}

        private IEnumerable<string> GetReferencePaths(IEnumerable<MetadataReference> references) {
            return references.OfType<PortableExecutableReference>().Select(x => x.FilePath).Where(x => x != null)!;
        }
        private List<LibraryRef> ParseReferences(SyntaxNode syntaxRoot) {
            const string NuGetPrefix = "nuget:";
            const string LegacyNuGetPrefix = "$NuGet\\";
            const string FxPrefix = "framework:";
            List<LibraryRef> libraries = new List<LibraryRef>();
            if (!(syntaxRoot is Microsoft.CodeAnalysis.CSharp.Syntax.CompilationUnitSyntax compilation)) {
                return libraries;
            }
            foreach (Microsoft.CodeAnalysis.CSharp.Syntax.ReferenceDirectiveTriviaSyntax directive in compilation.GetReferenceDirectives()) {
                string value = directive.File.ValueText;
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
                int indexOfSlash = value.IndexOf('/');
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
                string[] split = value.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length >= 3) {
                    return (split[1], split[2]);
                }
                return (null, null);
            }
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

        private void ExecutionHostOnInputRequest()
        {
            _dispatcher.InvokeAsync(() =>
            {
                ReadInput?.Invoke();
            }, AppDispatcherPriority.Low);
        }
        private void ExecutionHostOnDump(ResultObject result)
        {
            AddResult(result);
        }
        private void ExecutionHostOnError(ExceptionResultObject errorResult)
        {
            _dispatcher.InvokeAsync(() =>
            {
                _onError?.Invoke(errorResult);
                if (errorResult != null)
                {
                    _results.Add(errorResult);

                    ResultsAvailable?.Invoke();
                }
            }, AppDispatcherPriority.Low);
        }
        private void ExecutionHostOnCompilationErrors(IList<CompilationErrorResultObject> errors)
        {
            _dispatcher.InvokeAsync(() =>
            {
                foreach (CompilationErrorResultObject error in errors)
                {
                    _results.Add(error);
                }

                ResultsAvailable?.Invoke();
            });
        }

        public void SendInput(string input)
        {
            _executionHost?.SendInputAsync(input);
        }

        private async Task Run()
        {
            if (IsRunning) return;
            ReportedProgress = null;
            Reset();
            SetIsRunning(true);
            StartExec();
            var cancellationToken = _runCts!.Token;
            try
            {
                var code = await GetCode(cancellationToken).ConfigureAwait(true);
                if (_executionHost != null)
                {
                    // Make sure the execution working directory matches the current script path
                    // which may have changed since we loaded.
                    if (_executionHostParameters.WorkingDirectory != WorkingDirectory)
                        _executionHostParameters.WorkingDirectory = WorkingDirectory;

                    await _executionHost.ExecuteAsync(code, false, OptimizationLevel).ConfigureAwait(true);
                }
            }
            catch (CompilationErrorException ex)
            {
                foreach (var diagnostic in ex.Diagnostics)
                {
                    _results.Add(ResultObject.Create(diagnostic, DumpQuotas.Default));
                }
            }
            catch (Exception ex)
            {
                AddResult(ex);
            }
            finally
            {
                SetIsRunning(false);
                ReportedProgress = null;
            }
        }
        private async Task RestartHost()
        {
            Reset();
            try
            {
                await Task.Run(() => _executionHost?.TerminateAsync()).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _telemetryProvider.ReportError(e);
                throw;
            }
            finally
            {
                SetIsRunning(false);
            }
        }
        private async Task<string> GetCode(CancellationToken cancellationToken)
        {
            Document document = RoslynHost.GetDocument(CurrentDocumentId);
            if (document == null)
            {
                return string.Empty;
            }

            return (await document.GetTextAsync(cancellationToken)
                .ConfigureAwait(false)).ToString();
        }

        private void InitializePlatforms()
        {
            //AvailablePlatforms = _platformsFactory.GetExecutionPlatforms().ToImmutableArray();
            _executionHost.DotNetExecutable = _platformFactory.DotNetExecutable;
        }
        private void StartExec()
        {
            ClearResults(t => !(t is RestoreResultObject));

            _onError?.Invoke(null);
        }
        private void UpdatePackages() {
            _restoreCts?.Cancel();
            _restoreCts = new CancellationTokenSource();
            _ = UpdatePackagesAsync(_restoreCts.Token);
            async Task UpdatePackagesAsync(CancellationToken cancellationToken) {
                Document document = RoslynHost.GetDocument(CurrentDocumentId);
                if (document == null) {
                    return;
                }
                SyntaxNode syntaxRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
                List<LibraryRef> libraries = ParseReferences(syntaxRoot!);
                ImmutableArray<MetadataReference> defaultReferences = DefaultReferencesCompat50;
                if (defaultReferences.Length > 0) {
                    libraries.AddRange(GetReferencePaths(defaultReferences).Select(p => LibraryRef.Reference(p)));
                }
                _executionHost.UpdateLibraries(libraries);
            }
        }

        public double? ReportedProgress
        {
            get => _reportedProgress;
            private set
            {
                if (_reportedProgress != value)
                {
                    SetProperty(ref _reportedProgress, value);
                    OnPropertyChanged(nameof(HasReportedProgress));
                }
            }
        }
        public bool HasReportedProgress => ReportedProgress.HasValue;
        private void SetIsRunning(bool value)
        {
            _dispatcher.InvokeAsync(() => IsRunning = value);
        }
        public bool IsRestoring
        {
            get => _isRestoring;
            private set => SetProperty(ref _isRestoring, value);
        }
        public bool RestoreSuccessful
        {
            get => _restoreSuccessful;
            private set
            {
                if (SetProperty(ref _restoreSuccessful, value))
                {
                    //_dispatcher.InvokeAsync(() => RunCommand.RaiseCanExecuteChanged());
                }
            }
        }
        private void OnRestoreStarted()
        {
            IsRestoring = true;
        }
        private void OnRestoreCompleted(RestoreResult restoreResult)
        {
            IsRestoring = false;
            ClearResults(t => t is RestoreResultObject);
            if (restoreResult.Success)
            {
                RoslynHost host = RoslynHost;
                Document document = host.GetDocument(CurrentDocumentId);
                if (document == null)
                {
                    return;
                }
                var project = document.Project;
                project = project
                    .WithMetadataReferences(_executionHost.MetadataReferences)
                    .WithAnalyzerReferences(_executionHost.Analyzers);
                document = project.GetDocument(CurrentDocumentId);
                host.UpdateDocument(document!);
                OnDocumentUpdated();
            }
            else
            {
                foreach (string error in restoreResult.Errors)
                {
                    AddResult(new RestoreResultObject(error, "Error"));
                }
            }
            RestoreSuccessful = restoreResult.Success;
        }

        #endregion

        #region DocumentActions
        public enum CommentAction {
            Comment,
            Uncomment
        }
        public async Task CommentUncommentSelection(CommentAction action) {
            const string singleLineCommentString = "//";

            var document = RoslynHost.GetDocument(CurrentDocumentId);
            if (document == null) {
                return;
            }

            if (_getSelection == null) {
                return;
            }

            TextSpan selection = _getSelection();

            SourceText documentText = await document.GetTextAsync().ConfigureAwait(false);
            List<TextChange> changes = new List<TextChange>();
            TextLine[] lines = documentText.Lines.SkipWhile(x => !x.Span.IntersectsWith(selection))
                .TakeWhile(x => x.Span.IntersectsWith(selection)).ToArray();

            if (action == CommentAction.Comment) {
                foreach (TextLine line in lines) {
                    if (!string.IsNullOrWhiteSpace(documentText.GetSubText(line.Span).ToString())) {
                        changes.Add(new TextChange(new TextSpan(line.Start, 0), singleLineCommentString));
                    }
                }
            } else if (action == CommentAction.Uncomment) {
                foreach (TextLine line in lines) {
                    string text = documentText.GetSubText(line.Span).ToString();
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
            Document document = RoslynHost.GetDocument(CurrentDocumentId);
            Document formattedDocument = await Formatter.FormatAsync(document!).ConfigureAwait(false);
            RoslynHost.UpdateDocument(formattedDocument);
        }
        public async Task RenameSymbol() {
            RoslynHost host = RoslynHost;
            Document document = host.GetDocument(CurrentDocumentId);
            if (document == null || _getSelection == null) {
                return;
            }

            ISymbol symbol = await RenameHelper.GetRenameSymbol(document, _getSelection().Start).ConfigureAwait(true);
            if (symbol == null) return;

            IRenameSymbolDialog dialog = _serviceProvider.GetService<IRenameSymbolDialog>();
            dialog.Initialize(symbol.Name);
            await dialog.ShowAsync();
            if (dialog.ShouldRename) {
                Solution newSolution = await Renamer.RenameSymbolAsync(document.Project.Solution, symbol, dialog.SymbolName ?? string.Empty,
                    document.Project.Solution.Options).ConfigureAwait(true);
                Document newDocument = newSolution.GetDocument(CurrentDocumentId);
                // TODO: possibly update entire solution
                host.UpdateDocument(newDocument!);
            }
            OnEditorFocus();
        }
        #endregion

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
                string[] pathParts = data.Path.Substring(_documentRoot.Path.Length)
                    .Split(PathSeparators, StringSplitOptions.RemoveEmptyEntries);

                DocumentViewModel? current = _documentRoot;

                for (int index = 0; index < pathParts.Length; index++) {
                    if (!current.IsChildrenInitialized) {
                        break;
                    }

                    string part = pathParts[index];
                    bool isLast = index == pathParts.Length - 1;

                    DocumentViewModel parent = current;
                    current = current.InternalChildren[part];

                    // the current part is not in the tree
                    if (current == null) {
                        if (data.Type != DocumentFileChangeType.Deleted) {
                            string currentPath = isLast && data.Type == DocumentFileChangeType.Renamed
                                ? data.NewPath
                                : Path.Combine(_documentRoot.Path, Path.Combine(pathParts.Take(index + 1).ToArray()));

                            DocumentViewModel newDocument = DocumentViewModel.FromPath(currentPath!);
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
