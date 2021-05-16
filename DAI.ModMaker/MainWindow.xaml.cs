using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.FrostbiteAssets;
using DAI.ModMaker.DAIMod;
using DAI.ModMaker.DAIModules;
using DAI.ModMaker.Properties;
using DAI.ModMaker.Utilities;
using DAI.ModMaker.Themes;
using DAI.ModMaker;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Shell;
using System.Windows.Threading;

namespace DAI.ModMaker
{
    public partial class MainWindow : Window, IComponentConnector
    {
        private BackgroundWorker _BGWorker;

        private Dictionary<int, AssetFolder> _AssetFolders;

        private SearchWindow _SearchDialog;

        private ModJob _CurrentMod;

        private bool _MustExit;

        private int _NbTocsToParse;

        private int _NbTocsParsed;

        public MainWindow()
        {
            InitializeComponent();
            ConstructWindowTitle();
            _BGWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _BGWorker.DoWork += BGWorker_DoWork;
            _BGWorker.RunWorkerCompleted += BGWorker_RunWorkerCompleted;
            _BGWorker.ProgressChanged += BGWorker_ProgressChanged;
            AssetFolderTreeView.AddHandler(TreeViewItem.ExpandedEvent, new RoutedEventHandler(AssetFolderTreeView_ItemExpanded));
            AssetFolderTreeView.AddHandler(TreeViewItem.CollapsedEvent, new RoutedEventHandler(AssetFolderTreeView_ItemCollapsed));
            _AssetFolders = new Dictionary<int, AssetFolder>();
            AssetFolder assetFolder = new AssetFolder
            {
                Name = "Data"
            };
            _AssetFolders.Add("Data/".GetHashCode(), assetFolder);
            Version appVersion = Assembly.GetExecutingAssembly().GetName().Version;
            string appVersionString = appVersion.ToString();
            if (Settings.Default.ApplicationVersion != appVersion.ToString())
            {
                Settings.Default.Upgrade();
                Settings.Default.ApplicationVersion = appVersionString;
                Settings.Default.Save();
            }
            InitTemplates();
            Library.EventManager.BeginGameFolderParsing += EventManager_BeginGameFolderParsing;
            Library.EventManager.BeginTocParsing += EventManager_BeginTocParsing;
        }

        private void File_NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (_BGWorker.IsBusy)
            {
                WriteLogEntry("Unable to complete request. Currently there is another async task in progress. Please try again later");
            }
            else if (System.Windows.MessageBox.Show("This will clear all currently modified data. Continue?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _BGWorker.RunWorkerAsync(new WorkerState(WorkerStateType.WorkerState_NewPatch, null));
                _CurrentMod = new ModJob("NewMod", "", "");
                Version version = Assembly.GetEntryAssembly().GetName().Version;
                int applicationVersionInt = version.Minor * 1000 + version.Build * 100 + version.Revision;
                Guid guid = Guid.NewGuid();
                _CurrentMod.Meta = new ModMetaData(1, applicationVersionInt, guid.ToString().ToUpper(), (byte)Library.PatchVersion, new ModDetail("NewMod", "v0.1", Settings.Default.DefaultAuthor, ""));
                ConstructWindowTitle();
            }
        }

        private void File_OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (_BGWorker.IsBusy)
            {
                WriteLogEntry("Unable to complete request. Currently there is another async task in progress. Please try again later");
            }
            else if (System.Windows.MessageBox.Show("This will clear all currently modified data. Continue?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Title = "Open Patch",
                    Filter = "*.daimod|*.daimod|*.mft|*.mft"
                };
                if (openFileDialog.ShowDialog().Value)
                {
                    _BGWorker.RunWorkerAsync(new WorkerState(WorkerStateType.WorkerState_OpenPatch, openFileDialog.FileName));
                }
            }
        }

