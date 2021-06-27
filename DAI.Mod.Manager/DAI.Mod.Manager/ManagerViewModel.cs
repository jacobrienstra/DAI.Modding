using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Shell;
using System.Windows.Threading;

using DAI.Utilities;
using DAI.Mod.Manager.Frostbite;
using DAI.Mod.Manager.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;
using DAI.AssetLibrary.Utilities;
using System.Windows.Forms;

namespace DAI.Mod.Manager
{
    public class ManagerViewModel : NotificationObject
    {
        private readonly BackgroundWorker _bgWorker;

        private bool _cancelled;
        public bool Cancelled
        {
            get => _cancelled;
            set
            {
                SetProperty(ref _cancelled, value);
            }
        }

        public ProgressWindow ProgressWin { get; private set; }

        private BindingList<ModContainer> _userModList;
        public BindingList<ModContainer> UserModList
        {
            get => _userModList;
            set
            {
                _userModList = value;
                //SetProperty(ref _userModList, value);
            }
        }

        private ModContainer _patchMod;
        public ModContainer PatchMod
        {
            get => _patchMod;
            set
            {
                SetProperty(ref _patchMod, value);
            }
        }

        public List<ModContainer> AllModsList
        {
            get
            {
                List<ModContainer> list = UserModList.ToList();
                list.Insert(0, PatchMod);
                return list;
            }
            internal set { }
        }
        private void ManagerViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UserModList) || e.PropertyName == nameof(PatchMod))
            {
                OnPropertyChanged(nameof(AllModsList));
            }
        }
        private void AddUserMod(ModContainer userMod)
        {
            UserModList.Add(userMod);
            userMod.Index = UserModList.IndexOf(userMod);
            OnPropertyChanged(nameof(UserModList));
        }
        private void UpdateUserModIndicesAfter(int index)
        {
            for (int i = index; i < UserModList.Count; i++)
            {
                UserModList[i].Index = i;
            }
            OnPropertyChanged(nameof(UserModList));
        }
        private void RemoveUserMod(ModContainer userMod)
        {
            int modIndex = UserModList.IndexOf(userMod);
            UserModList.RemoveAt(modIndex);
            UpdateUserModIndicesAfter(modIndex);
        }
        private void InsertUserMod(int index, ModContainer userMod)
        {
            UserModList.Insert(index, userMod);
            UpdateUserModIndicesAfter(index);
        }
        private void ClearUserMods()
        {
            UserModList.Clear();
            OnPropertyChanged(nameof(UserModList));
        }

        private ModContainer _selectedMod;
        public ModContainer SelectedMod
        {
            get => _selectedMod;
            set
            {
                SetProperty(ref _selectedMod, value);
            }
        }

        private bool _modManagerGridEnabled;
        public bool ModManagerGridEnabled
        {
            get => _modManagerGridEnabled;
            set
            {
                SetProperty(ref _modManagerGridEnabled, value);
            }
        }

        private bool _mergeReady;
        public bool MergeReady
        {
            get => _mergeReady;
            set
            {
                SetProperty(ref _mergeReady, value);
            }
        }

        public string ModPath
        {
            get => Settings.ModPath;
            set
            {
                Settings.ModPath = value;
                Settings.Save();
                OnPropertyChanged(nameof(ModPath));
            }
        }
        public string DAIPath
        {
            get => Settings.BasePath;
            set
            {
                Settings.BasePath = value;
                Settings.Save();
                OnPropertyChanged(nameof(DAIPath));
            }
        }

        private bool _mergeDesitnation;
        public bool MergeDestination
        {
            get => _mergeDesitnation;
            set
            {
                SetProperty(ref _mergeDesitnation, value);
            }
        }

        public bool VerboseScan
        {
            get => Settings.VerboseScan;
            set
            {
                Settings.VerboseScan = value;
                Settings.Save();
                OnPropertyChanged(nameof(VerboseScan));
            }
        }
        public bool ForceRescan
        {
            get => Settings.RescanPatch;
            set
            {
                Settings.RescanPatch = value;
                Settings.Save();
                OnPropertyChanged(nameof(ForceRescan));
            }
        }

        public ManagerViewModel()
        {
            Cancelled = true;
            ModManagerGridEnabled = false;
            MergeReady = false;
            UserModList = new BindingList<ModContainer>();
            PatchMod = null;
            MergeDestination = false;
            PropertyChanged += ManagerViewModel_PropertyChanged;
            _bgWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _bgWorker.DoWork += BGWorker_DoWork;
            _bgWorker.RunWorkerCompleted += BGWorker_RunWorkerCompleted;
            _bgWorker.ProgressChanged += BGWorker_ProgressChanged;
        }

        public void SwitchSelectedModStatus()
        {
            ModContainer selectedMod = SelectedMod;
            if (selectedMod != null)
            {
                if (!selectedMod.IsOfficialPatch && Settings.PatchVersion >= selectedMod.MinPatchVersion)
                {
                    selectedMod.IsEnabled = !selectedMod.IsEnabled;
                    //OnPropertyChanged(nameof(SelectedMod));// TODO check if works for this nested field
                }
            }
        }

        public void MergeMods()
        {
            Cancelled = false;
            if (Cancelled)
            {
                return;
            }
            List<ModContainer> modList = (from ModContainer modContainer in UserModList
                                          where modContainer.IsEnabled
                                          select modContainer).ToList();
            string newPath;
            if (MergeDestination)
            {
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Title = "Save merged patch",
                    FileName = "package.mft",
                    Filter = "package.mft|*.mft"
                };
                if (!saveFileDialog.ShowDialog().Value)
                {
                    return;
                }
                newPath = saveFileDialog.FileName.Remove(saveFileDialog.FileName.LastIndexOf('\\') + 1).ToLower();
            }
            else
            {
                newPath = DAIPath + "Update\\Patch_ModManagerMerge\\";
            }
            if (newPath == DAIPath.ToLower() ||
                newPath == DAIPath.ToLower() + "update\\" ||
                newPath == DAIPath.ToLower() + "Update\\Patch\\")
            {
                System.Windows.MessageBox.Show("You tried to save the merged patch to an invalid location. Please read usage instructions carefully and try again.", "Error");
                return;
            }
            ProgressWin = new ProgressWindow();
            Scripting.ScriptingTextBox = ProgressWin.StatusTextBox;
            ProgressWin.Show();
            //TODO: pass in cancellation token
            _bgWorker.RunWorkerAsync(new WorkerState(WorkerStateType.WorkerState_SavePatch, new PatchPayloadData
            {
                CreateDistPatch = false,
                IncludeProjectData = false,
                OutputPath = newPath,
                ModList = modList
            }));
        }

        public void LoadMods()
        {
            ClearUserMods();
            ModManagerGridEnabled = false;
            MergeReady = false;
            // Initialize Check
            if (!File.Exists(DAIPath + "DragonAgeInquisition.exe"))
            {
                MessageBox.Show("Dragon Age path has not been setup correctly. Please click on Browse and locate.", "Warning");
                return;
            }
            if (Settings.PatchVersion == -1)
            {
                MessageBox.Show("You *MUST* have a version of the Official Patch to be able to use mods.", "Error");
                return;
            }
            if (!CheckBasePatch())
            {
                MessageBox.Show("The official patch folder contains a merged mod manager patch. Please restore the official patch to the correct location, or use 'Repair Game' in Origin to correct it.");
                return;
            }
            ModManagerGridEnabled = true;
            if (ModPath == "")
            {
                return;
            }

            // Add official Patch
            PatchMod = new ModContainer(DAIPath + "Update\\Patch\\", "Official Patch", "Bioware", "", "")
            {
                IsOfficialPatch = true,
                Version = Settings.PatchVersion.ToString()
            };

            // Add mft user mods
            foreach (string item in Directory.EnumerateDirectories(ModPath))
            {
                if (File.Exists(item + "\\package.mft"))
                {
                    DAIMft dAIMft = DAIMft.SerializeFromFile(item + "\\package.mft");
                    if (dAIMft.HasKey("ModTitle"))
                    {
                        AddUserMod(new ModContainer(item, dAIMft.GetValue("ModTitle"), dAIMft.GetValue("ModAuthor"), dAIMft.GetValue("ModVersion"), dAIMft.GetValue("ModDescription")));
                    }
                }
            }

            // Add daimod user mods
            string[] files = Directory.GetFiles(ModPath, "*.daimod", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                ModJob modJob = ModJob.CreateFromFile(file);
                AddUserMod(new ModContainer(file, modJob.Meta.Details.Name, modJob.Meta.Details.Author, modJob.Meta.Details.Version, modJob.Meta.Details.Description, modJob.Meta.MinPatchVersion)
                {
                    Mod = modJob,
                });
                // setup UI, set configvalues
                if (modJob.ScriptObject != null)
                {
                    ModConfigElementsList modConfigElementsList = new ModConfigElementsList();
                    modJob.ScriptObject.ConstructUI(modConfigElementsList);
                    modJob.ConfigValues = new Dictionary<string, object>();
                    foreach (ModConfigElement uIElement in modConfigElementsList.UIElements)
                    {
                        modJob.ConfigValues.Add(uIElement.ParameterName, uIElement.ParameterDefaultValue);
                    }
                }
                // version check
                if (modJob.Meta.ToolSetVersion >= 1000 && modJob.Meta.ToolSetVersion < 1016)
                {
                    System.Windows.MessageBox.Show("Warning: Mod " + modJob.Meta.Details.Name + " was created with an unstable toolset version and may not function correctly");
                }
            }
            MergeReady = true;
        }

        private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LoadingProgressState loadingProgressState = e.UserState as LoadingProgressState;
            if (loadingProgressState.UpdateStatus)
            {
                ProgressWin.StatusTextBlock.Text = loadingProgressState.StatusText;
            }
            if (loadingProgressState.UpdateProgress)
            {
                ProgressWin.StatusProgressBar.Visibility = System.Windows.Visibility.Visible;
                ProgressWin.StatusProgressBar.Value = e.ProgressPercentage;
                ProgressWin.TaskbarItemInfo.ProgressValue = e.ProgressPercentage / 100.0;
                ProgressWin.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
            }
            if (loadingProgressState.UpdateLog)
            {
                WriteLogEntry(loadingProgressState.LogText);
            }
        }

        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("Task failed. Error reported was: ");
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine($"Exception message:      {e.Error.Message}");
                stringBuilder.AppendLine($"Source:                 {e.Error.Source}");
                stringBuilder.AppendLine($"Target:                 {e.Error.TargetSite.ToString()}");
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine("StrackTrace:");
                stringBuilder.AppendLine(e.Error.StackTrace);
                WriteLogEntry(stringBuilder.ToString());
                ProgressWin.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Error;
            }
            else
            {
                WriteLogEntry("Task completed sucessfully");
                ProgressWin.StatusProgressBar.Value = 0.0;
                ProgressWin.StatusTextBlock.Text = "";
                ProgressWin.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Indeterminate;
            }
            ProgressWin.CloseWindowButton.IsEnabled = true;
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            PatchPayloadData patchPayloadData = (PatchPayloadData)((WorkerState)e.Argument).Payload;
            string patchPayloadDir = Path.GetDirectoryName(patchPayloadData.OutputPath);
            ModJob basePatchModJob = GetBasePatchModJob();
            //patchPayloadData.ModList.RemoveAt(0);

            List<ModJob> modJobList = ProcessModList(patchPayloadData).ToList();
            Dictionary<Sha1, byte[]> moddedResToData = new Dictionary<Sha1, byte[]>();
            Dictionary<int, List<ModResourceEntry>> moddedBundleToEntries = new Dictionary<int, List<ModResourceEntry>>();
            List<int> bundlesToRemove = new List<int>();

            // get modified or deleted bundles from base patch
            foreach (ModBundle bundle in basePatchModJob.Meta.Bundles)
            {
                if (bundle.Action == "modify")
                {
                    int bundleKey = Utils.Hasher(bundle.Name.ToLower());
                    // get all bundle entries
                    List<ModResourceEntry> bundleEntries = bundle.Entries.Select((ModBundleEntry modBundleEntry) => basePatchModJob.Meta.Resources[modBundleEntry.ResourceId]).ToList();
                    bundleEntries.Sort(
                        (ModResourceEntry A, ModResourceEntry B) =>
                        {
                            if (A is ChunkModResourceEntry a && B is ChunkModResourceEntry b)
                            {
                                return a.ChunkH32.CompareTo(b.ChunkH32);
                            }
                            else if (A is ChunkModResourceEntry)
                            {
                                return 1;
                            }
                            else if (B is ChunkModResourceEntry)
                            {
                                return -1;
                            }
                            return 0;
                        });
                    moddedBundleToEntries.Add(bundleKey, bundleEntries);
                }
                else if (bundle.Action == "remove")
                {
                    bundlesToRemove.Add(Utils.Hasher(bundle.Name.ToLower()));
                }
            }
            // process user mods
            foreach (ModJob modJob in modJobList)
            {
                // add modified resources from user mod
                foreach (ModResourceEntry resource in modJob.Meta.Resources.Where((ModResourceEntry mre) => mre.ResourceID != -1 && mre.IsEnabled && mre.Action != "remove"))
                {
                    moddedResToData[resource.OriginalSha1] = modJob.Data[resource.ResourceID];
                }
                // add modified bundles from user mod
                foreach (ModBundle mjBundle in modJob.Meta.Bundles)
                {
                    int mjBundleKey = Utils.Hasher(mjBundle.Name);
                    // if newly mentioned bundle, get enabled resources and then move on to next
                    if (!moddedBundleToEntries.ContainsKey(mjBundleKey))
                    {
                        moddedBundleToEntries.Add(mjBundleKey, (from entry in mjBundle.Entries
                                                                where modJob.Meta.Resources[entry.ResourceId].IsEnabled
                                                                select entry into ent
                                                                select modJob.Meta.Resources[ent.ResourceId]).ToList());
                        continue;
                    }
                    // else, we already have bundle, so process its entries
                    foreach (ModBundleEntry entry in mjBundle.Entries)
                    {
                        ModResourceEntry modResourceEntry = modJob.Meta.Resources[entry.ResourceId];
                        if (!modResourceEntry.IsEnabled)
                        {
                            continue;
                        }
                        int Hash = Utils.Hasher(modResourceEntry.Name + "_" + modResourceEntry.Action);
                        // check if we already have this resource-action for this bundle, and warn if so
                        int index = moddedBundleToEntries[mjBundleKey].FindIndex((ModResourceEntry A) => Utils.Hasher(A.Name + "_" + A.Action) == Hash);
                        if (index != -1)
                        {
                            ModJob prevModJob = ModJobForResource(modJobList, moddedBundleToEntries[mjBundleKey][index]);
                            if (prevModJob != null)
                            {
                                WriteLogEntry_Threaded("*** Warning: " + modResourceEntry.Name + " from mod " + prevModJob.Name + " overridden by " + modJob.Name);
                            }
                            // reset to new version
                            moddedBundleToEntries[mjBundleKey][index] = modResourceEntry;
                        }
                        else
                        {
                            // or add modified version
                            moddedBundleToEntries[mjBundleKey].Add(modResourceEntry);
                        }
                    }
                }
            }
            string basePatchDataPath = Settings.BasePath + "Update\\Patch\\Data\\";
            PrepareDirectory(patchPayloadDir, basePatchModJob, moddedResToData, basePatchDataPath, out var layoutToc);
            int progress = 0;
            _bgWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Creating merged patch."));
            string win32PatchPath = basePatchDataPath + "Win32\\";
            DAIToc chunks0Toc;
            // Toc = Table of Contents
            if (File.Exists(win32PatchPath + "chunks0.toc"))
            {
                chunks0Toc = DAIToc.ReadFromFile(win32PatchPath + "chunks0.toc", 0L);
                if (!Directory.Exists(patchPayloadDir + "\\Data\\Win32"))
                {
                    Directory.CreateDirectory(patchPayloadDir + "\\Data\\Win32");
                }
                File.Copy(win32PatchPath + "chunks0.sb", patchPayloadDir + "\\Data\\Win32\\chunks0.sb");
            }
            else
            {
                // else create new chunks0 file(s) I guess
                chunks0Toc = new DAIToc();
                DAIEntry chunks0TocRootEntry = new DAIEntry();
                chunks0TocRootEntry.AddListValue("bundles", new List<DAIEntry>());
                chunks0TocRootEntry.AddListValue("chunks", new List<DAIEntry>());
                chunks0TocRootEntry.AddBoolValue("cas", Value: true);
                chunks0Toc.SetRootEntry(chunks0TocRootEntry);
                DAIToc emptyChunks0Toc = new DAIToc();
                DAIEntry emptyChunks0TocRootEntry = new DAIEntry();
                emptyChunks0TocRootEntry.AddListValue("bundles", new List<DAIEntry>());
                emptyChunks0Toc.SetRootEntry(emptyChunks0TocRootEntry);
                emptyChunks0Toc.WriteToFile(patchPayloadDir + "\\Data\\Win32\\chunks0.sb");
            }
            // list added toc files from base patch
            // toc files contain many bundles, bundles can be referenced by multiple tocs as well i think
            List<string> NewTocFileNames = new List<string>();
            basePatchModJob.Meta.Bundles.ForEach(delegate (ModBundle A)
            {
                if (!NewTocFileNames.Contains(A.TocFilename) && !(A.Action != "add") && !File.Exists(Settings.BasePath + "\\Data\\Win32\\" + A.TocFilename))
                {
                    NewTocFileNames.Add(A.TocFilename);
                }
            });
            // process new TocFiles
            foreach (string newTocFileName in NewTocFileNames)
            {
                int newFileNameHash = Utils.Hasher(newTocFileName.ToLower());
                List<ModBundle> bundlesInNewToc = basePatchModJob.Meta.Bundles.FindAll((ModBundle A) => A.TocFilename != null && Utils.Hasher(A.TocFilename.ToLower()) == newFileNameHash);
                DAIEntry newTocMetaBundles = new DAIEntry();
                newTocMetaBundles.AddListValue("bundles", new List<DAIEntry>());
                DAIEntry newTocContentBundles = new DAIEntry();
                newTocContentBundles.AddListValue("bundles", new List<DAIEntry>());
                // process bundles in newToc
                foreach (ModBundle bundleInNewToc in bundlesInNewToc)
                {
                    DAIEntry contentBundle = new DAIEntry();
                    contentBundle.AddStringValue("path", bundleInNewToc.Name);
                    contentBundle.AddDWordValue("magicSalt", (uint)bundleInNewToc.MagicSalt);
                    contentBundle.AddListValue("ebx", new List<DAIEntry>());
                    contentBundle.AddListValue("res", new List<DAIEntry>());
                    contentBundle.AddBoolValue("alignMembers", bundleInNewToc.AlignMembers == 1);
                    contentBundle.AddBoolValue("ridSupport", bundleInNewToc.RidSupport == 1);
                    contentBundle.AddBoolValue("storeCompressedSizes", bundleInNewToc.StoreCompressedSizes == 1);
                    contentBundle.AddQWordValue("totalSize", 0L);
                    contentBundle.AddQWordValue("dbxTotalSize", 0L);
                    DAIEntry metaBundle = new DAIEntry();
                    metaBundle.AddStringValue("id", bundleInNewToc.Name);
                    metaBundle.AddQWordValue("offset", 0L);
                    metaBundle.AddDWordValue("size", 0u);
                    newTocContentBundles.GetListValue("bundles").Add(contentBundle);
                    newTocMetaBundles.GetListValue("bundles").Add(metaBundle);
                    // add each resource entry as a daientry to bundle
                    foreach (ModBundleEntry bundleInNewTocEntry in bundleInNewToc.Entries)
                    {
                        ModResourceEntry modResourceEntry2 = basePatchModJob.Meta.Resources[bundleInNewTocEntry.ResourceId];
                        ModResourceEntryExt.BuildDAIEntry(contentBundle, modResourceEntry2);
                    }
                    // if we don't have  bundle, move on to next bundle
                    int bundleInNewTocKey = Utils.Hasher(metaBundle.GetStringValue("id").ToLower());
                    if (!moddedBundleToEntries.ContainsKey(bundleInNewTocKey))
                    {
                        continue;
                    }
                    // else process existing entries
                    foreach (ModResourceEntry moddedBundleEntry in moddedBundleToEntries[bundleInNewTocKey])
                    {
                        ModResourceEntry mbe = moddedBundleEntry;
                        if (!(mbe.Action == "modify"))
                        {
                            continue;
                        }
                        // tbh idk what's going on with the original/newsha1 stuff
                        DAIEntry prevDaiEntry = contentBundle.GetListValue(mbe.Type).Find((DAIEntry A) => A.GetSha1Value("sha1") == mbe.OriginalSha1);
                        if (prevDaiEntry != null)
                        {
                            // update prevDAIEntry, if exists
                            ModResourceEntryExt.ModifyResourceEntry(mbe, prevDaiEntry);
                            continue;
                        }
                        // DAIEntry isn't in content bundle
                        // so if it IS referenced by a modjob, how did we get here without it
                        ModJob prevModJob = ModJobForResource(modJobList, moddedBundleEntry);
                        if (prevModJob != null)
                        {
                            WriteLogEntry_Threaded("*** Warning: " + moddedBundleEntry.Name + " not found for " + prevModJob.Name);
                        }
                    }
                }
                // set up toc i think
                newTocMetaBundles.AddListValue("chunks", new List<DAIEntry>());
                newTocMetaBundles.AddBoolValue("cas", Value: true);
                newTocMetaBundles.AddStringValue("name", "Win32/" + newTocFileName.Replace(".toc", ""));
                newTocMetaBundles.AddBoolValue("alwaysEmitSuperbundle", Value: true);
                DAIToc newTocContentBundlesToc = new DAIToc();
                newTocContentBundlesToc.SetRootEntry(newTocContentBundles);
                newTocContentBundlesToc.WriteToFile(patchPayloadDir + "\\Data\\Win32\\" + newTocFileName.Replace(".toc", ".sb"));
                DAIToc newTocMetaBundlesToc = new DAIToc();
                newTocMetaBundlesToc.SetRootEntry(newTocMetaBundles);
                // set offsets and size for each meta bundle
                for (int i = 0; i < newTocMetaBundles.GetListValue("bundles").Count; i++)
                {
                    DAIEntry newTocMetaBundle = newTocMetaBundles.GetListValue("bundles")[i];
                    DAIEntry newTocContentBundle = newTocContentBundles.GetListValue("bundles")[i];
                    newTocMetaBundle.SetQWordValue("offset", newTocContentBundle.EntryOffset);
                    newTocMetaBundle.SetDWordValue("size", (uint)newTocContentBundle.GetSize());
                }
                newTocMetaBundlesToc.WriteToFile(patchPayloadDir + "\\Data\\Win32\\" + newTocFileName, bWriteTocHeader: true);
            }
            // get all the existing toc files in main game data
            List<string> tocFiles = new List<string>();
            string text3 = Settings.BasePath + "Data\\Win32";
            tocFiles.AddRange(Directory.GetFiles(text3, "*.toc", SearchOption.AllDirectories));

            // merge each existing toc with modified ones
            foreach (string tocFilename in tocFiles)
            {
                if (Settings.VerboseScan)
                {
                    WriteLogEntry_Threaded("[0] Merging " + tocFilename);
                }
                Dictionary<DAIEntry, DAIEntry> bundleToChangedValue = new Dictionary<DAIEntry, DAIEntry>();

                _bgWorker.ReportProgress((int)((double)progress / (double)tocFiles.Count * 100.0), new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: false, tocFilename.Replace(text3 + "\\", ""), ""));

                DAIToc tocFile = DAIToc.ReadFromFile(tocFilename, 0L);
                bool flag = false;
                using (LazyDisposable<BinaryReader> lazyDisposable = new LazyDisposable<BinaryReader>(() => new BinaryReader(FileHelpers.UnXorFile(tocFilename.Replace(".toc", ".sb")))))
                {
                    // foreach toc bundle
                    foreach (DAIEntry tocFileBundle in tocFile.GetBundles())
                    {
                        tocFileBundle.AddBoolValue("base", Value: true);
                        DAIEntry value = null;
                        int tocFileBundleKey = Utils.Hasher(tocFileBundle.GetStringValue("id").ToLower());
                        if (bundlesToRemove.Contains(tocFileBundleKey))
                        {
                            flag = true;
                            continue;
                        }
                        if (moddedBundleToEntries.ContainsKey(tocFileBundleKey))
                        {
                            tocFileBundle.RemoveField("base");
                            tocFileBundle.AddBoolValue("delta", Value: true);
                            value = DAIToc.ReadFromStream(lazyDisposable.Value, tocFileBundle.GetQWordValue("offset")).GetRootEntry();
                            flag = true;
                        }
                        bundleToChangedValue.Add(tocFileBundle, value);
                    }
                }
                string shortFilename = tocFilename.Replace(Settings.BasePath + "Data\\Win32\\", "");
                // set up added bundles
                foreach (ModBundle addedBundle in basePatchModJob.Meta.Bundles.FindAll((ModBundle A) => A.Action == "add" && A.TocFilename.ToLower() == shortFilename.ToLower()))
                {
                    if (Settings.VerboseScan)
                    {
                        WriteLogEntry_Threaded("[1] Adding bundle " + addedBundle.Name);
                    }

                    DAIEntry addedBundleContent = new DAIEntry();
                    addedBundleContent.AddStringValue("path", addedBundle.Name.ToLower());
                    addedBundleContent.AddDWordValue("magicSalt", (uint)addedBundle.MagicSalt);
                    addedBundleContent.AddListValue("ebx", new List<DAIEntry>());
                    addedBundleContent.AddListValue("res", new List<DAIEntry>());

                    DAIEntry addedBundleMeta = new DAIEntry();
                    addedBundleMeta.AddStringValue("id", addedBundle.Name.ToLower());
                    addedBundleMeta.AddQWordValue("offset", 0L);
                    addedBundleMeta.AddDWordValue("size", 0u);
                    addedBundleMeta.AddBoolValue("delta", Value: true);

                    bundleToChangedValue.Add(addedBundleMeta, addedBundleContent);

                    foreach (ModBundleEntry addedBundleEntry in addedBundle.Entries)
                    {
                        ModResourceEntry modResourceEntry3 = basePatchModJob.Meta.Resources[addedBundleEntry.ResourceId];
                        ModResourceEntryExt.BuildDAIEntry(addedBundleContent, modResourceEntry3);
                        flag = true;
                    }
                    addedBundleContent.AddBoolValue("alignMembers", addedBundle.AlignMembers == 1);
                    addedBundleContent.AddBoolValue("ridSupport", addedBundle.RidSupport == 1);
                    addedBundleContent.AddBoolValue("storeCompressedSizes", addedBundle.StoreCompressedSizes == 1);
                    addedBundleContent.AddQWordValue("totalSize", 0L);
                    addedBundleContent.AddQWordValue("dbxTotalSize", 0L);
                }
                // setup changed entries
                foreach (DAIEntry changedEntry in bundleToChangedValue.Values)
                {
                    if (changedEntry == null)
                    {
                        continue;
                    }
                    if (Settings.VerboseScan)
                    {
                        WriteLogEntry_Threaded("[1] Merging " + changedEntry.GetStringValue("path"));
                    }

                    int changedEntryKey = Utils.Hasher(changedEntry.GetStringValue("path").ToLower());
                    if (!moddedBundleToEntries.ContainsKey(changedEntryKey))
                    {
                        continue;
                    }
                    foreach (ModResourceEntry moddedBundleChangedEntry in moddedBundleToEntries[changedEntryKey])
                    {
                        ModResourceEntry resEntry = moddedBundleChangedEntry;
                        if (resEntry.Action == "modify")
                        {
                            DAIEntry currentResEntry = changedEntry.GetListValue(resEntry.Type).Find((DAIEntry A) => A.GetSha1Value("sha1") == resEntry.OriginalSha1);
                            if (currentResEntry != null) // probably should happen most of the time i suppose
                            {
                                // change current entry
                                ModResourceEntryExt.ModifyResourceEntry(moddedBundleChangedEntry, currentResEntry);
                                continue;
                            }
                            // no existing res entry, in which case, we shouldn't have a mod job referencing it
                            ModJob prevModJob = ModJobForResource(modJobList, moddedBundleChangedEntry);
                            if (prevModJob != null)
                            {
                                WriteLogEntry_Threaded("*** Warning: " + moddedBundleChangedEntry.Name + " not found for " + prevModJob.Name);
                            }
                        }
                        else if (resEntry.Action == "remove")
                        {
                            string mreType = (resEntry.Type == "chunk") ? "chunks" : resEntry.Type;
                            int index = changedEntry.GetListValue(mreType).FindIndex((DAIEntry A) => A.GetSha1Value("sha1") == resEntry.OriginalSha1);
                            if (index != -1)
                            {
                                changedEntry.GetListValue(mreType).RemoveAt(index);
                                if (mreType == "chunks")
                                {
                                    changedEntry.GetListValue("chunkMeta").RemoveAt(index);
                                }
                            }
                        }
                        else
                        {
                            ModResourceEntryExt.BuildDAIEntry(changedEntry, resEntry);
                        }
                    }
                }
                int tocCount;
                // take care of removed bundles
                if (flag)
                {
                    foreach (KeyValuePair<DAIEntry, DAIEntry> entryMapPair in bundleToChangedValue)
                    {
                        DAIEntry changedValue = entryMapPair.Value;
                        DAIEntry keyBundle = entryMapPair.Key;
                        if (changedValue != null)
                        {
                            changedValue.GetListValue("ebx").Sort((DAIEntry A, DAIEntry B) => A.GetStringValue("name").CompareTo(B.GetStringValue("name")));
                            changedValue.GetListValue("res").Sort((DAIEntry A, DAIEntry B) => A.GetStringValue("name").CompareTo(B.GetStringValue("name")));
                            foreach (DAIEntry ebx in changedValue.GetListValue("ebx"))
                            {
                                if (ebx.HasField("idata"))
                                {
                                    ebx.RemoveField("idata");
                                }
                            }
                            foreach (DAIEntry res in changedValue.GetListValue("res"))
                            {
                                if (res.HasField("idata"))
                                {
                                    res.RemoveField("idata");
                                }
                            }
                            if (changedValue.HasField("chunks"))
                            {
                                foreach (DAIEntry chunk in changedValue.GetListValue("chunks"))
                                {
                                    if (chunk.HasField("idata"))
                                    {
                                        chunk.RemoveField("idata");
                                    }
                                }
                            }
                            if (changedValue.HasField("chunkMeta"))
                            {
                                foreach (DAIEntry chunkMeta in from A in changedValue.GetListValue("chunkMeta")
                                                               where A.GetDWordValue("h32") == -1
                                                               select A)
                                {
                                    changedValue.GetListValue("chunkMeta").Remove(chunkMeta);
                                }
                            }
                            if (changedValue.HasField("dbx"))
                            {
                                changedValue.RemoveField("dbx");
                            }
                            changedValue.SetStringValue("path", changedValue.GetStringValue("path").ToLower());
                        }
                        keyBundle.SetStringValue("id", keyBundle.GetStringValue("id").ToLower());
                    }
                    string tocPatchFilename = tocFilename.Replace(Settings.BasePath, patchPayloadDir + "\\");
                    string filename = tocPatchFilename.Replace(".toc", ".sb");
                    DAIEntry allBundleContents = new DAIEntry();
                    allBundleContents.AddListValue("bundles", new List<DAIEntry>());
                    foreach (DAIEntry changedValue2 in bundleToChangedValue.Values)
                    {
                        if (changedValue2 != null)
                        {
                            allBundleContents.GetListValue("bundles").Add(changedValue2);
                        }
                    }
                    allBundleContents.GetListValue("bundles").Sort((DAIEntry A, DAIEntry B) => string.Compare(A.GetStringValue("path"), B.GetStringValue("path")));
                    DAIToc allBundleContentsToc = new DAIToc();
                    allBundleContentsToc.SetRootEntry(allBundleContents);
                    allBundleContentsToc.WriteToFile(filename);
                    DAIToc baseBundlesToc = new DAIToc();
                    DAIEntry baseBundles = new DAIEntry();
                    List<DAIEntry> bundleMetas = bundleToChangedValue.Keys.Where((DAIEntry A) => A.HasField("base")).ToList();
                    List<DAIEntry> bundlesMetaDeltas = bundleToChangedValue.Keys.Where((DAIEntry A) => A.HasField("delta")).ToList();
                    bundleMetas.Sort((DAIEntry A, DAIEntry B) => string.Compare(A.GetStringValue("id"), B.GetStringValue("id")));
                    bundlesMetaDeltas.Sort((DAIEntry A, DAIEntry B) => string.Compare(A.GetStringValue("id"), B.GetStringValue("id")));
                    bundleMetas.AddRange(bundlesMetaDeltas);
                    baseBundles.AddListValue("bundles", bundleMetas);
                    baseBundles.AddListValue("chunks", new List<DAIEntry>());
                    baseBundles.AddBoolValue("cas", tocFile.GetRootEntry().GetBoolValue("cas"));
                    baseBundlesToc.SetRootEntry(baseBundles);
                    int index2 = 0;
                    for (int j = 0; j < bundleToChangedValue.Count; j = tocCount)
                    {
                        DAIEntry baseBundlesTocBundle = baseBundlesToc.GetBundles()[j];
                        if (baseBundlesTocBundle.HasField("delta"))
                        {
                            DAIEntry dAIEntry16 = allBundleContentsToc.GetBundles()[index2];
                            baseBundlesTocBundle.SetQWordValue("offset", dAIEntry16.EntryOffset);
                            baseBundlesTocBundle.SetDWordValue("size", (uint)dAIEntry16.GetSize());
                            tocCount = index2 + 1;
                            index2 = tocCount;
                        }
                        tocCount = j + 1;
                    }
                    baseBundlesToc.WriteToFile(tocPatchFilename, bWriteTocHeader: true);
                }
                tocCount = progress + 1;
                progress = tocCount;
                Sha1 LayoutNameHash = tocFilename.Replace(Settings.BasePath + "Data\\", "").Replace(".toc", "").Replace("\\", "/")
                    .ToLower().EncodeAsSha1();
                DAIEntry superBundle = layoutToc.GetRootEntry().GetListValue("superBundles").Find((DAIEntry A) => A.GetStringHashValue("name") == LayoutNameHash);
                if (superBundle?.HasField("same") ?? false)
                {
                    superBundle.RemoveField("same");
                    superBundle.AddBoolValue("delta", Value: true);
                }
            }
            layoutToc.GetRootEntry().RemoveField("fs");
            layoutToc.GetRootEntry().AddListValue("fs", new List<DAIEntry>());
            layoutToc.GetRootEntry().AddListStringChild("fs", "initfs_Win32");
            layoutToc.WriteToFile(patchPayloadDir + "\\Data\\layout.toc", bWriteTocHeader: true);
            chunks0Toc.WriteToFile(patchPayloadDir + "\\Data\\Win32\\chunks0.toc", bWriteTocHeader: true);
            StreamWriter streamWriter = new StreamWriter(patchPayloadDir + "\\package.mft");
            streamWriter.WriteLine("Name patch");
            streamWriter.WriteLine("Authoritative");
            streamWriter.WriteLine("Version " + (Settings.PatchVersion + 1));
            streamWriter.WriteLine("ModManager v0.60 alpha");
            streamWriter.Close();
        }

        private void WriteLogEntry(string LogText)
        {
            ProgressWin.StatusTextBox.AppendText("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "] " + LogText + "\n");
            ProgressWin.StatusTextBox.ScrollToEnd();
        }

        private void WriteLogEntry_Threaded(string LogText)
        {
            ProgressWin.Dispatcher.BeginInvoke(DispatcherPriority.Input, (Action)delegate
            {
                WriteLogEntry(LogText);
            });
        }

        private ModJob GenerateModJobFromPatch(string version)
        {
            IndexedMultiMap<Sha1, ModResourceEntry> indexedMultiMap = new IndexedMultiMap<Sha1, ModResourceEntry>();
            List<ModBundle> modBundleList = new List<ModBundle>();
            List<string> copyFiles = new List<string>();
            if (File.Exists(Settings.BasePath + "Update\\Patch\\package.mft"))
            {

                _bgWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Processing official patch."));

                string patchWin32Path = Settings.BasePath + "Update\\Patch\\Data\\Win32";
                string[] patchTocFiles = Directory.GetFiles(patchWin32Path, "*.toc", SearchOption.AllDirectories);

                int tocFileCount = 0;
                string[] patchTocFilesArray = patchTocFiles;
                foreach (string patchTocFileName in patchTocFilesArray)
                {

                    _bgWorker.ReportProgress((int)((double)tocFileCount / (double)patchTocFiles.Length * 100.0), new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: false, patchTocFileName.Replace(Settings.BasePath, ""), ""));
                    tocFileCount++;
                    if (Settings.VerboseScan)
                    {
                        WriteLogEntry_Threaded("[0] Processing " + patchTocFileName);
                    }

                    DAIToc newToc = DAIToc.ReadFromFile(patchTocFileName, 0L);
                    if (!newToc.HasBundles())
                    {
                        continue;
                    }
                    string baseTocFileName = patchTocFileName.Replace(patchWin32Path, Settings.BasePath + "Data\\Win32");
                    DAIToc existingToc = (File.Exists(baseTocFileName) ? DAIToc.ReadFromFile(baseTocFileName, 0L) : null);
                    if (existingToc != null)
                    {
                        // find all resources in existing toc that are NOT in newToc
                        foreach (DAIEntry bundle in existingToc.GetBundles().FindAll((DAIEntry A) => newToc.GetBundles().Find((DAIEntry B) => A.GetStringHashValue("id") == B.GetStringHashValue("id")) == null))
                        {
                            modBundleList.Add(new ModBundle(bundle.GetStringValue("id"), "remove"));
                        }
                    }
                    using (LazyDisposable<BinaryReader> patchSbReader = new LazyDisposable<BinaryReader>(() => new BinaryReader(FileHelpers.UnXorFile(patchTocFileName.Replace(".toc", ".sb")))))
                    {
                        using (LazyDisposable<BinaryReader> baseSbReader = new LazyDisposable<BinaryReader>(() => new BinaryReader(FileHelpers.UnXorFile(baseTocFileName.Replace(".toc", ".sb")))))
                        {
                            if (patchSbReader.Value.ReadByte() != 130)
                            {
                                copyFiles.Add(patchTocFileName.Replace(patchWin32Path + "\\", ""));
                                continue;
                            }
                            foreach (DAIEntry bundle in newToc.GetBundles())
                            {
                                if (bundle.HasField("base"))
                                {
                                    continue;
                                }
                                bool flag = false;
                                if (bundle.HasField("delta"))
                                {
                                    if (Settings.VerboseScan)
                                    {
                                        WriteLogEntry_Threaded("[1] Processing bundle " + bundle.GetStringValue("id"));
                                    }
                                    DAIEntry patchRootEntry = DAIToc.ReadFromStream(patchSbReader.Value, bundle.GetQWordValue("offset")).GetRootEntry();
                                    Sha1 bundleHash = bundle.GetStringHashValue("id");
                                    DAIEntry existingBundle = existingToc?.GetBundles().Find((DAIEntry A) => A.GetStringHashValue("id") == bundleHash);
                                    if (existingBundle != null)
                                    {
                                        ModBundle modBundle = new ModBundle(patchRootEntry.GetStringValue("path"), "modify");
                                        modBundleList.Add(modBundle);
                                        if (patchRootEntry.HasField("ebx") && File.Exists(baseTocFileName))
                                        {
                                            DAIEntry baseRootEntry = DAIToc.ReadFromStream(baseSbReader.Value, existingBundle.GetQWordValue("offset")).GetRootEntry();
                                            HashSet<Sha1> patchRootEbxSha1s = new HashSet<Sha1>(from ent in patchRootEntry.GetListValue("ebx")
                                                                                                select ent.GetSha1Value("sha1"));
                                            HashSet<Sha1> baseRootEbxSha1s = new HashSet<Sha1>(from ent in baseRootEntry.GetListValue("ebx")
                                                                                               select ent.GetSha1Value("sha1"));
                                            foreach (DAIEntry baseRootEntryEbx in from ent in baseRootEntry.GetListValue("ebx")
                                                                                  where !patchRootEbxSha1s.Contains(ent.GetSha1Value("sha1"))
                                                                                  select ent)
                                            {
                                                Sha1 baseRootEntryEbxSha1 = baseRootEntryEbx.GetSha1Value("sha1");
                                                int removedIndex = indexedMultiMap.FindIndex(baseRootEntryEbxSha1, (ModResourceEntry A) => A.Action == "remove");
                                                if (removedIndex == -1)
                                                {
                                                    removedIndex = indexedMultiMap.Add(baseRootEntryEbxSha1, new EbxModResourceEntry(baseRootEntryEbx.GetStringValue("name"), "remove")
                                                    {
                                                        OriginalSha1 = baseRootEntryEbxSha1
                                                    });
                                                }
                                                modBundle.Entries.Add(new ModBundleEntry(removedIndex));
                                            }
                                            foreach (DAIEntry patchRootEntryEbx in from ent in patchRootEntry.GetListValue("ebx")
                                                                                   where !baseRootEbxSha1s.Contains(ent.GetSha1Value("sha1"))
                                                                                   select ent)
                                            {
                                                int addedIndex = indexedMultiMap.FindIndex(patchRootEntryEbx.GetSha1Value("sha1"), (ModResourceEntry A) => A.Action == "add" && A.PatchType == (patchRootEntryEbx.HasField("casPatchType") ? patchRootEntryEbx.GetDWordValue("casPatchType") : 0));
                                                if (addedIndex == -1)
                                                {
                                                    ModResourceEntry ebxModResEntry = new EbxModResourceEntry(patchRootEntryEbx.GetStringValue("name"), "add");
                                                    ebxModResEntry.Size = patchRootEntryEbx.GetQWordValue("size");
                                                    ebxModResEntry.OriginalSize = patchRootEntryEbx.GetQWordValue("originalSize");
                                                    ebxModResEntry = ModResourceEntryExt.CopyPatchSha1(ebxModResEntry, patchRootEntryEbx);
                                                    addedIndex = indexedMultiMap.Add(patchRootEntryEbx.GetSha1Value("sha1"), ebxModResEntry);
                                                }
                                                modBundle.Entries.Add(new ModBundleEntry(addedIndex));
                                            }
                                        }
                                        if (patchRootEntry.HasField("res") && File.Exists(baseTocFileName))
                                        {
                                            DAIEntry baseRootEntry2 = DAIToc.ReadFromStream(baseSbReader.Value, existingBundle.GetQWordValue("offset")).GetRootEntry();
                                            HashSet<Sha1> patchRootEntryResSha1s = new HashSet<Sha1>(from ent in patchRootEntry.GetListValue("res")
                                                                                                     select ent.GetSha1Value("sha1"));
                                            HashSet<Sha1> baseRootEntryResSha1s = new HashSet<Sha1>(from ent in baseRootEntry2.GetListValue("res")
                                                                                                    select ent.GetSha1Value("sha1"));
                                            foreach (DAIEntry baseRootEntryRes in from ent in baseRootEntry2.GetListValue("res")
                                                                                  where !patchRootEntryResSha1s.Contains(ent.GetSha1Value("sha1"))
                                                                                  select ent)
                                            {
                                                Sha1 baseRootEntryResSha1 = baseRootEntryRes.GetSha1Value("sha1");
                                                int removedIndex = indexedMultiMap.FindIndex(baseRootEntryResSha1, (ModResourceEntry A) => A.Action == "remove" && A.Name == baseRootEntryRes.GetStringValue("name"));
                                                if (removedIndex == -1)
                                                {
                                                    removedIndex = indexedMultiMap.Add(baseRootEntryResSha1, new ResModResourceEntry(baseRootEntryRes.GetStringValue("name"), "remove")
                                                    {
                                                        OriginalSha1 = baseRootEntryResSha1
                                                    });
                                                }
                                                modBundle.Entries.Add(new ModBundleEntry(removedIndex));
                                            }
                                            foreach (DAIEntry patchRootEntryRes in from ent in patchRootEntry.GetListValue("res")
                                                                                   where !baseRootEntryResSha1s.Contains(ent.GetSha1Value("sha1"))
                                                                                   select ent)
                                            {
                                                Sha1 patchRootEntryResSha1 = patchRootEntryRes.GetSha1Value("sha1");
                                                int addedIndex = indexedMultiMap.FindIndex(patchRootEntryResSha1, (ModResourceEntry A) => A.Action == "add" && A.Name == patchRootEntryRes.GetStringValue("name") && A.PatchType == (patchRootEntryRes.HasField("casPatchType") ? patchRootEntryRes.GetDWordValue("casPatchType") : 0));
                                                if (addedIndex == -1)
                                                {
                                                    ResModResourceEntry resModEntry = new ResModResourceEntry(patchRootEntryRes.GetStringValue("name"), "add");
                                                    resModEntry.Size = patchRootEntryRes.GetQWordValue("size");
                                                    resModEntry.OriginalSize = patchRootEntryRes.GetQWordValue("originalSize");
                                                    resModEntry.ResRid = patchRootEntryRes.GetQWordValue("resRid");
                                                    resModEntry.ResType = patchRootEntryRes.GetDWordValue("resType");
                                                    resModEntry.Meta = Meta.MetaToString(patchRootEntryRes.GetByteArrayValue("resMeta"));
                                                    resModEntry = (ResModResourceEntry)ModResourceEntryExt.CopyPatchSha1(resModEntry, patchRootEntryRes);
                                                    addedIndex = indexedMultiMap.Add(patchRootEntryResSha1, resModEntry);
                                                }
                                                modBundle.Entries.Add(new ModBundleEntry(addedIndex));
                                            }
                                        }
                                        if (patchRootEntry.HasField("chunks") && File.Exists(baseTocFileName))
                                        {
                                            DAIEntry baseRootEntry = DAIToc.ReadFromStream(baseSbReader.Value, existingBundle.GetQWordValue("offset")).GetRootEntry();
                                            List<int> AddedCHUNK = new List<int>();
                                            if (baseRootEntry.HasField("chunks"))
                                            {
                                                HashSet<DQWord> patchChunkIdSet = new HashSet<DQWord>(from ent in patchRootEntry.GetListValue("chunks")
                                                                                                      select ent.GetDQWordValue("id"));
                                                foreach (DAIEntry baseRootEntryChunk in from ent in baseRootEntry.GetListValue("chunks")
                                                                                        where !patchChunkIdSet.Contains(ent.GetDQWordValue("id"))
                                                                                        select ent)
                                                {
                                                    int removedIndex = indexedMultiMap.FindIndex(baseRootEntryChunk.GetSha1Value("sha1"), (ModResourceEntry A) => A.Action == "remove" && A.Name == baseRootEntryChunk.GetDQWordValue("id").ToString());
                                                    if (removedIndex == -1)
                                                    {
                                                        removedIndex = indexedMultiMap.Add(baseRootEntryChunk.GetSha1Value("sha1"), new ChunkModResourceEntry(baseRootEntryChunk.GetDQWordValue("id").ToString(), "remove")
                                                        {
                                                            OriginalSha1 = baseRootEntryChunk.GetSha1Value("sha1")
                                                        });
                                                    }
                                                    modBundle.Entries.Add(new ModBundleEntry(removedIndex));
                                                }
                                                HashSet<DQWord> baseChunkIdSet = new HashSet<DQWord>(from ent in baseRootEntry.GetListValue("chunks")
                                                                                                     select ent.GetDQWordValue("id"));
                                                int idx = 0;
                                                patchRootEntry.GetListValue("chunks").ForEach(delegate (DAIEntry A)
                                                {
                                                    if (!baseChunkIdSet.Contains(A.GetDQWordValue("id")))
                                                    {
                                                        AddedCHUNK.Add(idx);
                                                    }
                                                    idx++;
                                                });
                                            }
                                            foreach (int chunkId in AddedCHUNK)
                                            {
                                                DAIEntry chunk = patchRootEntry.GetListValue("chunks")[chunkId];
                                                DAIEntry chunkMeta;
                                                if (chunkId < patchRootEntry.GetListValue("chunkMeta").Count)
                                                {
                                                    chunkMeta = patchRootEntry.GetListValue("chunkMeta")[chunkId];
                                                }
                                                else
                                                {
                                                    chunkMeta = new DAIEntry();
                                                    chunkMeta.AddDWordValue("h32", uint.MaxValue);
                                                    chunkMeta.AddByteArrayValue("meta", new byte[1]);
                                                }
                                                int addedIndex = indexedMultiMap.FindIndex(chunk.GetSha1Value("sha1"), (ModResourceEntry A) => A.Action == "add" && A.Name == chunk.GetDQWordValue("id").ToString());
                                                if (addedIndex == -1)
                                                {
                                                    ChunkModResourceEntry chunkModResEntry = new ChunkModResourceEntry(chunk.GetDQWordValue("id").ToString(), "add");
                                                    chunkModResEntry.Size = chunk.GetDWordValue("size");
                                                    chunkModResEntry = (ChunkModResourceEntry)ModResourceEntryExt.CopyChunkFields(chunkModResEntry, chunk, chunkMeta);
                                                    addedIndex = indexedMultiMap.Add(chunk.GetSha1Value("sha1"), chunkModResEntry);
                                                }
                                                modBundle.Entries.Add(new ModBundleEntry(addedIndex));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        flag = true;
                                    }
                                }
                                else
                                {
                                    flag = true;
                                }
                                if (!flag)
                                {
                                    continue;
                                }
                                if (Settings.VerboseScan)
                                {
                                    WriteLogEntry_Threaded("[1] Processing bundle " + bundle.GetStringValue("id"));
                                }
                                DAIEntry patchBundle = DAIToc.ReadFromStream(patchSbReader.Value, bundle.GetQWordValue("offset")).GetRootEntry();
                                ModBundle patchModBundle = new ModBundle(patchBundle.GetStringValue("path"), "add");
                                patchModBundle.TocFilename = patchTocFileName.Replace(patchWin32Path + "\\", "");
                                patchModBundle.MagicSalt = patchBundle.GetDWordValue("magicSalt");
                                patchModBundle.AlignMembers = (byte)(patchBundle.GetBoolValue("alignMembers") ? 1 : 0);
                                patchModBundle.RidSupport = (byte)(patchBundle.GetBoolValue("ridSupport") ? 1 : 0);
                                patchModBundle.StoreCompressedSizes = (byte)(patchBundle.GetBoolValue("storeCompressedSizes") ? 1 : 0);
                                modBundleList.Add(patchModBundle);
                                if (patchBundle.HasField("ebx"))
                                {
                                    foreach (DAIEntry patchBundleEbx in patchBundle.GetListValue("ebx"))
                                    {
                                        DAIEntry patchBundleEbxEntry = patchBundleEbx;
                                        Sha1 patchBundleEbxSha1 = patchBundleEbxEntry.GetSha1Value("sha1");
                                        int addedIndex = indexedMultiMap.FindIndex(patchBundleEbxSha1, (ModResourceEntry A) => A.Action == "add" && A.PatchType == (patchBundleEbxEntry.HasField("casPatchType") ? patchBundleEbxEntry.GetDWordValue("casPatchType") : 0));
                                        if (addedIndex == -1)
                                        {
                                            EbxModResourceEntry ebxModResEntry = new EbxModResourceEntry(patchBundleEbxEntry.GetStringValue("name"), "add");
                                            ebxModResEntry.Size = patchBundleEbxEntry.GetQWordValue("size");
                                            ebxModResEntry.OriginalSize = patchBundleEbxEntry.GetQWordValue("originalSize");
                                            ebxModResEntry = (EbxModResourceEntry)ModResourceEntryExt.CopyPatchSha1(ebxModResEntry, patchBundleEbxEntry);
                                            addedIndex = indexedMultiMap.Add(patchBundleEbxSha1, ebxModResEntry);
                                        }
                                        patchModBundle.Entries.Add(new ModBundleEntry(addedIndex));
                                    }
                                }
                                if (patchBundle.HasField("res"))
                                {
                                    foreach (DAIEntry patchBundleRes in patchBundle.GetListValue("res"))
                                    {
                                        Sha1 patchBundleResSha1 = patchBundleRes.GetSha1Value("sha1");
                                        int addedIndex = indexedMultiMap.FindIndex(patchBundleResSha1, (ModResourceEntry A) => A.Action == "add" && A.Name == patchBundleRes.GetStringValue("name") && A.PatchType == (patchBundleRes.HasField("casPatchType") ? patchBundleRes.GetDWordValue("casPatchType") : 0));
                                        if (addedIndex == -1)
                                        {
                                            ResModResourceEntry resModResEntry = new ResModResourceEntry(patchBundleRes.GetStringValue("name"), "add");
                                            resModResEntry = (ResModResourceEntry)ModResourceEntryExt.CopyPatchSha1(resModResEntry, patchBundleRes);
                                            resModResEntry.Size = patchBundleRes.GetQWordValue("size");
                                            resModResEntry.OriginalSize = patchBundleRes.GetQWordValue("originalSize");
                                            resModResEntry.ResRid = patchBundleRes.GetQWordValue("resRid");
                                            resModResEntry.ResType = patchBundleRes.GetDWordValue("resType");
                                            resModResEntry.Meta = Meta.MetaToString(patchBundleRes.GetByteArrayValue("resMeta"));
                                            addedIndex = indexedMultiMap.Add(patchBundleResSha1, resModResEntry);
                                        }
                                        patchModBundle.Entries.Add(new ModBundleEntry(addedIndex));
                                    }
                                }
                                if (!patchBundle.HasField("chunks"))
                                {
                                    continue;
                                }
                                int k = 0;
                                while (k < patchBundle.GetListValue("chunks").Count)
                                {
                                    DAIEntry chunk = patchBundle.GetListValue("chunks")[k];
                                    Sha1 chunkSha1 = chunk.GetSha1Value("sha1");
                                    DAIEntry chunkMetaEntry = patchBundle.GetListValue("chunkMeta")[k];
                                    int addedIndex = indexedMultiMap.FindIndex(chunkSha1, (ModResourceEntry A) => A.Action == "add" && A.Name == chunk.GetDQWordValue("id").ToString());
                                    if (addedIndex == -1)
                                    {
                                        ChunkModResourceEntry chunkModResEntry = new ChunkModResourceEntry(chunk.GetDQWordValue("id").ToString(), "add");
                                        chunkModResEntry.Size = chunk.GetDWordValue("size");
                                        chunkModResEntry = (ChunkModResourceEntry)ModResourceEntryExt.CopyChunkFields(chunkModResEntry, chunk, chunkMetaEntry);
                                        addedIndex = indexedMultiMap.Add(chunkSha1, chunkModResEntry);
                                    }
                                    patchModBundle.Entries.Add(new ModBundleEntry(addedIndex));
                                    int m = k + 1;
                                    k = m;
                                }
                            }
                        }
                    }
                }
            }
            ModJob modJob = new ModJob("Official Patch", "", "");
            modJob.Meta = new ModMetaData(1, 0, "", 0, new ModDetail("Official Patch", version, "Bioware", ""));
            modJob.Meta.Resources = indexedMultiMap.ToList();
            modJob.Meta.Bundles = modBundleList;
            modJob.Meta.CopyFiles = copyFiles;
            modJob.Save(Directory.GetCurrentDirectory() + "\\Patch.daimod");
            Settings.RescanPatch = false;
            return modJob;
        }

        public ModJob GenerateModJobFromDistPatch(ModContainer modContainer)
        {
            ModJob modJob = new ModJob(modContainer.Name, "", "")
            {
                Meta = new ModMetaData(1, 0, "", 0, new ModDetail(modContainer.Name, "", "", ""))
            };
            _bgWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Processing distributable patch \"" + modContainer.Name + "\""));

            Dictionary<Sha1, DAICatEntry> catDict = DAICat.SerializeLocal(modContainer.Path + "\\Data\\cas.cat");
            string[] modTocFiles = Directory.GetFiles(modContainer.Path + "\\Data\\Win32", "*.toc", SearchOption.AllDirectories);
            int modTocFileCount = 0;
            string[] modTocFilesArray = modTocFiles;
            foreach (string modTocFilename in modTocFilesArray)
            {

                _bgWorker.ReportProgress((int)(modTocFileCount / (double)modTocFiles.Length * 100.0), new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: false, modTocFilename.Replace(modContainer.Path + "\\Data\\Win32\\", ""), ""));

                DAIToc modToc = DAIToc.ReadFromFile(modTocFilename, 0L);
                string baseTocFile = modTocFilename.Replace(modContainer.Path + "\\", DAIPath);
                if (modToc.HasBundles())
                {
                    using (LazyDisposable<BinaryReader> modSbReader = new LazyDisposable<BinaryReader>(() => new BinaryReader(FileHelpers.UnXorFile(modTocFilename.Replace(".toc", ".sb")))))
                    {
                        using (LazyDisposable<BinaryReader> baseSbReader = new LazyDisposable<BinaryReader>(() => new BinaryReader(FileHelpers.UnXorFile(baseTocFile.Replace(".toc", ".sb")))))
                        {
                            foreach (DAIEntry modTocBundle in modToc.GetBundles())
                            {
                                if (!modTocBundle.HasField("base") && modTocBundle.HasField("delta"))
                                {
                                    DAIEntry modRootEntry = DAIToc.ReadFromStream(modSbReader.Value, modTocBundle.GetQWordValue("offset")).GetRootEntry();
                                    Sha1 modTocBundleSha1 = modTocBundle.GetStringHashValue("id");
                                    ModBundle modRootEntryModBundle = new ModBundle(modRootEntry.GetStringValue("path"), "modify");
                                    modJob.Meta.Bundles.Add(modRootEntryModBundle);
                                    DAIEntry baseEntry = DAIToc.ReadFromFile(baseTocFile, 0L).GetBundles().Find((DAIEntry A) => A.GetStringHashValue("id") == modTocBundleSha1);
                                    DAIEntry baseRootEntry = DAIToc.ReadFromStream(baseSbReader.Value, baseEntry.GetQWordValue("offset")).GetRootEntry();
                                    if (modRootEntry.HasField("ebx"))
                                    {
                                        ILookup<Sha1, DAIEntry> baseRootEntryEbxLookup = baseRootEntry.GetListValue("ebx").ToLookup((DAIEntry ent) => ent.GetStringHashValue("name"));
                                        foreach (DAIEntry ebx in from ent in modRootEntry.GetListValue("ebx")
                                                                 where !baseRootEntryEbxLookup[ent.GetStringHashValue("name")].Any((DAIEntry ent2) => ent.GetSha1Value("sha1") == ent2.GetSha1Value("sha1"))
                                                                 select ent)
                                        {
                                            DAIEntry modEbxEntry = ebx;
                                            DAIEntry baseEbxEntry = baseRootEntryEbxLookup[ebx.GetStringHashValue("name")].FirstOrDefault();
                                            if (baseEbxEntry != null)
                                            {
                                                int modifiedIndex = modJob.Meta.Resources.FindIndex((ModResourceEntry A) => A.OriginalSha1 == baseEbxEntry.GetSha1Value("sha1") && A.Action == "modify");
                                                if (modifiedIndex == -1)
                                                {
                                                    EbxModResourceEntry ebxMre = new EbxModResourceEntry(modEbxEntry.GetStringValue("name"), "modify")
                                                    {
                                                        Size = modEbxEntry.GetQWordValue("size"),
                                                        OriginalSize = modEbxEntry.GetQWordValue("originalSize"),
                                                        PatchType = 1,
                                                        OriginalSha1 = baseEbxEntry.GetSha1Value("sha1")
                                                    };
                                                    modJob.Meta.Resources.Add(ebxMre);
                                                    modifiedIndex = modJob.Meta.Resources.Count - 1;
                                                    DAICatEntry modCatEntry = catDict[modEbxEntry.GetSha1Value("sha1")];
                                                    modJob.Data.Add(DAICat.Get().GetCompressedPayloadFromFile(modCatEntry.Path, modCatEntry.Offset, modCatEntry.Size).ToArray());
                                                    ebxMre.ResourceID = modJob.Data.Count - 1;
                                                    ebxMre.NewSha1 =  modJob.Data[ebxMre.ResourceID].EncodeAsSha1();
                                                }
                                                modRootEntryModBundle.Entries.Add(new ModBundleEntry(modifiedIndex));
                                            }
                                        }
                                    }

                                    if (modRootEntry.HasField("res"))
                                    {
                                        ILookup<Sha1, DAIEntry> baseRootEntryResLookup = baseRootEntry.GetListValue("res").ToLookup((DAIEntry ent) => ent.GetStringHashValue("name"));
                                        foreach (DAIEntry res in from ent in modRootEntry.GetListValue("res")
                                                                 where !baseRootEntryResLookup[ent.GetStringHashValue("name")].Any((DAIEntry ent2) => ent.GetSha1Value("sha1") == ent2.GetSha1Value("sha1"))
                                                                 select ent)
                                        {
                                            DAIEntry modResEntry = res;
                                            DAIEntry baseResEntry = baseRootEntryResLookup[res.GetStringHashValue("name")].FirstOrDefault();
                                            if (baseResEntry != null)
                                            {
                                                int modifiedIndex = modJob.Meta.Resources.FindIndex((ModResourceEntry A) => A.OriginalSha1 == baseResEntry.GetSha1Value("sha1") && A.Action == "modify");
                                                if (modifiedIndex == -1)
                                                {
                                                    ResModResourceEntry resMre = new ResModResourceEntry(modResEntry.GetStringValue("name"), "modify");
                                                    modJob.Meta.Resources.Add(resMre);
                                                    resMre.Size = modResEntry.GetQWordValue("size");
                                                    resMre.OriginalSize = modResEntry.GetQWordValue("originalSize");
                                                    resMre.ResRid = modResEntry.GetQWordValue("resRid");
                                                    resMre.ResType = modResEntry.GetDWordValue("resType");
                                                    resMre.Meta = Meta.MetaToString(modResEntry.GetByteArrayValue("resMeta"));
                                                    resMre.PatchType = 1;
                                                    resMre.OriginalSha1 = baseResEntry.GetSha1Value("sha1");
                                                    modifiedIndex = modJob.Meta.Resources.Count - 1;
                                                    DAICatEntry modCatEntry = catDict[modResEntry.GetSha1Value("sha1")];
                                                    modJob.Data.Add(DAICat.Get().GetCompressedPayloadFromFile(modCatEntry.Path, modCatEntry.Offset, modCatEntry.Size).ToArray());
                                                    resMre.ResourceID = modJob.Data.Count - 1;
                                                    resMre.NewSha1 = modJob.Data[resMre.ResourceID].EncodeAsSha1();
                                                }
                                                modRootEntryModBundle.Entries.Add(new ModBundleEntry(modifiedIndex));
                                            }
                                        }
                                    }
                                    if (modRootEntry.HasField("chunks"))
                                    {
                                        List<int> AddedCHUNK = new List<int>();
                                        if (baseRootEntry.HasField("chunks"))
                                        {
                                            HashSet<DQWord> baseRootEntryChunkIds = new HashSet<DQWord>(from ent in baseRootEntry.GetListValue("chunks")
                                                                                                        select ent.GetDQWordValue("id"));
                                            int idx = 0;
                                            modRootEntry.GetListValue("chunks").ForEach(delegate (DAIEntry A)
                                            {
                                                if (!baseRootEntryChunkIds.Contains(A.GetDQWordValue("id")))
                                                {
                                                    AddedCHUNK.Add(idx);
                                                }
                                                idx++;
                                            });
                                        }
                                        foreach (int chunkIndex in AddedCHUNK)
                                        {
                                            DAIEntry chunk = modRootEntry.GetListValue("chunks")[chunkIndex];
                                            DAIEntry chunkMeta = modRootEntry.GetListValue("chunkMeta")[chunkIndex];
                                            int addedIndex = modJob.Meta.Resources.FindIndex((ModResourceEntry A) => A.OriginalSha1 == chunk.GetSha1Value("sha1") && A.Action == "add");
                                            if (addedIndex == -1)
                                            {
                                                if (!catDict.ContainsKey(chunk.GetSha1Value("sha1")))
                                                {
                                                    continue;
                                                }
                                                ChunkModResourceEntry chunkMre = new ChunkModResourceEntry(chunk.GetDQWordValue("id").ToString(), "add");
                                                modJob.Meta.Resources.Add(chunkMre);
                                                chunkMre.ChunkH32 = chunkMeta.GetDWordValue("h32");
                                                chunkMre.OriginalSha1 = chunk.GetSha1Value("sha1");
                                                chunkMre.PatchType = 1;
                                                addedIndex = modJob.Meta.Resources.Count - 1;
                                                DAICatEntry chunkCatEntry = catDict[chunk.GetSha1Value("sha1")];
                                                byte[] catFileData = Utils.DecompressData(DAICat.Get().GetCompressedPayloadFromFile(chunkCatEntry.Path, chunkCatEntry.Offset, chunkCatEntry.Size).ToArray());
                                                ImportCompressData ImportResults = new ImportCompressData();
                                                byte[] compCatFileData = Utils.CompressData(catFileData, ref ImportResults);
                                                if (chunk.HasField("rangeStart"))
                                                {
                                                    chunkMre.RangeStart = ImportResults.RangeStart;
                                                    chunkMre.RangeEnd = ImportResults.RangeEnd;
                                                    chunkMre.Meta = "0866697273744D6970000000000000";
                                                }
                                                chunkMre.LogicalOffset = 0;
                                                chunkMre.LogicalSize = catFileData.Length;
                                                chunkMre.Size = compCatFileData.Length;
                                                modJob.Data.Add(compCatFileData);
                                                chunkMre.ResourceID = modJob.Data.Count - 1;
                                            }
                                            modRootEntryModBundle.Entries.Add(new ModBundleEntry(addedIndex));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                int num5 = modTocFileCount + 1;
                modTocFileCount = num5;
            }
            return modJob;
        }

        public IEnumerable<ModJob> ProcessModList(PatchPayloadData patchPayloadData)
        {
            return patchPayloadData.ModList.Select(delegate (ModContainer modContainer)
            {
                if (!modContainer.IsDAIMod())
                {
                    return GenerateModJobFromDistPatch(modContainer);
                }
                _bgWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Processing DAI mod \"" + modContainer.Name + "\""));
                if (modContainer.Mod.ScriptObject != null)
                {
                    Scripting.CurrentMod = modContainer.Mod;
                    modContainer.Mod.ScriptObject.RunScript();
                }
                return modContainer.Mod;
            });
        }

        public ModJob GetBasePatchModJob()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\patch.daimod") || Settings.RescanPatch)
            {
                return GenerateModJobFromPatch(PatchMod.Version);
            }
            _bgWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Loading official patch."));
            return ModJob.CreateFromFile(Directory.GetCurrentDirectory() + "\\patch.daimod");
        }

        public void PrepareDirectory(string directoryName, ModJob basePatchModJob, Dictionary<Sha1, byte[]> modResources, string patchDataPath, out DAIToc layoutToc)
        {
            if (Directory.Exists(directoryName + "\\Data"))
            {
                Directory.Delete(directoryName + "\\Data", recursive: true);
            }
            _bgWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Creating cas files."));
            string text = "";
            if (File.Exists(patchDataPath + "cas.cat"))
            {
                Directory.CreateDirectory(directoryName + "\\Data");
                File.Copy(patchDataPath + "cas.cat", directoryName + "\\Data\\cas.cat");
                File.Copy(patchDataPath + "initfs_Win32", directoryName + "\\Data\\initfs_Win32");
                string[] files = Directory.GetFiles(patchDataPath, "*.cas");
                foreach (string text2 in files)
                {
                    File.Copy(text2, directoryName + "\\Data\\" + text2.Remove(0, text2.LastIndexOf('\\') + 1));
                    text = text2.Remove(0, text2.LastIndexOf('\\') + 1);
                }
            }
            Directory.CreateDirectory(directoryName + "\\Data\\Win32\\Loc");
            string[] files2 = Directory.GetFiles(patchDataPath + "\\Win32\\Loc");
            foreach (string text3 in files2)
            {
                File.Copy(text3, directoryName + "\\Data\\Win32\\Loc\\" + text3.Remove(0, text3.LastIndexOf('\\') + 1));
            }
            foreach (string copyFile in basePatchModJob.Meta.CopyFiles)
            {
                string text4 = directoryName + "\\Data\\Win32\\" + copyFile;
                string text5 = patchDataPath + "Win32\\" + copyFile;
                Directory.CreateDirectory(Path.GetDirectoryName(text4));
                if (!File.Exists(text4))
                {
                    File.Copy(text5, text4);
                    File.Copy(text5.Replace(".toc", ".sb"), text4.Replace(".toc", ".sb"));
                }
            }
            layoutToc = DAIToc.ReadFromFile(patchDataPath + "layout.toc", 0L);
            int num = Convert.ToInt32(text.Substring(4, 2));
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(directoryName + "\\Data\\" + text, FileMode.Open));
            binaryWriter.BaseStream.Position = binaryWriter.BaseStream.Length;
            BinaryWriter binaryWriter2 = new BinaryWriter(new FileStream(directoryName + "\\Data\\cas.cat", FileMode.Open));
            binaryWriter2.BaseStream.Position = binaryWriter2.BaseStream.Length;
            foreach (KeyValuePair<Sha1, byte[]> modResource in modResources)
            {
                if (binaryWriter.BaseStream.Position + modResource.Value.Length + 32 > 1073741824)
                {
                    binaryWriter.Flush();
                    binaryWriter.Close();
                    int num2 = num + 1;
                    num = num2;
                    binaryWriter = new BinaryWriter(new FileStream(directoryName + "\\Data\\cas_" + num.ToString("D2") + ".cas", FileMode.Create));
                }
                Sha1 sha1 = modResource.Value.EncodeAsSha1();
                binaryWriter.Write(new byte[4] { 250, 206, 15, 240 });
                binaryWriter.Write(sha1);
                binaryWriter.Write((long)modResource.Value.Length);
                binaryWriter2.Write(sha1);
                binaryWriter2.Write((uint)binaryWriter.BaseStream.Position);
                binaryWriter2.Write(modResource.Value.Length);
                binaryWriter2.Write(num);
                binaryWriter.Write(modResource.Value);
            }
            binaryWriter2.Flush();
            binaryWriter2.Close();
            binaryWriter.Flush();
            binaryWriter.Close();
        }

        public ModJob ModJobForResource(IEnumerable<ModJob> modJobs, ModResourceEntry entry)
        {
            foreach (ModJob modJob in modJobs)
            {
                if (modJob.Meta.Resources.Contains(entry))
                {
                    return modJob;
                }
            }
            return null;
        }

        public bool CheckBasePatch()
        {
            if (DAIMft.SerializeFromFile(DAIPath + "Update\\Patch\\package.mft").HasKey("ModManager"))
            {
                return false;
            }
            DAIToc dAIToc = DAIToc.ReadFromFile(DAIPath + "Update\\Patch\\Data\\Win32\\globals.toc", 0L);
            IEnumerable<string> enumerable = from b in dAIToc.GetBundles()
                                             where b.HasField("base")
                                             select b.GetStringValue("id");
            return enumerable.SequenceEqual(enumerable.OrderBy((string id) => id));
        }

        public void SetModPath()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (!string.IsNullOrWhiteSpace(ModPath))
            {
                folderBrowserDialog.SelectedPath = ModPath;
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                ModPath = folderBrowserDialog.SelectedPath;
                LoadMods();
            }
        }

        public void SetBasePath()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "*.exe|*.exe",
                Title = "Find Dragon Age: Inquisition executable"
            };
            if (!openFileDialog.ShowDialog().Value)
            {
                return;
            }
            DAIPath = Path.GetDirectoryName(openFileDialog.FileName) + "\\";
            if (File.Exists(DAIPath + "Update\\Patch\\package.mft"))
            {
                int num = int.Parse(DAIMft.SerializeFromFile(DAIPath + "Update\\Patch\\package.mft").GetValue("Version"));
                if (Settings.PatchVersion != num)
                {
                    ForceRescan = true;
                }
                Settings.PatchVersion = num;
            }
            else
            {
                Settings.PatchVersion = -1;
            }
            LoadMods();
        }

        public void MoveSelectedModUp()
        {
            ModContainer mod1Before = UserModList[SelectedMod.Index - 1];
            SwitchSelectedModWith(mod1Before);
        }

        public void MoveSelectedModDown()
        {
            ModContainer mod1After = UserModList[SelectedMod.Index + 1];
            SwitchSelectedModWith(mod1After);
        }

        private void SwitchSelectedModWith(ModContainer modToSwitch)
        {
            int selectedIndex = UserModList.IndexOf(SelectedMod);
            ModContainer selectedMod = UserModList[selectedIndex];
            int switchIndex = modToSwitch.Index;
            RemoveUserMod(modToSwitch);
            InsertUserMod(selectedIndex, modToSwitch);
            RemoveUserMod(selectedMod);
            InsertUserMod(switchIndex, selectedMod);
            SelectedMod = UserModList[switchIndex];
        }
    }
}