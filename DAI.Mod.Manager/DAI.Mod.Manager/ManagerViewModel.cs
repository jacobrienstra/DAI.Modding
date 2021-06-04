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
using DAI.AssetLibrary.Utilities.Extensions;
using DAI.AssetLibrary.Utilities;

namespace DAI.Mod.Manager {
    public class ManagerViewModel {
        private readonly BackgroundWorker _bgWorker;

        public bool Cancelled { get; set; }
        public ProgressWindow ProgressWin { get; private set; }
        public List<ModContainer> ModList { get; private set; }
        public bool ModManagerGridEnabled { get; private set; }
        public bool MergeReady { get; private set; }
        public ManagerViewModel(BackgroundWorker bgWorker) {
            Cancelled = true;
            ModManagerGridEnabled = false;
            ModList = new List<ModContainer>();
            MergeReady = false;
            _bgWorker = bgWorker;
            _bgWorker.WorkerReportsProgress = true;
            _bgWorker.WorkerSupportsCancellation = true;
            _bgWorker.DoWork += BGWorker_DoWork;
            _bgWorker.RunWorkerCompleted += BGWorker_RunWorkerCompleted;
            _bgWorker.ProgressChanged += BGWorker_ProgressChanged;
        }

        public void LoadMods() {
            ModList.Clear();
            // Initialize Check
            if (!File.Exists(Settings.BasePath + "DragonAgeInquisition.exe")) {
                MessageBox.Show("Dragon Age path has not been setup correctly. Please click on Browse and locate.", "Warning");
                return;
            }
            if (Settings.PatchVersion == -1) {
                MessageBox.Show("You *MUST* have a version of the Official Patch to be able to use mods.", "Error");
                return;
            }
            if (!CheckBasePatch()) {
                MessageBox.Show("The official patch folder contains a merged mod manager patch. Please restore the official patch to the correct location, or use 'Repair Game' in Origin to correct it.");
                return;
            }
            ModManagerGridEnabled = false;
            if (Settings.ModPath == "") {
                return;
            }

            // Add official Patch
            ModList.Add(new ModContainer(Settings.BasePath + "Update\\Patch\\", "Official Patch", "Bioware", "", "") {
                IsOfficialPatch = true,
                Version = Settings.PatchVersion.ToString()
            });

            // Add mft user mods
            int i = 1;
            foreach (string item in Directory.EnumerateDirectories(Settings.ModPath)) {
                if (File.Exists(item + "\\package.mft")) {
                    DAIMft dAIMft = DAIMft.SerializeFromFile(item + "\\package.mft");
                    if (dAIMft.HasKey("ModTitle")) {
                        ModList.Add(new ModContainer(item, dAIMft.GetValue("ModTitle"), dAIMft.GetValue("ModAuthor"), dAIMft.GetValue("ModVersion"), dAIMft.GetValue("ModDescription")) {
                            Index = i++
                        });
                    }
                }
            }

            // Add daimod user mods
            string[] files = Directory.GetFiles(Settings.ModPath, "*.daimod", SearchOption.AllDirectories);
            foreach (string file in files) {
                ModJob modJob = ModJob.CreateFromFile(file);
                ModList.Add(new ModContainer(file, modJob.Meta.Details.Name, modJob.Meta.Details.Author, modJob.Meta.Details.Version, modJob.Meta.Details.Description, modJob.Meta.MinPatchVersion) {
                    Mod = modJob,
                    Index = i++
                });
                // setup UI, set configvalues
                if (modJob.ScriptObject != null) {
                    ModConfigElementsList modConfigElementsList = new ModConfigElementsList();
                    modJob.ScriptObject.ConstructUI(modConfigElementsList);
                    modJob.ConfigValues = new Dictionary<string, object>();
                    foreach (ModConfigElement uIElement in modConfigElementsList.UIElements) {
                        modJob.ConfigValues.Add(uIElement.ParameterName, uIElement.ParameterDefaultValue);
                    }
                }
                // version check
                if (modJob.Meta.ToolSetVersion >= 1000 && modJob.Meta.ToolSetVersion < 1016) {
                    System.Windows.MessageBox.Show("Warning: Mod " + modJob.Meta.Details.Name + " was created with an unstable toolset version and may not function correctly");
                }
            }
            MergeReady = true;
        }

