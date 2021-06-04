using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Shell;
using System.Windows.Threading;

using DAI.Utilities;
using DAI.Mod.Manager.Frostbite;
using DAI.Mod.Manager.Utilities;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;
using System.Reflection;

namespace DAI.Mod.Manager {
    public partial class MainWindow : Window, IComponentConnector {
        public BackgroundWorker BGWorker;

        private const string PatchBasePath = "Update\\Patch\\";

        private ManagerViewModel _viewModel;

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
            Cancelled = true;
            Close();
        }

        private void MergeButton_Click(object sender, RoutedEventArgs e) {
            Cancelled = false;
            if (Cancelled) {
                return;
            }
            Settings.VerboseScan = VerboseLoggingCheckBox.IsChecked.GetValueOrDefault();
            Settings.RescanPatch |= ForceRescanCheckBox.IsChecked.GetValueOrDefault();
            List<ModContainer> modList = (from ModContainer modContainer in ModListBox.Items
                                          where modContainer.IsEnabled
                                          select modContainer).ToList();
            string text;
            if (MergeDestinationCheckBox.IsChecked.GetValueOrDefault()) {
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.Title = "Save merged patch";
                saveFileDialog.FileName = "package.mft";
                saveFileDialog.Filter = "package.mft|*.mft";
                if (!saveFileDialog.ShowDialog().Value) {
                    return;
                }
                text = saveFileDialog.FileName.Remove(saveFileDialog.FileName.LastIndexOf('\\') + 1).ToLower();
            } else {
                text = Settings.BasePath + "Update\\Patch_ModManagerMerge\\";
            }
            if (text == Settings.BasePath.ToLower() || text == Settings.BasePath.ToLower() + "update\\" || text == Settings.BasePath.ToLower() + "Update\\Patch\\") {
                System.Windows.MessageBox.Show("You tried to save the merged patch to an invalid location. Please read usage instructions carefully and try again.", "Error");
                return;
            }
            ProgressWin = new ProgressWindow();
            Scripting.ProgressWindow = ProgressWin;
            ProgressWin.Show();
            BGWorker.RunWorkerAsync(new WorkerState(WorkerStateType.WorkerState_SavePatch, new PatchPayloadData {
                CreateDistPatch = false,
                IncludeProjectData = false,
                OutputPath = text,
                ModList = modList
            }));
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
            if (ModListBox.SelectedItem == null) {
                ModTitleTextBlock.Text = "";
                ModAuthorTextBlock.Text = "";
                ModVersionTextBlock.Text = "";
                ModDescriptionTextBox.Text = "";
                ModMinPatchVersionTextBlock.Text = "";
                ModConfigureButton.IsEnabled = false;
                return;
            }
            ModContainer modContainer = (ModContainer)ModListBox.SelectedItem;
            ModTitleTextBlock.Text = modContainer.Name;
            ModAuthorTextBlock.Text = modContainer.Author;
            ModVersionTextBlock.Text = modContainer.Version;
            ModDescriptionTextBox.Text = modContainer.Description;
            ModMinPatchVersionTextBlock.Text = ((modContainer.MinPatchVersion != -1) ? modContainer.MinPatchVersion.ToString() : "None");
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
            ChangeStatusModButton.Content = (modContainer.IsEnabled ? "Disable" : "Enable");
            ModMessageTextBlock.Text = ((Settings.PatchVersion < modContainer.MinPatchVersion) ? "(This mod is incompatible with your patch.)" : "");
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

        private void ChangeStatusModButton_Click(object sender, RoutedEventArgs e) {
            ModContainer modContainer = (ModContainer)ModListBox.SelectedItem;
            modContainer.IsEnabled = !modContainer.IsEnabled;
            ChangeStatusModButton.Content = (modContainer.IsEnabled ? "Disable" : "Enable");
            ModListBox.Items.Refresh();
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

        private void ModListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            if (ModListBox.SelectedItem != null) {
                ModContainer modContainer = (ModContainer)ModListBox.SelectedItem;
                if (!modContainer.IsOfficialPatch && Settings.PatchVersion >= modContainer.MinPatchVersion) {
                    modContainer.IsEnabled = !modContainer.IsEnabled;
                    ChangeStatusModButton.Content = (modContainer.IsEnabled ? "Disable" : "Enable");
                    ModListBox.Items.Refresh();
                }
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