        private void File_SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (_BGWorker.IsBusy)
            {
                WriteLogEntry("Unable to complete request. Currently there is another async task in progress. Please try again later");
                return;
            }
            if (string.IsNullOrEmpty(_CurrentMod.FileName))
            {
                ModConfiguration modConfiguration = new ModConfiguration(_CurrentMod.Meta.Details.Name, _CurrentMod.Meta.Details.Author, _CurrentMod.Meta.Details.Version, _CurrentMod.Meta.Details.Description);
                modConfiguration.ShowDialog();
                if (modConfiguration.Cancelled)
                {
                    return;
                }
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Title = "Save mod file",
                    Filter = "*.daimod|*.daimod"
                };
                if (!saveFileDialog.ShowDialog().Value)
                {
                    return;
                }
                _CurrentMod.Name = modConfiguration.ModTitle;
                _CurrentMod.Meta.Details.Name = modConfiguration.ModTitle;
                _CurrentMod.Meta.Details.Version = modConfiguration.ModVersion;
                _CurrentMod.Meta.Details.Description = modConfiguration.ModDescription;
                _CurrentMod.Meta.Details.Author = modConfiguration.ModAuthor;
                if (string.IsNullOrEmpty(Settings.Default.DefaultAuthor))
                {
                    Settings.Default.DefaultAuthor = modConfiguration.ModAuthor;
                    Settings.Default.Save();
                }
                else if (Settings.Default.DefaultAuthor != modConfiguration.ModAuthor && System.Windows.MessageBox.Show("Author differs to the default author currently stored. Do you wish to set this author as the new default?", "Request change to Default Author", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Settings.Default.DefaultAuthor = modConfiguration.ModAuthor;
                    Settings.Default.Save();
                }
                _CurrentMod.FileName = saveFileDialog.FileName;
            }
            PatchPayloadData patchPayloadDatum = new PatchPayloadData
            {
                OutputPath = _CurrentMod.FileName,
                Mod = _CurrentMod
            };
            _BGWorker.RunWorkerAsync(new WorkerState(WorkerStateType.WorkerState_SavePatch, patchPayloadDatum));
            ConstructWindowTitle();
        }

        private void File_SaveAsCommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            if (_BGWorker.IsBusy)
            {
                WriteLogEntry("Unable to complete request. Currently there is another async task in progress. Please try again later");
                return;
            }
            ModConfiguration modConfiguration = new ModConfiguration(_CurrentMod.Meta.Details.Name, _CurrentMod.Meta.Details.Author, _CurrentMod.Meta.Details.Version, _CurrentMod.Meta.Details.Description);
            modConfiguration.ShowDialog();
            if (modConfiguration.Cancelled)
            {
                return;
            }
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Title = "Save mod file",
                Filter = "*.daimod|*.daimod"
            };
            if (saveFileDialog.ShowDialog().Value)
            {
                _CurrentMod.Name = modConfiguration.ModTitle;
                _CurrentMod.Meta.Details.Name = modConfiguration.ModTitle;
                _CurrentMod.Meta.Details.Version = modConfiguration.ModVersion;
                _CurrentMod.Meta.Details.Description = modConfiguration.ModDescription;
                _CurrentMod.Meta.Details.Author = modConfiguration.ModAuthor;
                if (string.IsNullOrEmpty(Settings.Default.DefaultAuthor))
                {
                    Settings.Default.DefaultAuthor = modConfiguration.ModAuthor;
                    Settings.Default.Save();
                }
                else if (Settings.Default.DefaultAuthor != modConfiguration.ModAuthor && System.Windows.MessageBox.Show("Author differs to the default author currently stored. Do you wish to set this author as the new default?", "Request change to Default Author", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Settings.Default.DefaultAuthor = modConfiguration.ModAuthor;
                    Settings.Default.Save();
                }
                _CurrentMod.FileName = saveFileDialog.FileName;
                PatchPayloadData patchPayloadDatum = new PatchPayloadData
                {
                    OutputPath = _CurrentMod.FileName,
                    Mod = _CurrentMod
                };
                _BGWorker.RunWorkerAsync(new WorkerState(WorkerStateType.WorkerState_SavePatch, patchPayloadDatum));
                ConstructWindowTitle();
            }
        }

        private void File_ImportCommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            if (_BGWorker.IsBusy)
            {
                WriteLogEntry("Unable to complete request. Currently there is another async task in progress. Please try again later");
                return;
            }
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Open Patch",
                Filter = "*.daimod|*.daimod|*.mft|*.mft"
            };
            if (openFileDialog.ShowDialog().Value)
            {
                _BGWorker.RunWorkerAsync(new WorkerState(WorkerStateType.WorkerState_ImportPatch, openFileDialog.FileName));
            }
        }

        private void File_ExitCommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Edit_TalktableEditorBinding_Executed(object sender, RoutedEventArgs e)
        {
            new TalktableEditor().Show();
        }

        private void Edit_SearchCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DAITreeViewItem selectedItem = AssetFolderTreeView.SelectedItem as DAITreeViewItem;
            AssetFolder userData = ((selectedItem == null) ? null : ((AssetFolder)selectedItem.UserData));
            _SearchDialog = new SearchWindow(userData);
            _SearchDialog.Show();
        }

        private void Edit_ModConfigCommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_CurrentMod.FileName))
            {
                System.Windows.MessageBox.Show("The current mod needs to be saved prior to launching the Advanced Mod Configuration dialog", "Warning");
                return;
            }
            AdvModConfiguration advModConfiguration = new AdvModConfiguration(_CurrentMod.FileName);
            advModConfiguration.ShowDialog();
            if (!advModConfiguration.Cancelled)
            {
                _CurrentMod = advModConfiguration.CurrentMod;
                ConstructWindowTitle();
            }
        }

        private void Tools_ExportAllEbxCommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            if (_BGWorker.IsBusy)
            {
                WriteLogEntry("Unable to complete request. Currently there is another async task in progress. Please try again later");
                return;
            }
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _BGWorker.RunWorkerAsync(new WorkerState(WorkerStateType.WorkerState_ExportAllEbx, folderBrowserDialog.SelectedPath));
            }
        }

        private void Tools_HashToolsCommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            new HashWindow().Show();
        }

        private void Tools_BundlePreviewCommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            new BundlePreview().Show();
        }

        private void Tools_ResourcePreview_CommandBinding_Executed(object sender, RoutedEventArgs e)
        {
            new ResourceListPreview().Show();
        }

        private void Support_ReportABug_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Support_RequestAFeature_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Tools_DeleteCache_Click(object sender, RoutedEventArgs e)
        {
            if (_BGWorker.IsBusy)
            {
                WriteLogEntry("Unable to complete request. Currently there is another async task in progress. Please try again later");
            }
            else if (System.Windows.Forms.MessageBox.Show("After deleting your cache, the ModMaker will close and will need to be launched again.\nPlease save your mod before doing so.\nIf you wish to go back and save your mod, press Cancel.\nIf you are ready, press Ok.", "Deleting cache", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK)
            {
                File.Delete("cache.dai");
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void Tools_ResetConfigs_Click(object sender, RoutedEventArgs e)
        {
            if (_BGWorker.IsBusy)
            {
                WriteLogEntry("Unable to complete request. Currently there is another async task in progress. Please try again later");
            }
            else if (System.Windows.Forms.MessageBox.Show("After resetting your configs, the ModMaker will close and will need to be launched again.\nPlease save your mod before doing so.\nIf you wish to go back and save your mod, press Cancel.\nIf you are ready, press Ok.", "Restoring configs", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.OK)
            {
                Settings.Default.Reset();
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void AssetFilterTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                FilterAssets();
            }
        }

        private void AssetFolderTreeView_ItemCollapsed(object sender, RoutedEventArgs e)
        {
            DAITreeViewItem originalSource = e.OriginalSource as DAITreeViewItem;
            AssetFolder userData = (AssetFolder)originalSource.UserData;
            originalSource.Items.Clear();
            if (userData.Children.Count > 0)
            {
                Style style = this.FindResource("FolderTreeViewItemStyle") as Style;
                TreeViewItem treeViewItem = new()
                {
                    Style = style
                };
                originalSource.Items.Add(treeViewItem);
            }
        }

        private void AssetFolderTreeView_ItemExpanded(object sender, RoutedEventArgs e)
        {
            DAITreeViewItem originalSource = e.OriginalSource as DAITreeViewItem;
            AssetFolder userData = (AssetFolder)originalSource.UserData;
            originalSource.Items.Clear();
            Style style = this.FindResource("FolderTreeViewItemStyle") as Style;

            for (int i = 0; i < userData.Children.Count; i++)
            {
                AssetFolder item = _AssetFolders[userData.Children[i]];
                DAITreeViewItem dAITreeViewItem = new DAITreeViewItem(item)
                {
                    Header = item.Name,
                    Style = style
                };
                if (item.Children.Count > 0)
                {
                    TreeViewItem treeViewItem = new()
                    {
                        Style = style
                    };
                    dAITreeViewItem.Items.Add(treeViewItem);
                }
                originalSource.Items.Add(dAITreeViewItem);
            }
            originalSource.Items.SortDescriptions.Add(new SortDescription("Header", ListSortDirection.Ascending));
        }

        private void AssetFolderTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            FilterAssets();
        }

        private void AssetListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EbxRefWrapper selectedItem = AssetListBox.SelectedItem as EbxRefWrapper;
            if (selectedItem != null)
            {
                DateTime start = DateTime.Now;
                new EbxPreviewWindow(EbxBase.FromEbx(selectedItem.Ebx)).Show();
                (DateTime.Now - start).ToDebugWindow("present EBX preview");
            }
        }

        private void AssetListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AssetListBox.SelectedItem == null)
            {
                Globals.SelectedAsset = null;
            }
            else
            {
                Globals.SelectedAsset = ((EbxRefWrapper)AssetListBox.SelectedItem).Ebx;
            }
        }

        private void cboAssetType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterAssets();
        }

        private void cboAssetSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterAssets();
        }

        private void chkShowChildren_Checked(object sender, RoutedEventArgs e)
        {
            FilterAssets();
        }

        private void chkShowChildren_Unchecked(object sender, RoutedEventArgs e)
        {
            FilterAssets();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            AssetFilterTextBox.Text = "";
            FilterAssets();
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            WorkerState argument = e.Argument as WorkerState;
            e.Result = argument.Type;
            switch (argument.Type)
            {
                case WorkerStateType.WorkerState_InitialImport:
                    if (DoInitialImport())
                    {
                        _BGWorker.ReportProgress(0, new LoadingProgressState(false, false, true, "", "Loading of cache and assets completed."));
                        _BGWorker.ReportProgress(0, new LoadingProgressState(false, false, true, "", "Loaded a total of " + Library.GetAllEbx().Count + " assets."));
                        UpdateUIFromAssetLibrary();
                    }
                    break;
                case WorkerStateType.WorkerState_ExportAllEbx:
                    DoExportAllEbx((string)argument.Payload);
                    break;
                case WorkerStateType.WorkerState_SavePatch:
                    DoSavePatch((PatchPayloadData)argument.Payload);
                    break;
                case WorkerStateType.WorkerState_OpenPatch:
                    DoOpenPatch((string)argument.Payload);
                    break;
                case WorkerStateType.WorkerState_ImportPatch:
                    DoOpenPatch((string)argument.Payload, true);
                    break;
                case WorkerStateType.WorkerState_NewPatch:
                    DoNewPatch();
                    break;
                case WorkerStateType.WorkerState_LoadMap:
                    break;
            }
        }

        private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LoadingProgressState userState = e.UserState as LoadingProgressState;
            if (userState.UpdateStatus)
            {
                StatusBarText.Text = userState.StatusText;
            }
            if (userState.UpdateProgress)
            {
                ProgressBarItem.Visibility = Visibility.Visible;
                SearchAssetsProgressBar.Value = e.ProgressPercentage;
                base.TaskbarItemInfo.ProgressValue = (double)e.ProgressPercentage / 100.0;
            }
            if (userState.UpdateLog)
            {
                WriteLogEntry(userState.LogText);
            }
        }

        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_MustExit)
            {
                System.Windows.Application.Current.Shutdown();
                return;
            }
            StatusBarText.Text = "Ready";
            ProgressBarItem.Visibility = Visibility.Hidden;
            base.TaskbarItemInfo.ProgressValue = 1.0;
            base.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
            if (e.Error != null)
            {
                new FrmException(e.Error).ShowDialog();
                WriteLogEntry("Task failed. Error reported was: " + e.Error.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new List<string>();
            if (string.IsNullOrEmpty(Settings.Default.BasePath))
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = "*.exe|*.exe",
                    Title = "Find Dragon Age: Inquisition executable"
                };
                if (!openFileDialog.ShowDialog().Value)
                {
                    Close();
                }
                else
                {
                    Settings.Default.BasePath = Path.GetDirectoryName(openFileDialog.FileName) + "\\";
                    Settings.Default.Save();
                }
            }
            _CurrentMod = new ModJob("NewMod", "", "");
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            int applicationVersionInt = version.Minor * 1000 + version.Build * 100 + version.Revision;
            Guid guid = Guid.NewGuid();
            _CurrentMod.Meta = new ModMetaData(1, applicationVersionInt, guid.ToString().ToUpper(), (byte)Library.PatchVersion, new ModDetail("NewMod", "v0.1", Settings.Default.DefaultAuthor, ""));
            _CurrentMod.FileName = string.Empty;
            ConstructWindowTitle();
            DAIModuleManager.LoadModules();
            base.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
            _BGWorker.RunWorkerAsync(new WorkerState(WorkerStateType.WorkerState_InitialImport, null));
        }

        private void EventManager_BeginTocParsing(LibraryEventManagerArgs e)
        {
            _BGWorker.ReportProgress((int)((double)_NbTocsParsed * 1.0 / (double)_NbTocsToParse * 100.0), new LoadingProgressState(true, true, true, "Parsing...", e.Message));
            _NbTocsParsed++;
        }

        private void EventManager_BeginLibraryInit(LibraryEventManagerArgs e)
        {
            _BGWorker.ReportProgress(0, new LoadingProgressState(true, false, true, "Initializing...", e.Message));
        }

        private void EventManager_BeginGameFolderParsing(LibraryEventManagerArgs e)
        {
            _NbTocsParsed = 0;
            _NbTocsToParse = (int)e.Parameter;
            _BGWorker.ReportProgress(0, new LoadingProgressState(true, true, true, "Initializing...", e.Message));
        }

        private void FilterAssets()
        {
            AssetListBox.Items.Clear();
            Globals.SelectedAsset = null;
            if (AssetFolderTreeView.SelectedItem == null)
            {
                lblNbResults.Content = "0 results";
                return;
            }
            StringBuilder sb = new StringBuilder();
            DAITreeViewItem selectedNode = AssetFolderTreeView.SelectedItem as DAITreeViewItem;
            for (DAITreeViewItem node = selectedNode; node != null; node = ((node.Parent is System.Windows.Controls.TreeView) ? null : ((DAITreeViewItem)node.Parent)))
            {
                if (sb.Length != 0)
                {
                    sb.Insert(0, "/");
                }
                sb.Insert(0, ((AssetFolder)node.UserData).Name);
            }
            bool includeChildren = chkShowChildren.IsChecked.HasValue && chkShowChildren.IsChecked.Value;
            IEnumerable<EbxRef> list = from ebx in Library.GetAllEbx()
                                       where (includeChildren || ((AssetFolder)selectedNode.UserData).Assets.Contains(ebx.FileGuid)) && (cboAssetType.SelectedIndex == 0 || ebx.AssetType.CompareTo(cboAssetType.SelectedItem.ToString()) == 0) && ("data/" + ebx.Name.ToLower()).StartsWith(sb.ToString().ToLower()) && ebx.Name.ToLower().Contains(AssetFilterTextBox.Text.ToLower().Replace("\\", "/"))
                                       select ebx;
            foreach (EbxRef ebx2 in list)
            {
                AssetListBox.Items.Add(new EbxRefWrapper(ebx2));
            }
            AssetListBox.Items.SortDescriptions.Clear();
            AssetListBox.Items.SortDescriptions.Add(new SortDescription((cboAssetSort.SelectedIndex == 0) ? "Name" : "AssetType", ListSortDirection.Ascending));
            lblNbResults.Content = list.Count() + " results";
        }

        private void ConstructAssetFolders(string Path, out string AssetPath, out string AssetName, bool bAddFolder = true)
        {
            string[] pathPieces = Path.Split('/');
            AssetName = pathPieces[pathPieces.Length - 1];
            string dataPath = "Data/";
            for (int i = 0; i < pathPieces.Length - 1; i++)
            {
                string parentPath = dataPath;
                dataPath = dataPath + pathPieces[i] + "/";
                if (bAddFolder && !_AssetFolders.ContainsKey(dataPath.GetHashCode()))
                {
                    AssetFolder assetFolder = new AssetFolder
                    {
                        Name = pathPieces[i],
                        Path = dataPath
                    };
                    _AssetFolders[parentPath.GetHashCode()].Children.Add(dataPath.GetHashCode());
                    _AssetFolders.Add(dataPath.GetHashCode(), assetFolder);
                }
            }
            AssetPath = dataPath;
        }

        private void ConstructWindowTitle()
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            base.Title = "DAI Mod Maker v" + version.ToString() + " alpha";
            if (_CurrentMod != null)
            {
                base.Title = base.Title + " (" + _CurrentMod.Meta.Details.Name + ")";
            }
        }

        private void DoExportAllEbx(string OutputPath)
        {
            _BGWorker.ReportProgress(0, new LoadingProgressState(true, true, true, "Exporting EBX...", "Began exporting all EBX to " + OutputPath));
            List<EbxRef> allEbx = Library.GetAllEbx();
            for (int i = 0; i < allEbx.Count; i++)
            {
                EbxRef ebxRef = allEbx[i];
                string path = ebxRef.Name.Replace("/", "\\");
                int index = path.LastIndexOf("\\");
                path = ((index != -1) ? path.Substring(0, index) : "");
                string ebxName = ebxRef.Name.Substring(path.Length);
                string ebxPath = OutputPath + "\\" + path;
                if (!Directory.Exists(ebxPath))
                {
                    Directory.CreateDirectory(ebxPath);
                }
                EbxBase dAIEbx = EbxBase.FromEbx(ebxRef);
                StreamWriter streamWriter = new StreamWriter(ebxPath + ebxName + ".yml");
                try
                {
                    streamWriter.Write(dAIEbx.ToXml(false));
                }
                catch
                {
                }
                finally
                {
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                BackgroundWorker bGWorker = _BGWorker;
                int count = (int)((float)i / (float)allEbx.Count * 100f);
                string[] strArrays = new string[5]
                {
                    "Exporting EBX (",
                    i.ToString(),
                    "/",
                    null,
                    null
                };
                strArrays[3] = allEbx.Count.ToString();
                strArrays[4] = ")";
                bGWorker.ReportProgress(count, new LoadingProgressState(true, true, false, string.Concat(strArrays), ""));
            }
            _BGWorker.ReportProgress(0, new LoadingProgressState(false, true, true, "", "Completed exporting EBX"));
        }

        private bool DoInitialImport()
        {
            System.Windows.Forms.MessageBox.Show("ATTENTION!\nThis version of the tool is still in alpha.  This means that this version still need some testing before being considered stable.\n\nAs we fix bugs, we will release new versions of the Mod Maker.  We urge you to use the Loader in order to keep the Mod Maker up to date.\n\nPlease, backup your mods and your saves!\n\nReport all bugs and suggestions to daimoddevteam@gmail.com.\n\nThank you for helping us in making this the best modding tool for DAI!", "Please read", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (System.Windows.Forms.MessageBox.Show("ATTENTION!\nBy using this software, you agree to the following:\n\nI will not make a mod that could give an advantage to players in Multiplayer.\nI will not profit from Bioware's asset in ANY way such as reselling them.\nI will not make a mod that allows paid content to be used without the end user owning it.  \n   (I.E. adding DLC content back in the main game to bypass the purhcase of said DLC.)\n\nThat's it!  That's the rules!  Happy modding!", "Please read", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.OK)
            {
                _MustExit = true;
                return false;
            }
            Library.Init(Settings.Default.BasePath);
            if (!LoadCache())
            {
                if (_MustExit)
                {
                    return false;
                }
                _BGWorker.ReportProgress(0, new LoadingProgressState(false, false, true, "", "Cache does not exist or out of date.  Loading assets."));
                Library.BuildLibrary();
                WriteCache();
            }
            _CurrentMod.Meta.MinPatchVersion = (byte)Library.PatchVersion;
            cboAssetSort.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate
            {
                cboAssetSort.Items.Add("Name");
                cboAssetSort.Items.Add("Type");
                cboAssetSort.SelectedIndex = 0;
                return null;
            }, null);
            cboAssetType.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate
            {
                cboAssetType.Items.Add("All");
                foreach (string current in Library.GetEbxTypes())
                {
                    cboAssetType.Items.Add(current);
                }
                cboAssetType.SelectedIndex = 0;
                return null;
            }, null);
            Task.Factory.StartNew(LoadMeshVariations);
            return true;
        }

        private bool LoadCache()
        {
            if (!File.Exists("cache.dai"))
            {
                return false;
            }
            try
            {
                _BGWorker.ReportProgress(0, new LoadingProgressState(true, false, true, "Reading cache...", "Cache found.  Reading cache..."));
                DateTime startDate = DateTime.Now;
                using (FileStream fs = new FileStream("cache.dai", FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader reader = new BinaryReader(fs))
                    {
                        int cacheVersion = reader.ReadInt32();
                        int patchVersion = reader.ReadInt32();
                        if (Library.PatchVersion == -1)
                        {
                            System.Windows.Forms.MessageBox.Show("It seems you have deleted the official patch folder.\nPlease restore the official patch folder and launch the ModMaker again.");
                            _MustExit = true;
                            _BGWorker.CancelAsync();
                            return false;
                        }
                        if (cacheVersion != Settings.Default.CacheVersion || patchVersion != Library.PatchVersion)
                        {
                            return false;
                        }
                        Library.Deserialize(reader);
                        Library.PatchVersion = patchVersion;
                    }
                }
                (DateTime.Now - startDate).ToDebugWindow("read cache and build library");
                return true;
            }
            catch (Exception)
            {
                _BGWorker.ReportProgress(0, new LoadingProgressState(false, false, true, "", "Cache loading failed."));
            }
            return false;
        }

        private void WriteCache()
        {
            try
            {
                DateTime startDate = DateTime.Now;
                using (FileStream fs = new FileStream("cache.dai", FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        writer.Write(Settings.Default.CacheVersion);
                        writer.Write(Library.PatchVersion);
                        Library.Serialize(writer);
                    }
                }
                (DateTime.Now - startDate).ToDebugWindow("write cache");
            }
            catch (Exception)
            {
            }
        }

        private void UpdateUIFromAssetLibrary()
        {
            foreach (EbxRef ebxAsset in Library.GetAllEbx())
            {
                ConstructAssetFolders(ebxAsset.Name, out var str, out var _);
                _AssetFolders[str.GetHashCode()].Assets.Add(ebxAsset.FileGuid);
                AssetFolderTreeView.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate
                {
                    Style style = this.FindResource("DefaultTreeViewItemStyle") as Style;
                    if (AssetFolderTreeView.Items.Count == 0)
                    {
                        AssetFolder assetFolder = _AssetFolders["Data/".GetHashCode()];
                        if (assetFolder.Children.Count != 0)
                        {
                            DAITreeViewItem dAITreeViewItem = new DAITreeViewItem(assetFolder)
                            {
                                Header = assetFolder.Name,
                                Style = style
                            };
                            if (assetFolder.Children.Count > 0)
                            {
                                TreeViewItem newItem = new()
                                {
                                    Style = style
                                };
                                dAITreeViewItem.Items.Add(newItem);
                            }
                            AssetFolderTreeView.Items.Add(dAITreeViewItem);
                        }
                    }
                    return null;
                }, null);
            }
        }

        private void DoNewPatch()
        {
            _BGWorker.ReportProgress(0, new LoadingProgressState(true, false, false, "New mod...", ""));
            LibraryManager.ClearModifiedData();
            for (int i = 0; i < _CurrentMod.Meta.Resources.Count; i++)
            {
                _CurrentMod.Data[_CurrentMod.Meta.Resources[i].ResourceID] = null;
            }
            _CurrentMod.Data.RemoveAll((byte[] A) => A == null);
            _CurrentMod.Meta.Bundles.Clear();
            _CurrentMod.Meta.Resources.Clear();
            _BGWorker.ReportProgress(0, new LoadingProgressState(false, true, true, "", "New mod constructed."));
        }

        private void DoOpenPatch(string PatchPath, bool bIsImport = false)
        {
            if (!bIsImport)
            {
                LibraryManager.ClearModifiedData();
            }
            _BGWorker.ReportProgress(0, new LoadingProgressState(true, false, true, "Loading mod...", "Loading mod from " + PatchPath));
            List<string> errors = null;
            ModJob job = ModParser.DoOpenPatch(PatchPath, bIsImport, out errors);
            errors = errors.Distinct().ToList();
            foreach (string error in errors)
            {
                _BGWorker.ReportProgress(0, new LoadingProgressState(false, false, true, "", "WARNING: " + error));
            }
            if (!bIsImport)
            {
                _CurrentMod = job;
            }
            for (int i = 0; i < _CurrentMod.Meta.Resources.Count; i++)
            {
                _CurrentMod.Data[_CurrentMod.Meta.Resources[i].ResourceID] = null;
            }
            _CurrentMod.Data.RemoveAll((byte[] A) => A == null);
            _CurrentMod.Meta.Bundles.Clear();
            _CurrentMod.Meta.Resources.Clear();
            _BGWorker.ReportProgress(0, new LoadingProgressState(false, false, true, "", ((errors.Count == 0) ? "Successfully loaded mod \"" : "Mod loaded with errors \"") + job.Meta.Details.Name + "\"."));
            if (!bIsImport)
            {
                base.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate
                {
                    ConstructWindowTitle();
                    return null;
                }, null);
            }
        }

        private void DoSavePatch(PatchPayloadData Payload)
        {
            _BGWorker.ReportProgress(0, new LoadingProgressState(true, false, true, "Saving mod...", "Saving mod to " + Payload.OutputPath));
            ModParser.DoSavePatch(Payload);
            _BGWorker.ReportProgress(0, new LoadingProgressState(false, false, true, "", "Mod successfully saved to " + Payload.OutputPath));
        }

        private void WriteLogEntry(string LogText)
        {
            System.Windows.Controls.TextBox logTextBox = LogTextBox;
            string text = logTextBox.Text;
            string[] shortDateString = new string[8] { text, "[", null, null, null, null, null, null };
            shortDateString[2] = DateTime.Now.ToShortDateString();
            shortDateString[3] = " ";
            shortDateString[4] = DateTime.Now.ToShortTimeString();
            shortDateString[5] = "] ";
            shortDateString[6] = LogText;
            shortDateString[7] = "\n";
            logTextBox.Text = string.Concat(shortDateString);
            LogTextBox.ScrollToEnd();
        }

        private static void LoadMeshVariations()
        {
            Globals.SetMeshVariationLoad(BuildVariations);
            Globals.MeshVariations.ContainsKey(1u);
        }

        private static Dictionary<uint, Dictionary<uint, MeshVariationDatabaseEntry>> BuildVariations()
        {
            DateTime start = DateTime.Now;
            Dictionary<uint, Dictionary<uint, MeshVariationDatabaseEntry>> meshVariations = new Dictionary<uint, Dictionary<uint, MeshVariationDatabaseEntry>>();
            foreach (EbxRef ebx in (from x in Library.GetAllEbx()
                                    where x.Name.ToLower().Contains("meshvariation")
                                    select x).ToList())
            {
                try
                {
                    EbxBase daiEbx = EbxBase.FromEbx(ebx);
                    if (daiEbx == null)
                    {
                        continue;
                    }
                    foreach (ComplexObject value in daiEbx.Instances.Values)
                    {
                        EbxField entriesField = value.Fields.Find((EbxField x) => x.Descriptor.FieldName == "Entries");
                        if (entriesField == null)
                        {
                            continue;
                        }
                        foreach (EbxField entryField in entriesField.ComplexValue.Fields)
                        {
                            EbxField ebxField = entryField.ComplexValue.Fields.Find((EbxField x) => x.Descriptor.FieldName == "Mesh");
                            uint nameHash = (uint)entryField.ComplexValue.Fields.Find((EbxField x) => x.Descriptor.FieldName == "VariationAssetNameHash").Value;
                            EbxRef meshEbx = Library.GetEbxByGuid(ebxField.GetValueAsGuid().FileGuid);
                            if (meshEbx != null)
                            {
                                if (!meshVariations.ContainsKey(meshEbx.NameHash))
                                {
                                    meshVariations.Add(meshEbx.NameHash, new Dictionary<uint, MeshVariationDatabaseEntry>());
                                }
                                if (!meshVariations[meshEbx.NameHash].ContainsKey(nameHash))
                                {
                                    MeshVariationDatabaseEntry entry = (MeshVariationDatabaseEntry)FrostbiteAssetFactory.CreateObject("MeshVariationDatabaseEntry", new AssetContainer(), entryField.ComplexValue);
                                    meshVariations[meshEbx.NameHash].Add(nameHash, entry);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            (DateTime.Now - start).ToDebugWindow("parse mesh variations");
            return meshVariations;
        }

        private void InitTemplates()
        {
            if (!Directory.Exists("Templates"))
            {
                Directory.CreateDirectory("Templates");
            }
            if (File.Exists("Templates\\BlankTemplate.cs"))
            {
                return;
            }
            using (Stream input = Assembly.GetExecutingAssembly().GetManifestResourceStream("DAI.ModMaker.Resources.BlankTemplate.cs"))
            {
                using (Stream output = File.Create("Templates\\BlankTemplate.cs"))
                {
                    byte[] buffer = new byte[8192];
                    int bytesRead;
                    while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
