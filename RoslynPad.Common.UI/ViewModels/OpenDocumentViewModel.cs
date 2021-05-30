using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Options;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.Text;
using NuGet.Versioning;
using RoslynPad.Build;
using RoslynPad.NuGet;
using RoslynPad.Roslyn.Rename;
using RoslynPad.Runtime;
using RoslynPad.Utilities;

namespace RoslynPad.UI
{
    [Export]
    public class OpenDocumentViewModel : NotificationObject
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly IAppDispatcher _dispatcher;
        private readonly ITelemetryProvider _telemetryProvider;
        private readonly IExecutionHost _executionHost;
        private readonly ObservableCollection<IResultObject> _results;
        private readonly ExecutionHostParameters _executionHostParameters;

        private CancellationTokenSource? _runCts;
        private bool _isDirty;
        private bool _isSaving;
        private Action<ExceptionResultObject?>? _onError;
        private Func<TextSpan>? _getSelection;
        private bool _isInitialized;
        private DocumentViewModel? _document;
        private DocumentId? _documentId;

        public string Id { get; }
        public string BuildPath { get; }

        public string WorkingDirectory => Document != null
            ? Path.GetDirectoryName(Document.Path)!
            : MainViewModel.DocumentRoot.Path;

        public IEnumerable<object> Results => _results;
        internal IEnumerable<IResultObject> ResultsInternal => _results;

        public DocumentViewModel? Document
        {
            get => _document;
            private set
            {
                if (_document != value)
                {
                    _document = value;

                    if (_executionHost != null && value != null)
                    {
                        _executionHost.Name = value.Name;
                    }
                }
            }
        }

        [ImportingConstructor]
        public OpenDocumentViewModel(IServiceProvider serviceProvider, MainViewModelBase mainViewModel, ICommandProvider commands, IAppDispatcher appDispatcher, ITelemetryProvider telemetryProvider)
        {
            Id = Guid.NewGuid().ToString("n");
            BuildPath = Path.Combine(Path.GetTempPath(), "roslynpad", "build", Id);
            Directory.CreateDirectory(BuildPath);

            _telemetryProvider = telemetryProvider;
            _serviceProvider = serviceProvider;
            _results = new ObservableCollection<IResultObject>();

            CommandProvider = commands;

            _dispatcher = appDispatcher;

            OpenBuildPathCommand = commands.Create(() => OpenBuildPath());
            SaveCommand = commands.CreateAsync(() => Save(promptSave: false));

            var roslynHost = MainViewModel.RoslynHost;

            _executionHostParameters = new ExecutionHostParameters(
                BuildPath,
                serviceProvider.GetService<NuGetViewModel>().ConfigPath,
                roslynHost.DefaultImports,
                roslynHost.DisabledDiagnostics,
                WorkingDirectory);
            _executionHost = new ExecutionHost(_executionHostParameters, roslynHost);

            _executionHost.Dumped += ExecutionHostOnDump;
            _executionHost.Error += ExecutionHostOnError;
            _executionHost.ReadInput += ExecutionHostOnInputRequest;
            _executionHost.CompilationErrors += ExecutionHostOnCompilationErrors;
        }

