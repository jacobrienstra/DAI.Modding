using System;
using System.ComponentModel;
using System.Composition.Hosting;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

using Avalon.Windows.Controls;

using AvalonDock;
using AvalonDock.Layout.Serialization;

using RoslynPad.UI;
using RoslynPad.Utilities;

namespace RoslynPad
{
    /// <summary>
    /// Interaction logic for MainWindowRoslynPad.xaml
    /// </summary>
    public partial class MainWindowRoslynPad
    {
        private readonly MainViewModelBase _viewModel;

        public MainWindowRoslynPad()
        {
            Loaded += OnLoaded;

            var container = new ContainerConfiguration()
                .WithAssembly(typeof(MainViewModelBase).Assembly)   // RoslynPad.Common.UI
                .WithAssembly(typeof(MainWindowRoslynPad).Assembly);         // RoslynPad
            var locator = container.CreateContainer().GetExport<IServiceProvider>();

            _viewModel = locator.GetService<MainViewModelBase>();

            DataContext = _viewModel;
            InitializeComponent();
            //DocumentsPane.ToggleAutoHide();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnLoaded;

            await _viewModel.Initialize().ConfigureAwait(false);
        }

        private async void DockingManager_OnDocumentClosing(object sender, DocumentClosingEventArgs e)
        {
            e.Cancel = true;
            var document = (OpenDocumentViewModel)e.Document.Content;
            await _viewModel.CloseDocument(document).ConfigureAwait(false);
        }

        private void ViewErrorDetails_OnClick(object sender, RoutedEventArgs e)
        {
            if (_viewModel.LastError == null) return;

            TaskDialog.ShowInline(this, "Unhandled Exception",
                _viewModel.LastError.ToAsyncString(), string.Empty, TaskDialogButtons.Close);
        }
    }
}
