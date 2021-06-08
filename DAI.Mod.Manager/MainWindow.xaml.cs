using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Reflection;

using DAI.Mod.Manager.Frostbite;

// TODO: inotify for 2 way bindings ugh

namespace DAI.Mod.Manager {
    public partial class MainWindow : Window, IComponentConnector {
        public BackgroundWorker BGWorker;

        private const string PatchBasePath = "Update\\Patch\\";

        private readonly ManagerViewModel _viewModel;

        public MainWindow() {
            InitializeComponent();
            BGWorker = new BackgroundWorker();
            ConstructWindowTitle();
            _viewModel = new ManagerViewModel(BGWorker);
            DataContext = _viewModel;
        }

        private void LoadMods() {
            _viewModel.LoadMods();
        }

        private void ConstructWindowTitle() {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            base.Title = "DAI Mod Manager v" + version.ToString() + " alpha";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            _viewModel.Cancelled = true;
            Close();
        }

        private void MergeButton_Click(object sender, RoutedEventArgs e) {
            _viewModel.MergeMods();
        }

        private void ModPathBrowseButton_Click(object sender, RoutedEventArgs e) {
            _viewModel.SetModPath();
        }

        private void BasePathBrowseButton_Click(object sender, RoutedEventArgs e) {
            _viewModel.SetBasePath();
        }

        //private void ModListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        //    if (ModListBox.SelectedIndex == 0) {
        //        MoveModUpButton.IsEnabled = false;
        //    }
        //    if (ModListBox.SelectedIndex == ModListBox.Items.Count - 1) {
        //        MoveModDownButton.IsEnabled = false;
        //    }
        //}

        private void ModListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            _viewModel.SwitchSelectedModStatus();
        }

        private void ChangeStatusModButton_Click(object sender, RoutedEventArgs e) {
            _viewModel.SwitchSelectedModStatus();
        }

        private void MoveModUpButton_Click(object sender, RoutedEventArgs e) {
            _viewModel.MoveSelectedModUp();
        }

        private void MoveModDownButton_Click(object sender, RoutedEventArgs e) {
            _viewModel.MoveSelectedModDown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Settings.SetDefaults();
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\daimodmanager.ini")) {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog {
                    Filter = "DragonAgeInquisition.exe|DragonAgeInquisition.exe|All Files (*.*)|*.*",
                    Title = "Find Dragon Age: Inquisition executable"
                };
                if (openFileDialog.ShowDialog().Value) {
                    _viewModel.DAIPath = Path.GetDirectoryName(openFileDialog.FileName) + "\\";
                }
            } else {
                Settings.Load();
            }
            if (File.Exists(_viewModel.DAIPath + "Update\\Patch\\package.mft")) {
                int num = int.Parse(DAIMft.SerializeFromFile(Settings.BasePath + "Update\\Patch\\package.mft").GetValue("Version"));
                if (Settings.PatchVersion != num) {
                    _viewModel.ForceRescan = true;
                }
                Settings.PatchVersion = num;
            } else {
                Settings.PatchVersion = -1;
            }
            //if ("v0.60 alpha" != Settings.CurrentVersion) {
            //    Settings.RescanPatch = true;
            //    Settings.CurrentVersion = "v0.60 alpha";
            //}
            LoadMods();
            
        }

        private void Window_Closing(object sender, CancelEventArgs e) {
            if (_viewModel.ProgressWin != null && _viewModel.ProgressWin.IsActive) {
                _viewModel.ProgressWin.Close();
            }
        }

        private void ModConfigureButton_Click(object sender, RoutedEventArgs e) {
            if (ModListBox.SelectedItem != null) {
                ModConfigElementsList modConfigElementsList = new ModConfigElementsList();
                _viewModel.SelectedMod.Mod.ScriptObject.ConstructUI(modConfigElementsList);
                ModConfigWindow modConfigWindow = new ModConfigWindow(modConfigElementsList, _viewModel.SelectedMod.Mod.ConfigValues);
                modConfigWindow.ShowDialog();
                _viewModel.SelectedMod.Mod.ConfigValues = modConfigWindow.ConfigValues;
            }
        }
    }
}