        private void OnDocumentUpdated()
        {
            DocumentUpdated?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler? DocumentUpdated;

        public event Action? ReadInput;

        public event Action? ResultsAvailable;

        private void AddResult(object o)
        {
            AddResult(ResultObject.Create(o, DumpQuotas.Default));
        }

        private void AddResult(IResultObject o)
        {
            _dispatcher.InvokeAsync(() =>
            {
                _results.Add(o);
                ResultsAvailable?.Invoke();
            }, AppDispatcherPriority.Low);
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
                foreach (var error in errors)
                {
                    _results.Add(error);
                }

                ResultsAvailable?.Invoke();
            });
        }

        public void SetDocument(DocumentViewModel? document)
        {
            Document = document == null ? null : DocumentViewModel.FromPath(document.Path);

            IsDirty = document?.IsAutoSave == true;

            _executionHost.Name = Document?.Name ?? "Untitled";
        }

        public void SendInput(string input)
        {
            _ = _executionHost?.SendInputAsync(input);
        }

        private IEnumerable<string> GetReferencePaths(IEnumerable<MetadataReference> references)
        {
            return references.OfType<PortableExecutableReference>().Select(x => x.FilePath).Where(x => x != null)!;
        }

        public async Task RenameSymbol()
        {
            var host = MainViewModel.RoslynHost;
            var document = host.GetDocument(DocumentId);
            if (document == null || _getSelection == null)
            {
                return;
            }

            var symbol = await RenameHelper.GetRenameSymbol(document, _getSelection().Start).ConfigureAwait(true);
            if (symbol == null) return;

            var dialog = _serviceProvider.GetService<IRenameSymbolDialog>();
            dialog.Initialize(symbol.Name);
            await dialog.ShowAsync();
            if (dialog.ShouldRename)
            {
                var newSolution = await Renamer.RenameSymbolAsync(document.Project.Solution, symbol, dialog.SymbolName ?? string.Empty,
                    document.Project.Solution.Options).ConfigureAwait(true);
                var newDocument = newSolution.GetDocument(DocumentId);
                // TODO: possibly update entire solution
                host.UpdateDocument(newDocument!);
            }
            OnEditorFocus();
        }

        public enum CommentAction
        {
            Comment,
            Uncomment
        }

        public async Task CommentUncommentSelection(CommentAction action)
        {
            const string singleLineCommentString = "//";

            var document = MainViewModel.RoslynHost.GetDocument(DocumentId);
            if (document == null)
            {
                return;
            }

            if (_getSelection == null)
            {
                return;
            }

            var selection = _getSelection();

            var documentText = await document.GetTextAsync().ConfigureAwait(false);
            var changes = new List<TextChange>();
            var lines = documentText.Lines.SkipWhile(x => !x.Span.IntersectsWith(selection))
                .TakeWhile(x => x.Span.IntersectsWith(selection)).ToArray();

            if (action == CommentAction.Comment)
            {
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(documentText.GetSubText(line.Span).ToString()))
                    {
                        changes.Add(new TextChange(new TextSpan(line.Start, 0), singleLineCommentString));
                    }
                }
            }
            else if (action == CommentAction.Uncomment)
            {
                foreach (var line in lines)
                {
                    var text = documentText.GetSubText(line.Span).ToString();
                    if (text.TrimStart().StartsWith(singleLineCommentString, StringComparison.Ordinal))
                    {
                        changes.Add(new TextChange(new TextSpan(
                            line.Start + text.IndexOf(singleLineCommentString, StringComparison.Ordinal),
                            singleLineCommentString.Length), string.Empty));
                    }
                }
            }

            if (changes.Count == 0) return;

            MainViewModel.RoslynHost.UpdateDocument(document.WithText(documentText.WithChanges(changes)));
            if (action == CommentAction.Uncomment && MainViewModel.Settings.FormatDocumentOnComment)
            {
                await FormatDocument().ConfigureAwait(false);
            }
        }

        public async Task FormatDocument()
        {
            var document = MainViewModel.RoslynHost.GetDocument(DocumentId);
            var formattedDocument = await Formatter.FormatAsync(document!).ConfigureAwait(false);
            MainViewModel.RoslynHost.UpdateDocument(formattedDocument);
        }

        public async Task AutoSave()
        {
            if (!IsDirty) return;

            var document = Document;

            if (document == null)
            {
                var index = 1;
                string path;

                do
                {
                    path = Path.Combine(WorkingDirectory, DocumentViewModel.GetAutoSaveName("Program" + index++));
                }
                while (File.Exists(path));

                document = DocumentViewModel.FromPath(path);
            }

            Document = document;

            await SaveDocument(Document.GetAutoSavePath()).ConfigureAwait(false);
        }

        public void OpenBuildPath()
        {
            Task.Run(() =>
            {
                try
                {
                    Process.Start(new ProcessStartInfo(new Uri("file://" + BuildPath).ToString()) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    _telemetryProvider.ReportError(ex);
                }
            });
        }

        public async Task<SaveResult> Save(bool promptSave)
        {
            if (_isSaving) return SaveResult.Cancel;
            if (!IsDirty && promptSave) return SaveResult.Save;
            _isSaving = true;
            try
            {
                var result = SaveResult.Save;
                if (Document == null || Document.IsAutoSaveOnly)
                {
                    var dialog = _serviceProvider.GetService<ISaveDocumentDialog>();
                    dialog.ShowDontSave = promptSave;
                    dialog.AllowNameEdit = true;
                    dialog.FilePathFactory = s => DocumentViewModel.GetDocumentPathFromName(WorkingDirectory, s);
                    await dialog.ShowAsync();
                    result = dialog.Result;
                    if (result == SaveResult.Save && dialog.DocumentName != null)
                    {
                        Document?.DeleteAutoSave();
                        Document = MainViewModel.AddDocument(dialog.DocumentName);
                        OnPropertyChanged(nameof(Title));
                    }
                }
                else if (promptSave)
                {
                    var dialog = _serviceProvider.GetService<ISaveDocumentDialog>();
                    dialog.ShowDontSave = true;
                    dialog.DocumentName = Document.Name;
                    await dialog.ShowAsync();
                    result = dialog.Result;
                }
                if (result == SaveResult.Save && Document != null)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    await SaveDocument(Document.GetSavePath()).ConfigureAwait(true);
                    IsDirty = false;
                }
                if (result != SaveResult.Cancel)
                {
                    Document?.DeleteAutoSave();
                }
                return result;
            }
            finally
            {
                _isSaving = false;
            }
        }

        private async Task SaveDocument(string path)
        {
            if (!_isInitialized) return;

            var document = MainViewModel.RoslynHost.GetDocument(DocumentId);
            if (document == null)
            {
                return;
            }

            var text = await document.GetTextAsync().ConfigureAwait(false);

            using var writer = File.CreateText(path);
            for (int lineIndex = 0; lineIndex < text.Lines.Count - 1; ++lineIndex)
            {
                var lineText = text.Lines[lineIndex].ToString();
                await writer.WriteLineAsync(lineText).ConfigureAwait(false);
            }

            await writer.WriteAsync(text.Lines[text.Lines.Count - 1].ToString()).ConfigureAwait(false);
        }

        internal void Initialize(DocumentId documentId,
            Action<ExceptionResultObject?> onError,
            Func<TextSpan> getSelection)
        {
            _onError = onError;
            _getSelection = getSelection;
            DocumentId = documentId;
            _isInitialized = true;
        }

        public DocumentId DocumentId
        {
            get => _documentId ?? throw new ArgumentNullException(nameof(_documentId));
            private set => _documentId = value;
        }

        public MainViewModelBase MainViewModel { get; }
        public ICommandProvider CommandProvider { get; }

        public string Title => Document != null && !Document.IsAutoSaveOnly ? Document.Name : "New";

        public IDelegateCommand OpenBuildPathCommand { get; }

        public IDelegateCommand SaveCommand { get; }

        //public IDelegateCommand FormatDocumentCommand { get; }

        //public IDelegateCommand CommentSelectionCommand { get; }

        //public IDelegateCommand UncommentSelectionCommand { get; }

        //public IDelegateCommand RenameSymbolCommand { get; }


        private void ClearResults(Func<IResultObject, bool> filter)
        {
            _dispatcher.InvokeAsync(() =>
            {
                foreach (var result in _results.Where(filter).ToArray())
                {
                    _results.Remove(result);
                }
            });
        }

        private async Task<string> GetCode(CancellationToken cancellationToken)
        {
            var document = MainViewModel.RoslynHost.GetDocument(DocumentId);
            if (document == null)
            {
                return string.Empty;
            }

            return (await document.GetTextAsync(cancellationToken)
                .ConfigureAwait(false)).ToString();
        }

        private void Reset()
        {
            if (_runCts != null)
            {
                _runCts.Cancel();
                _runCts.Dispose();
            }
            _runCts = new CancellationTokenSource();
        }

        public async Task<string> LoadText()
        {
            if (Document == null)
            {
                return string.Empty;
            }

            using var fileStream = File.OpenText(Document.Path);
            return await fileStream.ReadToEndAsync().ConfigureAwait(false);
        }

        public bool IsDirty
        {
            get => _isDirty;
            private set => SetProperty(ref _isDirty, value);
        }

        public event EventHandler? EditorFocus;

        private void OnEditorFocus()
        {
            EditorFocus?.Invoke(this, EventArgs.Empty);
        }

        public void OnTextChanged()
        {
            IsDirty = true;
        }
    }
}
