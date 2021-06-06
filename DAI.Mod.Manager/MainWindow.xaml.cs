using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Forms;
using System.Reflection;

using DAI.Mod.Manager.Frostbite;
using DAI.Mod.Manager.Utilities;

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
            _viewModel.MergeMods(VerboseLoggingCheckBox.IsChecked.GetValueOrDefault(), ForceRescanCheckBox.IsChecked.GetValueOrDefault());
        }

        private void ModPathBrowseButton_Click(object sender, RoutedEventArgs e) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (!string.IsNullOrWhiteSpace(Settings.ModPath)) {
                folderBrowserDialog.SelectedPath = Settings.ModPath;
            }
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                Settings.ModPath = folderBrowserDialog.SelectedPath;
                ModPathTextBox.Text = Settings.ModPath;
                LoadMods();
                Settings.Save();
            }
        }

        private void BasePathBrowseButton_Click(object sender, RoutedEventArgs e) {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "*.exe|*.exe";
            openFileDialog.Title = "Find Dragon Age: Inquisition executable";
            if (!openFileDialog.ShowDialog().Value) {
                return;
            }
            Settings.BasePath = Path.GetDirectoryName(openFileDialog.FileName) + "\\";
            DAPathTextBox.Text = Settings.BasePath;
            if (File.Exists(Settings.BasePath + "Update\\Patch\\package.mft")) {
                int num = int.Parse(DAIMft.SerializeFromFile(Settings.BasePath + "Update\\Patch\\package.mft").GetValue("Version"));
                if (Settings.PatchVersion != num) {
                    Settings.RescanPatch = true;
                }
                Settings.PatchVersion = num;
            } else {
                Settings.PatchVersion = -1;
            }
            LoadMods();
            Settings.Save();
        }

        private void ModListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            //if (ModListBox.SelectedItem == null) {
            //    ModTitleTextBlock.Text = "";
            //    ModAuthorTextBlock.Text = "";
            //    ModVersionTextBlock.Text = "";
            //    ModDescriptionTextBox.Text = "";
            //    ModMinPatchVersionTextBlock.Text = "";
            //    ModConfigureButton.IsEnabled = false;
            //    return;
            //}
            ModContainer modContainer = (ModContainer)ModListBox.SelectedItem;
            //ModTitleTextBlock.Text = modContainer.Name;
            //ModAuthorTextBlock.Text = modContainer.Author;
            //ModVersionTextBlock.Text = modContainer.Version;
            //ModDescriptionTextBox.Text = modContainer.Description;
            ModMinPatchVersionTextBlock.Text = (modContainer.MinPatchVersion != -1) ? modContainer.MinPatchVersion.ToString() : "None";
            MoveModUpButton.IsEnabled = !modContainer.IsOfficialPatch;
            MoveModDownButton.IsEnabled = !modContainer.IsOfficialPatch;
            if (ModListBox.SelectedIndex != 0) {
                MoveModUpButton.IsEnabled = !((ModContainer)ModListBox.Items[ModListBox.SelectedIndex - 1]).IsOfficialPatch;
            }
            if (ModListBox.SelectedIndex == ModListBox.Items.Count - 1) {
                MoveModDownButton.IsEnabled = false;
            }
            ModConfigureButton.IsEnabled = modContainer.IsDAIMod() && modContainer.Mod.ScriptObject != null;
            ChangeStatusModButton.IsEnabled = !modContainer.IsOfficialPatch && (modContainer.MinPatchVersion == -1 || Settings.PatchVersion >= modContainer.MinPatchVersion);
            //ModMessageTextBlock.Text = (Settings.PatchVersion < modContainer.MinPatchVersion) ? "(This mod is incompatible with your patch.)" : "";
        }

        private void ModListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            SwitchSelectedModStatus();
        }

        private void ChangeStatusModButton_Click(object sender, RoutedEventArgs e) {
            SwitchSelectedModStatus();
        }

        private void SwitchSelectedModStatus() {
            ModContainer selectedMod = _viewModel.SelectedMod;
            if (selectedMod != null) {
                if (!selectedMod.IsOfficialPatch && Settings.PatchVersion >= selectedMod.MinPatchVersion) {
                    selectedMod.IsEnabled = !selectedMod.IsEnabled;
                    ModListBox.GetBindingExpression(ModListBox.SelectedItem as DependencyProperty).UpdateTarget();
                }
            }
        }

        private void MoveModUpButton_Click(object sender, RoutedEventArgs e) {
            ModContainer modContainer = (ModContainer)ModListBox.SelectedItem;
            ModContainer modContainer2 = (ModContainer)ModListBox.Items[ModListBox.SelectedIndex - 1];
            int index = modContainer.Index;
            modContainer.Index = modContainer2.Index;
            modContainer2.Index = index;
            ModListBox.Items.Remove(modContainer);
            ModListBox.Items.Remove(modContainer2);
            ModListBox.Items.Insert(modContainer.Index, modContainer);
            ModListBox.Items.Insert(modContainer2.Index, modContainer2);
            ModListBox.SelectedItem = modContainer;
        }

        private void MoveModDownButton_Click(object sender, RoutedEventArgs e) {
            ModContainer modContainer = (ModContainer)ModListBox.SelectedItem;
            ModContainer modContainer2 = (ModContainer)ModListBox.Items[ModListBox.SelectedIndex + 1];
            int index = modContainer.Index;
            modContainer.Index = modContainer2.Index;
            modContainer2.Index = index;
            ModListBox.Items.Remove(modContainer);
            ModListBox.Items.Remove(modContainer2);
            ModListBox.Items.Insert(modContainer2.Index, modContainer2);
            ModListBox.Items.Insert(modContainer.Index, modContainer);
            ModListBox.SelectedItem = modContainer;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Settings.SetDefaults();
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\daimodmanager.ini")) {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = "DragonAgeInquisition.exe|DragonAgeInquisition.exe|All Files (*.*)|*.*";
                openFileDialog.Title = "Find Dragon Age: Inquisition executable";
                if (openFileDialog.ShowDialog().Value) {
                    Settings.BasePath = Path.GetDirectoryName(openFileDialog.FileName) + "\\";
                }
            } else {
                Settings.Load();
            }
            if (File.Exists(Settings.BasePath + "Update\\Patch\\package.mft")) {
                int num = int.Parse(DAIMft.SerializeFromFile(Settings.BasePath + "Update\\Patch\\package.mft").GetValue("Version"));
                if (Settings.PatchVersion != num) {
                    Settings.RescanPatch = true;
                }
                Settings.PatchVersion = num;
            } else {
                Settings.PatchVersion = -1;
            }
            if ("v0.60 alpha" != Settings.CurrentVersion) {
                Settings.RescanPatch = true;
                Settings.CurrentVersion = "v0.60 alpha";
            }
            DAPathTextBox.Text = Settings.BasePath;
            ModPathTextBox.Text = Settings.ModPath;
            LoadMods();
            Settings.Save();
        }

        private void Window_Closing(object sender, CancelEventArgs e) {
            if (ProgressWin != null && ProgressWin.IsActive) {
                ProgressWin.Close();
            }
        }

        private void ModConfigureButton_Click(object sender, RoutedEventArgs e) {
            if (ModListBox.SelectedItem != null) {
                ModContainer modContainer = (ModContainer)ModListBox.SelectedItem;
                ModConfigElementsList modConfigElementsList = new ModConfigElementsList();
                modContainer.Mod.ScriptObject.ConstructUI(modConfigElementsList);
                ModConfigWindow modConfigWindow = new ModConfigWindow(modConfigElementsList, modContainer.Mod.ConfigValues);
                modConfigWindow.ShowDialog();
                modContainer.Mod.ConfigValues = modConfigWindow.ConfigValues;
            }
        }
    }
}