        private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            LoadingProgressState loadingProgressState = e.UserState as LoadingProgressState;
            if (loadingProgressState.UpdateStatus) {
                ProgressWin.StatusTextBlock.Text = loadingProgressState.StatusText;
            }
            if (loadingProgressState.UpdateProgress) {
                ProgressWin.StatusProgressBar.Visibility = Visibility.Visible;
                ProgressWin.StatusProgressBar.Value = e.ProgressPercentage;
                ProgressWin.TaskbarItemInfo.ProgressValue = (double)e.ProgressPercentage / 100.0;
                ProgressWin.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Normal;
            }
            if (loadingProgressState.UpdateLog) {
                WriteLogEntry(loadingProgressState.LogText);
            }
        }

        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
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
            } else {
                WriteLogEntry("Task completed sucessfully");
                ProgressWin.StatusProgressBar.Value = 0.0;
                ProgressWin.StatusTextBlock.Text = "";
                ProgressWin.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Indeterminate;
            }
            ProgressWin.CloseWindowButton.IsEnabled = true;
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e) {
            PatchPayloadData patchPayloadData = (PatchPayloadData)((WorkerState)e.Argument).Payload;
            string patchDirectory = Path.GetDirectoryName(patchPayloadData.OutputPath);
            ModJob basePatchModJob = GetBasePatchModJob(patchPayloadData);
            patchPayloadData.ModList.RemoveAt(0);

            List<ModJob> modJobList = ProcessModList(patchPayloadData).ToList(); //list

            Dictionary<Sha1, byte[]> modifiedRes = new Dictionary<Sha1, byte[]>(); //dictionary
            Dictionary<int, List<ChunkModResourceEntry>> modifiedBundles = new Dictionary<int, List<ChunkModResourceEntry>>(); //dictionary2

            List<int> bundlesToRemove = new List<int>(); //list2

            // get modified or deleted bundles from base patch
            foreach (ModBundle bundle in basePatchModJob.Meta.Bundles) {
                if (bundle.Action == "modify") {
                    int bundleKey = Utils.Hasher(bundle.Name.ToLower());
                    // get all bundle entries
                    List<ChunkModResourceEntry> bundleEntries = bundle.Entries.Select((ModBundleEntry modBundleEntry) => basePatchModJob.Meta.Resources[modBundleEntry.ResourceId]).ToList();
                    bundleEntries.Sort((ChunkModResourceEntry A, ChunkModResourceEntry B) => B.ChunkH32.CompareTo(A.ChunkH32));
                    modifiedBundles.Add(bundleKey, bundleEntries);
                } else if (bundle.Action == "remove") {
                    bundlesToRemove.Add(Utils.Hasher(bundle.Name.ToLower()));
                }
            }

            // process user mods
            foreach (ModJob modJob in modJobList) {

                // add modified resources from user mods
                foreach (ChunkModResourceEntry item in modJob.Meta.Resources.Where((ChunkModResourceEntry mre) => mre.ResourceID != -1 && mre.IsEnabled && mre.Action != "remove")) {
                    modifiedRes[new Sha1(item.OriginalSha1.ToSha1Bytes())] = modJob.Data[item.ResourceID];
                }
                // add modified bundles from user mods
                foreach (ModBundle mjBundle in modJob.Meta.Bundles) {
                    int mjBundleKey = Utils.Hasher(mjBundle.Name);
                    // if newly mentioned bundle,
                    // get only enabled resources
                    if (!modifiedBundles.ContainsKey(mjBundleKey)) {
                        modifiedBundles.Add(mjBundleKey, (from entry in mjBundle.Entries
                                               where modJob.Meta.Resources[entry.ResourceId].IsEnabled
                                               select entry into ent
                                               select modJob.Meta.Resources[ent.ResourceId]).ToList());
                        continue; 
                    }
                    // else, we already have bundle
                    foreach (ModBundleEntry entry in mjBundle.Entries) {
                        ChunkModResourceEntry modResourceEntry = modJob.Meta.Resources[entry.ResourceId];
                        if (!modResourceEntry.IsEnabled) {
                            continue;
                        }
                        int Hash = Utils.Hasher(modResourceEntry.Name + "_" + modResourceEntry.Action);
                        // check if we already have this resource action listen for this bundle, and warn if so
                        int index = modifiedBundles[mjBundleKey].FindIndex((ChunkModResourceEntry A) => Utils.Hasher(A.Name + "_" + A.Action) == Hash);
                        if (index != -1) {
                            // TODO: only returns first one found...
                            ModJob prevModJob = ModJobForResource(modJobList, modifiedBundles[mjBundleKey][index]);
                            if (prevModJob != null) {
                                WriteLogEntry_Threaded("*** Warning: " + modResourceEntry.Name + "from mod " + prevModJob.Name + " overridden by " + modJob.Name);
                            }
                            // reset to new version
                            modifiedBundles[mjBundleKey][index] = modResourceEntry;
                        } else {
                            // add modified version
                            modifiedBundles[mjBundleKey].Add(modResourceEntry);
                        }
                    }
                }
            }
            string basePatchDataPath = Settings.BasePath + "Update\\Patch\\Data\\";
            PrepareDirectory(patchDirectory, basePatchModJob, modifiedRes, basePatchDataPath, out var layoutToc);
            _bgWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Creating merged patch."));

            string win32PatchPath = basePatchDataPath + "Win32\\";
            DAIToc dAIToc;
            // Toc = Table of Contents
            if (File.Exists(win32PatchPath + "chunks0.toc")) {
                dAIToc = DAIToc.ReadFromFile(win32PatchPath + "chunks0.toc", 0L);
                if (!Directory.Exists(patchDirectory + "\\Data\\Win32")) {
                    Directory.CreateDirectory(patchDirectory + "\\Data\\Win32");
                }
                File.Copy(win32PatchPath + "chunks0.sb", patchDirectory + "\\Data\\Win32\\chunks0.sb");
            } else {
                dAIToc = new DAIToc();
                DAIEntry dAIEntry = new DAIEntry();
                dAIEntry.AddListValue("bundles", new List<DAIEntry>());
                dAIEntry.AddListValue("chunks", new List<DAIEntry>());
                dAIEntry.AddBoolValue("cas", Value: true);
                dAIToc.SetRootEntry(dAIEntry);
                DAIToc dAIToc2 = new DAIToc();
                DAIEntry dAIEntry2 = new DAIEntry();
                dAIEntry2.AddListValue("bundles", new List<DAIEntry>());
                dAIToc2.SetRootEntry(dAIEntry2);
                dAIToc2.WriteToFile(patchDirectory + "\\Data\\Win32\\chunks0.sb");
            }
            // add toc files if needed from base patch
            List<string> NewTocFileNames = new List<string>();
            basePatchModJob.Meta.Bundles.ForEach(delegate (ModBundle A) {
                if (!NewTocFileNames.Contains(A.TocFilename) && (A.Action == "add") && !File.Exists(Settings.BasePath + "\\Data\\Win32\\" + A.TocFilename)) {
                    NewTocFileNames.Add(A.TocFilename);
                }
            });

            foreach (string newTocFileName in NewTocFileNames) {
                int newFileHash = Utils.Hasher(newTocFileName.ToLower());
                // toc files contain many bundles
                List<ModBundle> bundlesInToc = basePatchModJob.Meta.Bundles.FindAll((ModBundle A) => A.TocFilename != null && Utils.Hasher(A.TocFilename.ToLower()) == newFileHash);
                DAIEntry tocBundlesMeta = new DAIEntry();
                tocBundlesMeta.AddListValue("bundles", new List<DAIEntry>());
                DAIEntry tocBundlesContent = new DAIEntry();
                tocBundlesContent.AddListValue("bundles", new List<DAIEntry>());
                foreach (ModBundle bundleInToc in bundlesInToc) {
                    DAIEntry bundleInTocContent = new DAIEntry();
                    bundleInTocContent.AddStringValue("path", bundleInToc.Name);
                    bundleInTocContent.AddDWordValue("magicSalt", (uint)bundleInToc.MagicSalt);
                    bundleInTocContent.AddListValue("ebx", new List<DAIEntry>());
                    bundleInTocContent.AddListValue("res", new List<DAIEntry>());
                    bundleInTocContent.AddBoolValue("alignMembers", bundleInToc.AlignMembers == 1);
                    bundleInTocContent.AddBoolValue("ridSupport", bundleInToc.RidSupport == 1);
                    bundleInTocContent.AddBoolValue("storeCompressedSizes", bundleInToc.StoreCompressedSizes == 1);
                    bundleInTocContent.AddQWordValue("totalSize", 0L);
                    bundleInTocContent.AddQWordValue("dbxTotalSize", 0L);

                    DAIEntry bundleInTocMeta = new DAIEntry();
                    bundleInTocMeta.AddStringValue("id", bundleInToc.Name);
                    bundleInTocMeta.AddQWordValue("offset", 0L);
                    bundleInTocMeta.AddDWordValue("size", 0u);

                    tocBundlesContent.GetListValue("bundles").Add(bundleInTocContent);
                    tocBundlesMeta.GetListValue("bundles").Add(bundleInTocMeta);

                    foreach (ModBundleEntry entry in bundleInToc.Entries) {
                        ChunkModResourceEntry entryMre = basePatchModJob.Meta.Resources[entry.ResourceId];
                        ChunkModResourceEntry.BuildDAIEntry(bundleInTocContent, entryMre);
                    }
                    int bundleInTocKey = Utils.Hasher(bundleInTocMeta.GetStringValue("id").ToLower());
                    // if already have bundle, move on
                    if (!modifiedBundles.ContainsKey(bundleInTocKey)) {
                        continue;
                    }
                    // 
                    foreach (ChunkModResourceEntry entryInBundleInToc in modifiedBundles[bundleInTocKey]) {
                        ChunkModResourceEntry EntryInBundleInToc = entryInBundleInToc;
                        if (EntryInBundleInToc.Action != "modify") {
                            continue;
                        }
                        DAIEntry prevDAIEntry = bundleInTocContent.GetListValue(EntryInBundleInToc.Type).Find((DAIEntry A) => A.GetSha1Value("sha1") == EntryInBundleInToc.OriginalSha1);
                        if (prevDAIEntry != null) {
                            ChunkModResourceEntry.ModifyResourceEntry(EntryInBundleInToc, prevDAIEntry);
                            continue;
                        }
                        ModJob prevModJob = ModJobForResource(modJobList, entryInBundleInToc);
                        if (prevModJob != null) {
                            WriteLogEntry_Threaded("*** Warning: " + entryInBundleInToc.Name + " not found for " + prevModJob.Name);
                        }
                    }
                }
                tocBundlesMeta.AddListValue("chunks", new List<DAIEntry>());
                tocBundlesMeta.AddBoolValue("cas", Value: true);
                tocBundlesMeta.AddStringValue("name", "Win32/" + newTocFileName.Replace(".toc", ""));
                tocBundlesMeta.AddBoolValue("alwaysEmitSuperbundle", Value: true);
                DAIToc newTocBundleContent = new DAIToc();
                newTocBundleContent.SetRootEntry(tocBundlesContent);
                newTocBundleContent.WriteToFile(patchDirectory + "\\Data\\Win32\\" + newTocFileName.Replace(".toc", ".sb"));
                DAIToc newTocBundleMeta = new DAIToc();
                newTocBundleMeta.SetRootEntry(tocBundlesMeta);
                for (int i = 0; i < tocBundlesMeta.GetListValue("bundles").Count; i++) {
                    DAIEntry tocBundlesMetaBundles = tocBundlesMeta.GetListValue("bundles")[i];
                    DAIEntry tocBundlesContentBundles = tocBundlesContent.GetListValue("bundles")[i];
                    tocBundlesMetaBundles.SetQWordValue("offset", tocBundlesContentBundles.EntryOffset);
                    tocBundlesMetaBundles.SetDWordValue("size", (uint)tocBundlesContentBundles.GetSize());
                }
                newTocBundleMeta.WriteToFile(patchDirectory + "\\Data\\Win32\\" + newTocFileName, bWriteTocHeader: true);
            }

            List<string> tocFiles = new List<string>();
            string win32Path = Settings.BasePath + "Data\\Win32";
            tocFiles.AddRange(Directory.GetFiles(win32Path, "*.toc", SearchOption.AllDirectories));

            int tocFileCount = 0;
            foreach (string tocFilename in tocFiles) {
                if (Settings.VerboseScan) {
                    WriteLogEntry_Threaded("[0] Merging " + tocFilename);
                }
                Dictionary<DAIEntry, DAIEntry> entryMap = new Dictionary<DAIEntry, DAIEntry>();

                _bgWorker.ReportProgress((int)((double)tocFileCount / (double)tocFiles.Count * 100.0), new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: false, tocFilename.Replace(win32Path + "\\", ""), ""));

                DAIToc tocFile = DAIToc.ReadFromFile(tocFilename, 0L);
                bool flag = false;
                using (LazyDisposable<BinaryReader> lazyDisposable = new LazyDisposable<BinaryReader>(() => new BinaryReader(FileHelpers.UnXorFile(tocFilename.Replace(".toc", ".sb"))))) {
                    foreach (DAIEntry tocFileBundle in tocFile.GetBundles()) {
                        tocFileBundle.AddBoolValue("base", Value: true);
                        DAIEntry value = null;
                        int tocFileBundleKey = Utils.Hasher(tocFileBundle.GetStringValue("id").ToLower());
                        if (bundlesToRemove.Contains(tocFileBundleKey)) {
                            flag = true;
                            continue;
                        }
                        if (modifiedBundles.ContainsKey(tocFileBundleKey)) {
                            tocFileBundle.RemoveField("base");
                            tocFileBundle.AddBoolValue("delta", Value: true);
                            value = DAIToc.ReadFromStream(lazyDisposable.Value, tocFileBundle.GetQWordValue("offset")).GetRootEntry();
                            flag = true;
                        }
                        entryMap.Add(tocFileBundle, value);
                    }
                }
                string actualFilename = tocFilename.Replace(Settings.BasePath + "Data\\Win32\\", "");
                foreach (ModBundle basePatchBundleAdded in basePatchModJob.Meta.Bundles.FindAll((ModBundle A) => A.Action == "add" && A.TocFilename.ToLower() == actualFilename.ToLower())) {
                    if (Settings.VerboseScan) {
                        WriteLogEntry_Threaded("[1] Adding bundle " + basePatchBundleAdded.Name);
                    }
                    DAIEntry bundleContent = new DAIEntry();
                    bundleContent.AddStringValue("path", basePatchBundleAdded.Name.ToLower());
                    bundleContent.AddDWordValue("magicSalt", (uint)basePatchBundleAdded.MagicSalt);
                    bundleContent.AddListValue("ebx", new List<DAIEntry>());
                    bundleContent.AddListValue("res", new List<DAIEntry>());
                    DAIEntry bundleMeta = new DAIEntry();
                    bundleMeta.AddStringValue("id", basePatchBundleAdded.Name.ToLower());
                    bundleMeta.AddQWordValue("offset", 0L);
                    bundleMeta.AddDWordValue("size", 0u);
                    bundleMeta.AddBoolValue("delta", Value: true);
                    entryMap.Add(bundleMeta, bundleContent);
                    foreach (ModBundleEntry basePatchBundleAddedEntry in basePatchBundleAdded.Entries) {
                        ModResourceEntry modResourceEntry3 = basePatchModJob.Meta.Resources[basePatchBundleAddedEntry.ResourceId];
                        ModResourceEntry.BuildDAIEntry(bundleContent, modResourceEntry3);
                        flag = true;
                    }
                    bundleContent.AddBoolValue("alignMembers", basePatchBundleAdded.AlignMembers == 1);
                    bundleContent.AddBoolValue("ridSupport", basePatchBundleAdded.RidSupport == 1);
                    bundleContent.AddBoolValue("storeCompressedSizes", basePatchBundleAdded.StoreCompressedSizes == 1);
                    bundleContent.AddQWordValue("totalSize", 0L);
                    bundleContent.AddQWordValue("dbxTotalSize", 0L);
                }
                foreach (DAIEntry bundleMeta in entryMap.Values) {
                    if (bundleMeta == null) {
                        continue;
                    }
                    if (Settings.VerboseScan) {
                        WriteLogEntry_Threaded("[1] Merging " + bundleMeta.GetStringValue("path"));
                    }
                    int bundleMetaKey = Utils.Hasher(bundleMeta.GetStringValue("path").ToLower());
                    if (!modifiedBundles.ContainsKey(bundleMetaKey)) {
                        continue;
                    }
                    foreach (ModResourceEntry bundleMetaRes in modifiedBundles[bundleMetaKey]) {
                        ModResourceEntry ResourceEntry = bundleMetaRes;
                        if (ResourceEntry.Action == "modify") {
                            DAIEntry dAIEntry12 = bundleMeta.GetListValue(ResourceEntry.Type).Find((DAIEntry A) => A.GetSha1Value("sha1") == ResourceEntry.OriginalSha1);
                            if (dAIEntry12 != null) {
                                ModResourceEntry.ModifyResourceEntry(bundleMetaRes, dAIEntry12);
                                continue;
                            }
                            ModJob prevModJob = ModJobForResource(modJobList, bundleMetaRes);
                            if (prevModJob != null) {
                                WriteLogEntry_Threaded("*** Warning: " + bundleMetaRes.Name + " not found for " + prevModJob.Name);
                            }
                        } else if (ResourceEntry.Action == "remove") {
                            string mreType = ((ResourceEntry.Type == "chunk") ? "chunks" : ResourceEntry.Type);
                            int index = bundleMeta.GetListValue(mreType).FindIndex((DAIEntry A) => A.GetSha1Value("sha1") == ResourceEntry.OriginalSha1);
                            if (index != -1) {
                                bundleMeta.GetListValue(mreType).RemoveAt(index);
                                if (mreType == "chunks") {
                                    bundleMeta.GetListValue("chunkMeta").RemoveAt(index);
                                }
                            }
                        } else {
                            ModResourceEntry.BuildDAIEntry(bundleMeta, ResourceEntry);
                        }
                    }
                }
                int num4;
                if (flag) {
                    foreach (KeyValuePair<DAIEntry, DAIEntry> entryMapPair in entryMap) {
                        DAIEntry bundleContent = entryMapPair.Value;
                        DAIEntry bundleMeta = entryMapPair.Key;
                        if (bundleContent != null) {
                            bundleContent.GetListValue("ebx").Sort((DAIEntry A, DAIEntry B) => A.GetStringValue("name").CompareTo(B.GetStringValue("name")));
                            bundleContent.GetListValue("res").Sort((DAIEntry A, DAIEntry B) => A.GetStringValue("name").CompareTo(B.GetStringValue("name")));
                            foreach (DAIEntry ebx in bundleContent.GetListValue("ebx")) {
                                if (ebx.HasField("idata")) {
                                    ebx.RemoveField("idata");
                                }
                            }
                            foreach (DAIEntry res in bundleContent.GetListValue("res")) {
                                if (res.HasField("idata")) {
                                    res.RemoveField("idata");
                                }
                            }
                            if (bundleContent.HasField("chunks")) {
                                foreach (DAIEntry chunk in bundleContent.GetListValue("chunks")) {
                                    if (chunk.HasField("idata")) {
                                        chunk.RemoveField("idata");
                                    }
                                }
                            }
                            if (bundleContent.HasField("chunkMeta")) {
                                foreach (DAIEntry chunkMeta in from A in bundleContent.GetListValue("chunkMeta")
                                                            where A.GetDWordValue("h32") == -1
                                                            select A) {
                                    bundleContent.GetListValue("chunkMeta").Remove(chunkMeta);
                                }
                            }
                            if (bundleContent.HasField("dbx")) {
                                bundleContent.RemoveField("dbx");
                            }
                            bundleContent.SetStringValue("path", bundleContent.GetStringValue("path").ToLower());
                        }
                        bundleMeta.SetStringValue("id", bundleMeta.GetStringValue("id").ToLower());
                    }
                    string tocActualFileName = tocFilename.Replace(Settings.BasePath, patchDirectory + "\\");
                    string filename = tocActualFileName.Replace(".toc", ".sb");
                    DAIEntry allBundleContents = new DAIEntry();
                    allBundleContents.AddListValue("bundles", new List<DAIEntry>());
                    foreach (DAIEntry bundleContent in entryMap.Values) {
                        if (bundleContent != null) {
                            allBundleContents.GetListValue("bundles").Add(bundleContent);
                        }
                    }
                    allBundleContents.GetListValue("bundles").Sort((DAIEntry A, DAIEntry B) => string.Compare(A.GetStringValue("path"), B.GetStringValue("path")));
                    DAIToc allBundleContentsToc = new DAIToc();
                    allBundleContentsToc.SetRootEntry(allBundleContents);
                    allBundleContentsToc.WriteToFile(filename);
                    DAIToc baseBundlesToc = new DAIToc();
                    DAIEntry baseBundles = new DAIEntry();
                    List<DAIEntry> bundleMetas = entryMap.Keys.Where((DAIEntry A) => A.HasField("base")).ToList();
                    List<DAIEntry> bundleMetaDeltas = entryMap.Keys.Where((DAIEntry A) => A.HasField("delta")).ToList();
                    bundleMetas.Sort((DAIEntry A, DAIEntry B) => string.Compare(A.GetStringValue("id"), B.GetStringValue("id")));
                    bundleMetaDeltas.Sort((DAIEntry A, DAIEntry B) => string.Compare(A.GetStringValue("id"), B.GetStringValue("id")));
                    bundleMetas.AddRange(bundleMetaDeltas);
                    baseBundles.AddListValue("bundles", bundleMetas);
                    baseBundles.AddListValue("chunks", new List<DAIEntry>());
                    baseBundles.AddBoolValue("cas", tocFile.GetRootEntry().GetBoolValue("cas"));
                    baseBundlesToc.SetRootEntry(baseBundles);
                    int index = 0;
                    for (int j = 0; j < entryMap.Count; j++) {
                        DAIEntry baseBundle = baseBundlesToc.GetBundles()[j];
                        if (baseBundle.HasField("delta")) {
                            DAIEntry dAIEntry16 = allBundleContentsToc.GetBundles()[index];
                            baseBundle.SetQWordValue("offset", dAIEntry16.EntryOffset);
                            baseBundle.SetDWordValue("size", (uint)dAIEntry16.GetSize());
                            index++;
                        }
                    }
                    baseBundlesToc.WriteToFile(tocActualFileName, bWriteTocHeader: true);
                }
                tocFileCount++;
                Sha1 LayoutNameHash = new Sha1(tocFilename.Replace(Settings.BasePath + "Data\\", "").Replace(".toc", "").Replace("\\", "/")
                    .ToLower().ToSha1Bytes());
                DAIEntry superBundle = layoutToc.GetRootEntry().GetListValue("superBundles").Find((DAIEntry A) => A.GetStringHashValue("name") == LayoutNameHash);
                if (superBundle?.HasField("same") ?? false) {
                    superBundle.RemoveField("same");
                    superBundle.AddBoolValue("delta", Value: true);
                }
            }
            layoutToc.GetRootEntry().RemoveField("fs");
            layoutToc.GetRootEntry().AddListValue("fs", new List<DAIEntry>());
            layoutToc.GetRootEntry().AddListStringChild("fs", "initfs_Win32");
            layoutToc.WriteToFile(patchDirectory + "\\Data\\layout.toc", bWriteTocHeader: true);
            dAIToc.WriteToFile(patchDirectory + "\\Data\\Win32\\chunks0.toc", bWriteTocHeader: true);
            StreamWriter streamWriter = new StreamWriter(patchDirectory + "\\package.mft");
            streamWriter.WriteLine("Name patch");
            streamWriter.WriteLine("Authoritative");
            streamWriter.WriteLine("Version " + (Settings.PatchVersion + 1));
            streamWriter.WriteLine("ModManager v0.60 alpha");
            streamWriter.Close();
        }

        private void WriteLogEntry(string LogText) {
            ProgressWin.StatusTextBox.AppendText("[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "] " + LogText + "\n");
            ProgressWin.StatusTextBox.ScrollToEnd();
        }

        private void WriteLogEntry_Threaded(string LogText) {
            ProgressWin.Dispatcher.BeginInvoke(DispatcherPriority.Input, (Action)delegate {
                WriteLogEntry(LogText);
            });
        }

        public ModJob GenerateModJobFromPatch(string version) {
            IndexedMultiMap<Sha1, ModResourceEntry> indexedMultiMap = new IndexedMultiMap<Sha1, ModResourceEntry>();
            List<ModBundle> list = new List<ModBundle>();
            List<string> list2 = new List<string>();
            if (File.Exists(Settings.BasePath + "Update\\Patch\\package.mft")) {
                _bgWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Processing official patch."));
                string text = Settings.BasePath + "Update\\Patch\\Data\\Win32";
                string[] files = Directory.GetFiles(text, "*.toc", SearchOption.AllDirectories);
                int num = 0;
                string[] array = files;
                foreach (string patchTocFileName in array) {
                    _bgWorker.ReportProgress((int)((double)num / (double)files.Length * 100.0), new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: false, patchTocFileName.Replace(Settings.BasePath, ""), ""));
                    num++;
                    if (Settings.VerboseScan) {
                        WriteLogEntry_Threaded("[0] Processing " + patchTocFileName);
                    }
                    DAIToc Toc = DAIToc.ReadFromFile(patchTocFileName, 0L);
                    if (!Toc.HasBundles()) {
                        continue;
                    }
                    string baseTocFileName = patchTocFileName.Replace(text, Settings.BasePath + "Data\\Win32");
                    DAIToc dAIToc = (File.Exists(baseTocFileName) ? DAIToc.ReadFromFile(baseTocFileName, 0L) : null);
                    if (dAIToc != null) {
                        foreach (DAIEntry item in dAIToc.GetBundles().FindAll((DAIEntry A) => Toc.GetBundles().Find((DAIEntry B) => A.GetStringHashValue("id") == B.GetStringHashValue("id")) == null)) {
                            list.Add(new ModBundle(item.GetStringValue("id"), "remove"));
                        }
                    }
                    using (LazyDisposable<BinaryReader> lazyDisposable = new LazyDisposable<BinaryReader>(() => new BinaryReader(FileHelpers.UnXorFile(patchTocFileName.Replace(".toc", ".sb"))))) {
                        using (LazyDisposable<BinaryReader> lazyDisposable2 = new LazyDisposable<BinaryReader>(() => new BinaryReader(FileHelpers.UnXorFile(baseTocFileName.Replace(".toc", ".sb"))))) {
                            if (lazyDisposable.Value.ReadByte() != 130) {
                                list2.Add(patchTocFileName.Replace(text + "\\", ""));
                                continue;
                            }
                            foreach (DAIEntry bundle in Toc.GetBundles()) {
                                if (bundle.HasField("base")) {
                                    continue;
                                }
                                bool flag = false;
                                if (bundle.HasField("delta")) {
                                    if (Settings.VerboseScan) {
                                        WriteLogEntry_Threaded("[1] Processing bundle " + bundle.GetStringValue("id"));
                                    }
                                    DAIEntry rootEntry = DAIToc.ReadFromStream(lazyDisposable.Value, bundle.GetQWordValue("offset")).GetRootEntry();
                                    Sha1 BundleHash = bundle.GetStringHashValue("id");
                                    DAIEntry dAIEntry = dAIToc?.GetBundles().Find((DAIEntry A) => A.GetStringHashValue("id") == BundleHash);
                                    if (dAIEntry != null) {
                                        ModBundle modBundle = new ModBundle(rootEntry.GetStringValue("path"), "modify");
                                        list.Add(modBundle);
                                        if (rootEntry.HasField("ebx") && File.Exists(baseTocFileName)) {
                                            DAIEntry rootEntry2 = DAIToc.ReadFromStream(lazyDisposable2.Value, dAIEntry.GetQWordValue("offset")).GetRootEntry();
                                            HashSet<Sha1> modBundleSet3 = new HashSet<Sha1>(from ent in rootEntry.GetListValue("ebx")
                                                                                            select ent.GetSha1Value("sha1"));
                                            HashSet<Sha1> baseBundleSet3 = new HashSet<Sha1>(from ent in rootEntry2.GetListValue("ebx")
                                                                                             select ent.GetSha1Value("sha1"));
                                            foreach (DAIEntry item2 in from ent in rootEntry2.GetListValue("ebx")
                                                                       where !modBundleSet3.Contains(ent.GetSha1Value("sha1"))
                                                                       select ent) {
                                                Sha1 sha1Value = item2.GetSha1Value("sha1");
                                                int num2 = indexedMultiMap.FindIndex(sha1Value, (ModResourceEntry A) => A.Action == "remove");
                                                if (num2 == -1) {
                                                    num2 = indexedMultiMap.Add(sha1Value, new ModResourceEntry(item2.GetStringValue("name"), "ebx", "remove") {
                                                        OriginalSha1 = sha1Value
                                                    });
                                                }
                                                modBundle.Entries.Add(new ModBundleEntry(num2));
                                            }
                                            foreach (DAIEntry daiEntry7 in from ent in rootEntry.GetListValue("ebx")
                                                                           where !baseBundleSet3.Contains(ent.GetSha1Value("sha1"))
                                                                           select ent) {
                                                int num3 = indexedMultiMap.FindIndex(daiEntry7.GetSha1Value("sha1"), (ModResourceEntry A) => A.Action == "add" && A.PatchType == (daiEntry7.HasField("casPatchType") ? daiEntry7.GetDWordValue("casPatchType") : 0));
                                                if (num3 == -1) {
                                                    ModResourceEntry modResourceEntry = new ModResourceEntry(daiEntry7.GetStringValue("name"), "ebx", "add");
                                                    modResourceEntry.Size = daiEntry7.GetQWordValue("size");
                                                    modResourceEntry.OriginalSize = daiEntry7.GetQWordValue("originalSize");
                                                    modResourceEntry.CopyPatchSha1(daiEntry7);
                                                    num3 = indexedMultiMap.Add(daiEntry7.GetSha1Value("sha1"), modResourceEntry);
                                                }
                                                modBundle.Entries.Add(new ModBundleEntry(num3));
                                            }
                                        }
                                        if (rootEntry.HasField("res") && File.Exists(baseTocFileName)) {
                                            DAIEntry rootEntry3 = DAIToc.ReadFromStream(lazyDisposable2.Value, dAIEntry.GetQWordValue("offset")).GetRootEntry();
                                            HashSet<Sha1> modBundleSet2 = new HashSet<Sha1>(from ent in rootEntry.GetListValue("res")
                                                                                            select ent.GetSha1Value("sha1"));
                                            HashSet<Sha1> baseBundleSet2 = new HashSet<Sha1>(from ent in rootEntry3.GetListValue("res")
                                                                                             select ent.GetSha1Value("sha1"));
                                            foreach (DAIEntry daiEntry6 in from ent in rootEntry3.GetListValue("res")
                                                                           where !modBundleSet2.Contains(ent.GetSha1Value("sha1"))
                                                                           select ent) {
                                                Sha1 sha1Value2 = daiEntry6.GetSha1Value("sha1");
                                                int num4 = indexedMultiMap.FindIndex(sha1Value2, (ModResourceEntry A) => A.Action == "remove" && A.Name == daiEntry6.GetStringValue("name"));
                                                if (num4 == -1) {
                                                    num4 = indexedMultiMap.Add(sha1Value2, new ModResourceEntry(daiEntry6.GetStringValue("name"), "res", "remove") {
                                                        OriginalSha1 = sha1Value2
                                                    });
                                                }
                                                modBundle.Entries.Add(new ModBundleEntry(num4));
                                            }
                                            foreach (DAIEntry daiEntry5 in from ent in rootEntry.GetListValue("res")
                                                                           where !baseBundleSet2.Contains(ent.GetSha1Value("sha1"))
                                                                           select ent) {
                                                Sha1 sha1Value3 = daiEntry5.GetSha1Value("sha1");
                                                int num5 = indexedMultiMap.FindIndex(sha1Value3, (ModResourceEntry A) => A.Action == "add" && A.Name == daiEntry5.GetStringValue("name") && A.PatchType == (daiEntry5.HasField("casPatchType") ? daiEntry5.GetDWordValue("casPatchType") : 0));
                                                if (num5 == -1) {
                                                    ModResourceEntry modResourceEntry2 = new ModResourceEntry(daiEntry5.GetStringValue("name"), "res", "add");
                                                    modResourceEntry2.Size = daiEntry5.GetQWordValue("size");
                                                    modResourceEntry2.OriginalSize = daiEntry5.GetQWordValue("originalSize");
                                                    modResourceEntry2.ResRid = daiEntry5.GetQWordValue("resRid");
                                                    modResourceEntry2.ResType = daiEntry5.GetDWordValue("resType");
                                                    modResourceEntry2.Meta = Util.MetaToString(daiEntry5.GetByteArrayValue("resMeta"));
                                                    modResourceEntry2.CopyPatchSha1(daiEntry5);
                                                    num5 = indexedMultiMap.Add(sha1Value3, modResourceEntry2);
                                                }
                                                modBundle.Entries.Add(new ModBundleEntry(num5));
                                            }
                                        }
                                        if (rootEntry.HasField("chunks") && File.Exists(baseTocFileName)) {
                                            DAIEntry rootEntry4 = DAIToc.ReadFromStream(lazyDisposable2.Value, dAIEntry.GetQWordValue("offset")).GetRootEntry();
                                            List<int> AddedCHUNK = new List<int>();
                                            if (rootEntry4.HasField("chunks")) {
                                                HashSet<DQWord> modBundleSet = new HashSet<DQWord>(from ent in rootEntry.GetListValue("chunks")
                                                                                                   select ent.GetDQWordValue("id"));
                                                foreach (DAIEntry daiEntry4 in from ent in rootEntry4.GetListValue("chunks")
                                                                               where !modBundleSet.Contains(ent.GetDQWordValue("id"))
                                                                               select ent) {
                                                    int num6 = indexedMultiMap.FindIndex(daiEntry4.GetSha1Value("sha1"), (ModResourceEntry A) => A.Action == "remove" && A.Name == daiEntry4.GetDQWordValue("id").ToString());
                                                    if (num6 == -1) {
                                                        num6 = indexedMultiMap.Add(daiEntry4.GetSha1Value("sha1"), new ModResourceEntry(daiEntry4.GetDQWordValue("id").ToString(), "chunk", "remove") {
                                                            OriginalSha1 = daiEntry4.GetSha1Value("sha1")
                                                        });
                                                    }
                                                    modBundle.Entries.Add(new ModBundleEntry(num6));
                                                }
                                                HashSet<DQWord> baseBundleSet = new HashSet<DQWord>(from ent in rootEntry4.GetListValue("chunks")
                                                                                                    select ent.GetDQWordValue("id"));
                                                int Idx = 0;
                                                rootEntry.GetListValue("chunks").ForEach(delegate (DAIEntry A) {
                                                    if (!baseBundleSet.Contains(A.GetDQWordValue("id"))) {
                                                        AddedCHUNK.Add(Idx);
                                                    }
                                                    Idx++;
                                                });
                                            }
                                            foreach (int item3 in AddedCHUNK) {
                                                DAIEntry daiEntry3 = rootEntry.GetListValue("chunks")[item3];
                                                DAIEntry dAIEntry2;
                                                if (item3 < rootEntry.GetListValue("chunkMeta").Count) {
                                                    dAIEntry2 = rootEntry.GetListValue("chunkMeta")[item3];
                                                } else {
                                                    dAIEntry2 = new DAIEntry();
                                                    dAIEntry2.AddDWordValue("h32", uint.MaxValue);
                                                    dAIEntry2.AddByteArrayValue("meta", new byte[1]);
                                                }
                                                int num7 = indexedMultiMap.FindIndex(daiEntry3.GetSha1Value("sha1"), (ModResourceEntry A) => A.Action == "add" && A.Name == daiEntry3.GetDQWordValue("id").ToString());
                                                if (num7 == -1) {
                                                    ModResourceEntry modResourceEntry3 = new ModResourceEntry(daiEntry3.GetDQWordValue("id").ToString(), "chunk", "add");
                                                    modResourceEntry3.Size = daiEntry3.GetDWordValue("size");
                                                    modResourceEntry3.CopyChunkFields(daiEntry3, dAIEntry2);
                                                    num7 = indexedMultiMap.Add(daiEntry3.GetSha1Value("sha1"), modResourceEntry3);
                                                }
                                                modBundle.Entries.Add(new ModBundleEntry(num7));
                                            }
                                        }
                                    } else {
                                        flag = true;
                                    }
                                } else {
                                    flag = true;
                                }
                                if (!flag) {
                                    continue;
                                }
                                if (Settings.VerboseScan) {
                                    WriteLogEntry_Threaded("[1] Processing bundle " + bundle.GetStringValue("id"));
                                }
                                DAIEntry rootEntry5 = DAIToc.ReadFromStream(lazyDisposable.Value, bundle.GetQWordValue("offset")).GetRootEntry();
                                ModBundle modBundle2 = new ModBundle(rootEntry5.GetStringValue("path"), "add");
                                modBundle2.TocFilename = patchTocFileName.Replace(text + "\\", "");
                                modBundle2.MagicSalt = rootEntry5.GetDWordValue("magicSalt");
                                modBundle2.AlignMembers = (byte)(rootEntry5.GetBoolValue("alignMembers") ? 1 : 0);
                                modBundle2.RidSupport = (byte)(rootEntry5.GetBoolValue("ridSupport") ? 1 : 0);
                                modBundle2.StoreCompressedSizes = (byte)(rootEntry5.GetBoolValue("storeCompressedSizes") ? 1 : 0);
                                list.Add(modBundle2);
                                if (rootEntry5.HasField("ebx")) {
                                    foreach (DAIEntry item4 in rootEntry5.GetListValue("ebx")) {
                                        DAIEntry Entry2 = item4;
                                        Sha1 sha1Value4 = Entry2.GetSha1Value("sha1");
                                        int num8 = indexedMultiMap.FindIndex(sha1Value4, (ModResourceEntry A) => A.Action == "add" && A.PatchType == (Entry2.HasField("casPatchType") ? Entry2.GetDWordValue("casPatchType") : 0));
                                        if (num8 == -1) {
                                            ModResourceEntry modResourceEntry4 = new ModResourceEntry(Entry2.GetStringValue("name"), "ebx", "add");
                                            modResourceEntry4.Size = Entry2.GetQWordValue("size");
                                            modResourceEntry4.OriginalSize = Entry2.GetQWordValue("originalSize");
                                            modResourceEntry4.CopyPatchSha1(Entry2);
                                            num8 = indexedMultiMap.Add(sha1Value4, modResourceEntry4);
                                        }
                                        modBundle2.Entries.Add(new ModBundleEntry(num8));
                                    }
                                }
                                if (rootEntry5.HasField("res")) {
                                    foreach (DAIEntry daiEntry2 in rootEntry5.GetListValue("res")) {
                                        Sha1 sha1Value5 = daiEntry2.GetSha1Value("sha1");
                                        int num9 = indexedMultiMap.FindIndex(sha1Value5, (ModResourceEntry A) => A.Action == "add" && A.Name == daiEntry2.GetStringValue("name") && A.PatchType == (daiEntry2.HasField("casPatchType") ? daiEntry2.GetDWordValue("casPatchType") : 0));
                                        if (num9 == -1) {
                                            ModResourceEntry modResourceEntry5 = new ModResourceEntry(daiEntry2.GetStringValue("name"), "res", "add");
                                            modResourceEntry5.CopyPatchSha1(daiEntry2);
                                            modResourceEntry5.Size = daiEntry2.GetQWordValue("size");
                                            modResourceEntry5.OriginalSize = daiEntry2.GetQWordValue("originalSize");
                                            modResourceEntry5.ResRid = daiEntry2.GetQWordValue("resRid");
                                            modResourceEntry5.ResType = daiEntry2.GetDWordValue("resType");
                                            modResourceEntry5.Meta = Util.MetaToString(daiEntry2.GetByteArrayValue("resMeta"));
                                            num9 = indexedMultiMap.Add(sha1Value5, modResourceEntry5);
                                        }
                                        modBundle2.Entries.Add(new ModBundleEntry(num9));
                                    }
                                }
                                if (!rootEntry5.HasField("chunks")) {
                                    continue;
                                }
                                int num10 = 0;
                                while (num10 < rootEntry5.GetListValue("chunks").Count) {
                                    DAIEntry Entry = rootEntry5.GetListValue("chunks")[num10];
                                    Sha1 sha1Value6 = Entry.GetSha1Value("sha1");
                                    DAIEntry chunkMetaEntry = rootEntry5.GetListValue("chunkMeta")[num10];
                                    int num11 = indexedMultiMap.FindIndex(sha1Value6, (ModResourceEntry A) => A.Action == "add" && A.Name == Entry.GetDQWordValue("id").ToString());
                                    if (num11 == -1) {
                                        ModResourceEntry modResourceEntry6 = new ModResourceEntry(Entry.GetDQWordValue("id").ToString(), "chunk", "add");
                                        modResourceEntry6.Size = Entry.GetDWordValue("size");
                                        modResourceEntry6.CopyChunkFields(Entry, chunkMetaEntry);
                                        num11 = indexedMultiMap.Add(sha1Value6, modResourceEntry6);
                                    }
                                    modBundle2.Entries.Add(new ModBundleEntry(num11));
                                    int num12 = num10 + 1;
                                    num10 = num12;
                                }
                            }
                        }
                    }
                }
            }
            ModJob modJob = new ModJob("Official Patch", "", "");
            modJob.Meta = new ModMetaData(1, "", 0, new ModDetail("Official Patch", version, "Bioware", ""));
            modJob.Meta.Resources = indexedMultiMap.ToList();
            modJob.Meta.Bundles = list;
            modJob.Meta.CopyFiles = list2;
            modJob.Save(Directory.GetCurrentDirectory() + "\\Patch.daimod");
            Settings.RescanPatch = false;
            return modJob;
        }

        public ModJob GenerateModJobFromDistPatch(ModContainer ModCont) {
            ModJob modJob = new ModJob(ModCont.Name, "", "");
            modJob.Meta = new ModMetaData(1, "", 0, new ModDetail(ModCont.Name, "", "", ""));
            _bgWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Processing distributable patch \"" + ModCont.Name + "\""));
            Dictionary<Sha1, DAICatEntry> dictionary = DAICat.SerializeLocal(ModCont.Path + "\\Data\\cas.cat");
            string[] files = Directory.GetFiles(ModCont.Path + "\\Data\\Win32", "*.toc", SearchOption.AllDirectories);
            int num = 0;
            string[] array = files;
            foreach (string Filename1 in array) {
                _bgWorker.ReportProgress((int)((double)num / (double)files.Length * 100.0), new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: false, Filename1.Replace(ModCont.Path + "\\Data\\Win32\\", ""), ""));
                DAIToc dAIToc = DAIToc.ReadFromFile(Filename1, 0L);
                string Filename2 = Filename1.Replace(ModCont.Path + "\\", Settings.BasePath);
                if (dAIToc.HasBundles()) {
                    using (LazyDisposable<BinaryReader> lazyDisposable = new LazyDisposable<BinaryReader>(() => new BinaryReader(Util.UnXorFile(Filename1.Replace(".toc", ".sb"))))) {
                        using (LazyDisposable<BinaryReader> lazyDisposable2 = new LazyDisposable<BinaryReader>(() => new BinaryReader(Util.UnXorFile(Filename2.Replace(".toc", ".sb"))))) {
                            foreach (DAIEntry bundle in dAIToc.GetBundles()) {
                                if (bundle.HasField("base") || !bundle.HasField("delta")) {
                                    continue;
                                }
                                DAIEntry rootEntry = DAIToc.ReadFromStream(lazyDisposable.Value, bundle.GetQWordValue("offset")).GetRootEntry();
                                Sha1 BundleHash = bundle.GetStringHashValue("id");
                                ModBundle modBundle = new ModBundle(rootEntry.GetStringValue("path"), "modify");
                                modJob.Meta.Bundles.Add(modBundle);
                                DAIEntry dAIEntry = DAIToc.ReadFromFile(Filename2, 0L).GetBundles().Find((DAIEntry A) => A.GetStringHashValue("id") == BundleHash);
                                DAIEntry rootEntry2 = DAIToc.ReadFromStream(lazyDisposable2.Value, dAIEntry.GetQWordValue("offset")).GetRootEntry();
                                if (rootEntry.HasField("ebx")) {
                                    ILookup<Sha1, DAIEntry> baseBundleSet3 = rootEntry2.GetListValue("ebx").ToLookup((DAIEntry ent) => ent.GetStringHashValue("name"));
                                    foreach (DAIEntry item in from ent in rootEntry.GetListValue("ebx")
                                                              where !baseBundleSet3[ent.GetStringHashValue("name")].Any((DAIEntry ent2) => ent.GetSha1Value("sha1") == ent2.GetSha1Value("sha1"))
                                                              select ent) {
                                        DAIEntry dAIEntry2 = item;
                                        DAIEntry FoundEntry2 = baseBundleSet3[item.GetStringHashValue("name")].FirstOrDefault();
                                        if (FoundEntry2 != null) {
                                            int num2 = modJob.Meta.Resources.FindIndex((ModResourceEntry A) => A.OriginalSha1 == FoundEntry2.GetSha1Value("sha1") && A.Action == "modify");
                                            if (num2 == -1) {
                                                ModResourceEntry modResourceEntry = new ModResourceEntry(dAIEntry2.GetStringValue("name"), "ebx", "modify");
                                                modJob.Meta.Resources.Add(modResourceEntry);
                                                modResourceEntry.Size = dAIEntry2.GetQWordValue("size");
                                                modResourceEntry.OriginalSize = dAIEntry2.GetQWordValue("originalSize");
                                                modResourceEntry.PatchType = 1;
                                                modResourceEntry.OriginalSha1 = FoundEntry2.GetSha1Value("sha1");
                                                num2 = modJob.Meta.Resources.Count - 1;
                                                DAICatEntry dAICatEntry = dictionary[dAIEntry2.GetSha1Value("sha1")];
                                                modJob.Data.Add(DAICat.Get().GetCompressedPayloadFromFile(dAICatEntry.Path, dAICatEntry.Offset, dAICatEntry.Size).ToArray());
                                                modResourceEntry.ResourceID = modJob.Data.Count - 1;
                                                modResourceEntry.NewSha1 = Util.CalculateSha1(modJob.Data[modResourceEntry.ResourceID]);
                                            }
                                            modBundle.Entries.Add(new ModBundleEntry(num2));
                                        }
                                    }
                                }
                                if (rootEntry.HasField("res")) {
                                    ILookup<Sha1, DAIEntry> baseBundleSet2 = rootEntry2.GetListValue("res").ToLookup((DAIEntry ent) => ent.GetStringHashValue("name"));
                                    foreach (DAIEntry item2 in from ent in rootEntry.GetListValue("res")
                                                               where !baseBundleSet2[ent.GetStringHashValue("name")].Any((DAIEntry ent2) => ent.GetSha1Value("sha1") == ent2.GetSha1Value("sha1"))
                                                               select ent) {
                                        DAIEntry dAIEntry3 = item2;
                                        DAIEntry FoundEntry = baseBundleSet2[item2.GetStringHashValue("name")].FirstOrDefault();
                                        if (FoundEntry != null) {
                                            int num3 = modJob.Meta.Resources.FindIndex((ModResourceEntry A) => A.OriginalSha1 == FoundEntry.GetSha1Value("sha1") && A.Action == "modify");
                                            if (num3 == -1) {
                                                ModResourceEntry modResourceEntry2 = new ModResourceEntry(dAIEntry3.GetStringValue("name"), "res", "modify");
                                                modJob.Meta.Resources.Add(modResourceEntry2);
                                                modResourceEntry2.Size = dAIEntry3.GetQWordValue("size");
                                                modResourceEntry2.OriginalSize = dAIEntry3.GetQWordValue("originalSize");
                                                modResourceEntry2.ResRid = dAIEntry3.GetQWordValue("resRid");
                                                modResourceEntry2.ResType = dAIEntry3.GetDWordValue("resType");
                                                modResourceEntry2.Meta = Util.MetaToString(dAIEntry3.GetByteArrayValue("resMeta"));
                                                modResourceEntry2.PatchType = 1;
                                                modResourceEntry2.OriginalSha1 = FoundEntry.GetSha1Value("sha1");
                                                num3 = modJob.Meta.Resources.Count - 1;
                                                DAICatEntry dAICatEntry2 = dictionary[dAIEntry3.GetSha1Value("sha1")];
                                                modJob.Data.Add(DAICat.Get().GetCompressedPayloadFromFile(dAICatEntry2.Path, dAICatEntry2.Offset, dAICatEntry2.Size).ToArray());
                                                modResourceEntry2.ResourceID = modJob.Data.Count - 1;
                                                modResourceEntry2.NewSha1 = Util.CalculateSha1(modJob.Data[modResourceEntry2.ResourceID]);
                                            }
                                            modBundle.Entries.Add(new ModBundleEntry(num3));
                                        }
                                    }
                                }
                                if (!rootEntry.HasField("chunks")) {
                                    continue;
                                }
                                List<int> AddedCHUNK = new List<int>();
                                if (rootEntry2.HasField("chunks")) {
                                    HashSet<DQWord> baseBundleSet = new HashSet<DQWord>(from ent in rootEntry2.GetListValue("chunks")
                                                                                        select ent.GetDQWordValue("id"));
                                    int Idx = 0;
                                    rootEntry.GetListValue("chunks").ForEach(delegate (DAIEntry A) {
                                        if (!baseBundleSet.Contains(A.GetDQWordValue("id"))) {
                                            AddedCHUNK.Add(Idx);
                                        }
                                        Idx++;
                                    });
                                }
                                foreach (int item3 in AddedCHUNK) {
                                    DAIEntry Entry = rootEntry.GetListValue("chunks")[item3];
                                    DAIEntry dAIEntry4 = rootEntry.GetListValue("chunkMeta")[item3];
                                    int num4 = modJob.Meta.Resources.FindIndex((ModResourceEntry A) => A.OriginalSha1 == Entry.GetSha1Value("sha1") && A.Action == "add");
                                    if (num4 == -1) {
                                        if (!dictionary.ContainsKey(Entry.GetSha1Value("sha1"))) {
                                            continue;
                                        }
                                        ModResourceEntry modResourceEntry3 = new ModResourceEntry(Entry.GetDQWordValue("id").ToString(), "chunk", "add");
                                        modJob.Meta.Resources.Add(modResourceEntry3);
                                        modResourceEntry3.ChunkH32 = dAIEntry4.GetDWordValue("h32");
                                        modResourceEntry3.OriginalSha1 = Entry.GetSha1Value("sha1");
                                        modResourceEntry3.PatchType = 1;
                                        num4 = modJob.Meta.Resources.Count - 1;
                                        DAICatEntry dAICatEntry3 = dictionary[Entry.GetSha1Value("sha1")];
                                        byte[] array2 = Util.DecompressData(DAICat.Get().GetCompressedPayloadFromFile(dAICatEntry3.Path, dAICatEntry3.Offset, dAICatEntry3.Size).ToArray());
                                        ImportCompressData ImportResults = new ImportCompressData();
                                        byte[] array3 = Util.CompressData(array2, ref ImportResults);
                                        if (Entry.HasField("rangeStart")) {
                                            modResourceEntry3.RangeStart = ImportResults.RangeStart;
                                            modResourceEntry3.RangeEnd = ImportResults.RangeEnd;
                                            modResourceEntry3.Meta = "0866697273744D6970000000000000";
                                        }
                                        modResourceEntry3.LogicalOffset = 0;
                                        modResourceEntry3.LogicalSize = array2.Length;
                                        modResourceEntry3.Size = array3.Length;
                                        modJob.Data.Add(array3);
                                        modResourceEntry3.ResourceID = modJob.Data.Count - 1;
                                    }
                                    modBundle.Entries.Add(new ModBundleEntry(num4));
                                }
                            }
                        }
                    }
                }
                int num5 = num + 1;
                num = num5;
            }
            return modJob;
        }

        public IEnumerable<ModJob> ProcessModList(PatchPayloadData patchPayloadData) {
            return patchPayloadData.ModList.Select(delegate (ModContainer ModCont) {
                if (!ModCont.IsDAIMod()) {
                    return GenerateModJobFromDistPatch(ModCont);
                }
                _bgWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Processing DAI mod \"" + ModCont.Name + "\""));
                if (ModCont.Mod.ScriptObject != null) {
                    Scripting.CurrentMod = ModCont.Mod;
                    ModCont.Mod.ScriptObject.RunScript();
                }
                return ModCont.Mod;
            });
        }

        public ModJob GetBasePatchModJob(PatchPayloadData patchPayloadData) {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\patch.daimod") || Settings.RescanPatch) {
                return GenerateModJobFromPatch(patchPayloadData.ModList[0].Version);
            }
            _bgWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Loading official patch."));
            return ModJob.CreateFromFile(Directory.GetCurrentDirectory() + "\\patch.daimod");
        }

        public void PrepareDirectory(string directoryName, ModJob basePatchModJob, Dictionary<Sha1, byte[]> modResources, string patchDataPath, out DAIToc layoutToc) {
            if (Directory.Exists(directoryName + "\\Data")) {
                Directory.Delete(directoryName + "\\Data", recursive: true);
            }
            _bgWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Creating cas files."));
            string text = "";
            if (File.Exists(patchDataPath + "cas.cat")) {
                Directory.CreateDirectory(directoryName + "\\Data");
                File.Copy(patchDataPath + "cas.cat", directoryName + "\\Data\\cas.cat");
                File.Copy(patchDataPath + "initfs_Win32", directoryName + "\\Data\\initfs_Win32");
                string[] files = Directory.GetFiles(patchDataPath, "*.cas");
                foreach (string text2 in files) {
                    File.Copy(text2, directoryName + "\\Data\\" + text2.Remove(0, text2.LastIndexOf('\\') + 1));
                    text = text2.Remove(0, text2.LastIndexOf('\\') + 1);
                }
            }
            Directory.CreateDirectory(directoryName + "\\Data\\Win32\\Loc");
            string[] files2 = Directory.GetFiles(patchDataPath + "\\Win32\\Loc");
            foreach (string text3 in files2) {
                File.Copy(text3, directoryName + "\\Data\\Win32\\Loc\\" + text3.Remove(0, text3.LastIndexOf('\\') + 1));
            }
            foreach (string copyFile in basePatchModJob.Meta.CopyFiles) {
                string text4 = directoryName + "\\Data\\Win32\\" + copyFile;
                string text5 = patchDataPath + "Win32\\" + copyFile;
                Directory.CreateDirectory(Path.GetDirectoryName(text4));
                if (!File.Exists(text4)) {
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
            foreach (KeyValuePair<Sha1, byte[]> modResource in modResources) {
                if (binaryWriter.BaseStream.Position + modResource.Value.Length + 32 > 1073741824) {
                    binaryWriter.Flush();
                    binaryWriter.Close();
                    int num2 = num + 1;
                    num = num2;
                    binaryWriter = new BinaryWriter(new FileStream(directoryName + "\\Data\\cas_" + num.ToString("D2") + ".cas", FileMode.Create));
                }
                Sha1 value = Util.CalculateSha1(modResource.Value);
                binaryWriter.Write(new byte[4] { 250, 206, 15, 240 });
                binaryWriter.Write(value);
                binaryWriter.Write((long)modResource.Value.Length);
                binaryWriter2.Write(value);
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

        public ModJob ModJobForResource(IEnumerable<ModJob> modJobs, ModResourceEntry entry) {
            foreach (ModJob modJob in modJobs) {
                if (modJob.Meta.Resources.Contains(entry)) {
                    return modJob;
                }
            }
            return null;
        }

        public bool CheckBasePatch() {
            if (DAIMft.SerializeFromFile(Settings.BasePath + "Update\\Patch\\package.mft").HasKey("ModManager")) {
                return false;
            }
            DAIToc dAIToc = DAIToc.ReadFromFile(Settings.BasePath + "Update\\Patch\\Data\\Win32\\globals.toc", 0L);
            IEnumerable<string> enumerable = from b in dAIToc.GetBundles()
                                             where b.HasField("base")
                                             select b.GetStringValue("id");
            return enumerable.SequenceEqual(enumerable.OrderBy((string id) => id));
        }

    }
}
