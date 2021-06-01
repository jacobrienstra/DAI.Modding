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

using DAI.Mod;
using DAI.ModManager.Frostbite;
using DAI.ModManager.Utils;

namespace DAI.ModManager {
    public partial class MainWindow : Window, IComponentConnector {
        public BackgroundWorker BGWorker;

        private ProgressWindow ProgressWin;

        private const string PatchBasePath = "Update\\Patch\\";

        private const string Version = "v0.60 alpha";

        public bool Cancelled { get; set; }

        public MainWindow() {
            InitializeComponent();
            Cancelled = true;
            BGWorker = new BackgroundWorker();
            BGWorker.WorkerReportsProgress = true;
            BGWorker.WorkerSupportsCancellation = true;
            BGWorker.DoWork += BGWorker_DoWork;
            BGWorker.RunWorkerCompleted += BGWorker_RunWorkerCompleted;
            BGWorker.ProgressChanged += BGWorker_ProgressChanged;
            base.Title = "Mod Manager v0.60 alpha";
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

        private ModJob GenerateModJobFromPatch(string version) {
            IndexedMultiMap<Sha1, ModResourceEntry> indexedMultiMap = new IndexedMultiMap<Sha1, ModResourceEntry>();
            List<ModBundle> list = new List<ModBundle>();
            List<string> list2 = new List<string>();
            if (File.Exists(Settings.BasePath + "Update\\Patch\\package.mft")) {
                BGWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Processing official patch."));
                string text = Settings.BasePath + "Update\\Patch\\Data\\Win32";
                string[] files = Directory.GetFiles(text, "*.toc", SearchOption.AllDirectories);
                int num = 0;
                string[] array = files;
                foreach (string patchTocFileName in array) {
                    BGWorker.ReportProgress((int)((double)num / (double)files.Length * 100.0), new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: false, patchTocFileName.Replace(Settings.BasePath, ""), ""));
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
                    using (LazyDisposable<BinaryReader> lazyDisposable = new LazyDisposable<BinaryReader>(() => new BinaryReader(Util.UnXorFile(patchTocFileName.Replace(".toc", ".sb"))))) {
                        using (LazyDisposable<BinaryReader> lazyDisposable2 = new LazyDisposable<BinaryReader>(() => new BinaryReader(Util.UnXorFile(baseTocFileName.Replace(".toc", ".sb"))))) {
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

        private ModJob GenerateModJobFromDistPatch(ModContainer ModCont) {
            ModJob modJob = new ModJob(ModCont.Name, "", "");
            modJob.Meta = new ModMetaData(1, "", 0, new ModDetail(ModCont.Name, "", "", ""));
            BGWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Processing distributable patch \"" + ModCont.Name + "\""));
            Dictionary<Sha1, DAICatEntry> dictionary = DAICat.SerializeLocal(ModCont.Path + "\\Data\\cas.cat");
            string[] files = Directory.GetFiles(ModCont.Path + "\\Data\\Win32", "*.toc", SearchOption.AllDirectories);
            int num = 0;
            string[] array = files;
            foreach (string Filename1 in array) {
                BGWorker.ReportProgress((int)((double)num / (double)files.Length * 100.0), new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: false, Filename1.Replace(ModCont.Path + "\\Data\\Win32\\", ""), ""));
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

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e) {
            PatchPayloadData patchPayloadData = (PatchPayloadData)((WorkerState)e.Argument).Payload;
            string directoryName = Path.GetDirectoryName(patchPayloadData.OutputPath);
            ModJob basePatchModJob = GetBasePatchModJob(patchPayloadData);
            patchPayloadData.ModList.RemoveAt(0);
            List<ModJob> list = ProcessModList(patchPayloadData).ToList();
            Dictionary<Sha1, byte[]> dictionary = new Dictionary<Sha1, byte[]>();
            Dictionary<int, List<ModResourceEntry>> dictionary2 = new Dictionary<int, List<ModResourceEntry>>();
            List<int> list2 = new List<int>();
            foreach (ModBundle bundle in basePatchModJob.Meta.Bundles) {
                if (bundle.Action == "modify") {
                    int key = Util.Hasher(bundle.Name.ToLower());
                    List<ModResourceEntry> list3 = bundle.Entries.Select((ModBundleEntry modBundleEntry) => basePatchModJob.Meta.Resources[modBundleEntry.ResourceId]).ToList();
                    list3.Sort((ModResourceEntry A, ModResourceEntry B) => B.ChunkH32.CompareTo(A.ChunkH32));
                    dictionary2.Add(key, list3);
                } else if (bundle.Action == "remove") {
                    list2.Add(Util.Hasher(bundle.Name.ToLower()));
                }
            }
            foreach (ModJob modJob in list) {
                foreach (ModResourceEntry item in modJob.Meta.Resources.Where((ModResourceEntry mre) => mre.ResourceID != -1 && mre.IsEnabled && mre.Action != "remove")) {
                    dictionary[item.OriginalSha1] = modJob.Data[item.ResourceID];
                }
                foreach (ModBundle bundle2 in modJob.Meta.Bundles) {
                    int key2 = Util.Hasher(bundle2.Name);
                    if (!dictionary2.ContainsKey(key2)) {
                        dictionary2.Add(key2, (from entry in bundle2.Entries
                                               where modJob.Meta.Resources[entry.ResourceId].IsEnabled
                                               select entry into ent
                                               select modJob.Meta.Resources[ent.ResourceId]).ToList());
                        continue;
                    }
                    foreach (ModBundleEntry entry in bundle2.Entries) {
                        ModResourceEntry modResourceEntry = modJob.Meta.Resources[entry.ResourceId];
                        if (!modResourceEntry.IsEnabled) {
                            continue;
                        }
                        int Hash = Util.Hasher(modResourceEntry.Name + "_" + modResourceEntry.Action);
                        int num = dictionary2[key2].FindIndex((ModResourceEntry A) => Util.Hasher(A.Name + "_" + A.Action) == Hash);
                        if (num != -1) {
                            ModJob modJob2 = ModJobForResource(list, dictionary2[key2][num]);
                            if (modJob2 != null) {
                                WriteLogEntry_Threaded("*** Warning: " + modResourceEntry.Name + "from mod " + modJob2.Name + " overridden by " + modJob.Name);
                            }
                            dictionary2[key2][num] = modResourceEntry;
                        } else {
                            dictionary2[key2].Add(modResourceEntry);
                        }
                    }
                }
            }
            string text = Settings.BasePath + "Update\\Patch\\Data\\";
            PrepareDirectory(directoryName, basePatchModJob, dictionary, text, out var layoutToc);
            int num2 = 0;
            BGWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Creating merged patch."));
            string text2 = text + "Win32\\";
            DAIToc dAIToc;
            if (File.Exists(text2 + "chunks0.toc")) {
                dAIToc = DAIToc.ReadFromFile(text2 + "chunks0.toc", 0L);
                if (!Directory.Exists(directoryName + "\\Data\\Win32")) {
                    Directory.CreateDirectory(directoryName + "\\Data\\Win32");
                }
                File.Copy(text2 + "chunks0.sb", directoryName + "\\Data\\Win32\\chunks0.sb");
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
                dAIToc2.WriteToFile(directoryName + "\\Data\\Win32\\chunks0.sb");
            }
            List<string> NewFileList = new List<string>();
            basePatchModJob.Meta.Bundles.ForEach(delegate (ModBundle A) {
                if (!NewFileList.Contains(A.TocFilename) && !(A.Action != "add") && !File.Exists(Settings.BasePath + "\\Data\\Win32\\" + A.TocFilename)) {
                    NewFileList.Add(A.TocFilename);
                }
            });
            foreach (string item2 in NewFileList) {
                int FilenameHash = Util.Hasher(item2.ToLower());
                List<ModBundle> list4 = basePatchModJob.Meta.Bundles.FindAll((ModBundle A) => A.TocFilename != null && Util.Hasher(A.TocFilename.ToLower()) == FilenameHash);
                DAIEntry dAIEntry3 = new DAIEntry();
                dAIEntry3.AddListValue("bundles", new List<DAIEntry>());
                DAIEntry dAIEntry4 = new DAIEntry();
                dAIEntry4.AddListValue("bundles", new List<DAIEntry>());
                foreach (ModBundle item3 in list4) {
                    DAIEntry dAIEntry5 = new DAIEntry();
                    dAIEntry5.AddStringValue("path", item3.Name);
                    dAIEntry5.AddDWordValue("magicSalt", (uint)item3.MagicSalt);
                    dAIEntry5.AddListValue("ebx", new List<DAIEntry>());
                    dAIEntry5.AddListValue("res", new List<DAIEntry>());
                    dAIEntry5.AddBoolValue("alignMembers", item3.AlignMembers == 1);
                    dAIEntry5.AddBoolValue("ridSupport", item3.RidSupport == 1);
                    dAIEntry5.AddBoolValue("storeCompressedSizes", item3.StoreCompressedSizes == 1);
                    dAIEntry5.AddQWordValue("totalSize", 0L);
                    dAIEntry5.AddQWordValue("dbxTotalSize", 0L);
                    DAIEntry dAIEntry6 = new DAIEntry();
                    dAIEntry6.AddStringValue("id", item3.Name);
                    dAIEntry6.AddQWordValue("offset", 0L);
                    dAIEntry6.AddDWordValue("size", 0u);
                    dAIEntry4.GetListValue("bundles").Add(dAIEntry5);
                    dAIEntry3.GetListValue("bundles").Add(dAIEntry6);
                    foreach (ModBundleEntry entry2 in item3.Entries) {
                        ModResourceEntry modResourceEntry2 = basePatchModJob.Meta.Resources[entry2.ResourceId];
                        ModResourceEntry.BuildDAIEntry(dAIEntry5, modResourceEntry2);
                    }
                    int key3 = Util.Hasher(dAIEntry6.GetStringValue("id").ToLower());
                    if (!dictionary2.ContainsKey(key3)) {
                        continue;
                    }
                    foreach (ModResourceEntry item4 in dictionary2[key3]) {
                        ModResourceEntry BundleEntry = item4;
                        if (!(BundleEntry.Action == "modify")) {
                            continue;
                        }
                        DAIEntry dAIEntry7 = dAIEntry5.GetListValue(BundleEntry.Type).Find((DAIEntry A) => A.GetSha1Value("sha1") == BundleEntry.OriginalSha1);
                        if (dAIEntry7 != null) {
                            ModResourceEntry.ModifyResourceEntry(BundleEntry, dAIEntry7);
                            continue;
                        }
                        ModJob modJob3 = ModJobForResource(list, item4);
                        if (modJob3 != null) {
                            WriteLogEntry_Threaded("*** Warning: " + item4.Name + " not found for " + modJob3.Name);
                        }
                    }
                }
                dAIEntry3.AddListValue("chunks", new List<DAIEntry>());
                dAIEntry3.AddBoolValue("cas", Value: true);
                dAIEntry3.AddStringValue("name", "Win32/" + item2.Replace(".toc", ""));
                dAIEntry3.AddBoolValue("alwaysEmitSuperbundle", Value: true);
                DAIToc dAIToc3 = new DAIToc();
                dAIToc3.SetRootEntry(dAIEntry4);
                dAIToc3.WriteToFile(directoryName + "\\Data\\Win32\\" + item2.Replace(".toc", ".sb"));
                DAIToc dAIToc4 = new DAIToc();
                dAIToc4.SetRootEntry(dAIEntry3);
                int num3 = 0;
                while (num3 < dAIEntry3.GetListValue("bundles").Count) {
                    DAIEntry dAIEntry8 = dAIEntry3.GetListValue("bundles")[num3];
                    DAIEntry dAIEntry9 = dAIEntry4.GetListValue("bundles")[num3];
                    dAIEntry8.SetQWordValue("offset", dAIEntry9.EntryOffset);
                    dAIEntry8.SetDWordValue("size", (uint)dAIEntry9.GetSize());
                    int num4 = num3 + 1;
                    num3 = num4;
                }
                dAIToc4.WriteToFile(directoryName + "\\Data\\Win32\\" + item2, bWriteTocHeader: true);
            }
            List<string> list5 = new List<string>();
            string text3 = Settings.BasePath + "Data\\Win32";
            list5.AddRange(Directory.GetFiles(text3, "*.toc", SearchOption.AllDirectories));
            foreach (string tocFilename in list5) {
                if (Settings.VerboseScan) {
                    WriteLogEntry_Threaded("[0] Merging " + tocFilename);
                }
                Dictionary<DAIEntry, DAIEntry> dictionary3 = new Dictionary<DAIEntry, DAIEntry>();
                BGWorker.ReportProgress((int)((double)num2 / (double)list5.Count * 100.0), new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: false, tocFilename.Replace(text3 + "\\", ""), ""));
                DAIToc dAIToc5 = DAIToc.ReadFromFile(tocFilename, 0L);
                bool flag = false;
                using (LazyDisposable<BinaryReader> lazyDisposable = new LazyDisposable<BinaryReader>(() => new BinaryReader(Util.UnXorFile(tocFilename.Replace(".toc", ".sb"))))) {
                    foreach (DAIEntry bundle3 in dAIToc5.GetBundles()) {
                        bundle3.AddBoolValue("base", Value: true);
                        DAIEntry value = null;
                        int num5 = Util.Hasher(bundle3.GetStringValue("id").ToLower());
                        if (list2.Contains(num5)) {
                            flag = true;
                            continue;
                        }
                        if (dictionary2.ContainsKey(num5)) {
                            bundle3.RemoveField("base");
                            bundle3.AddBoolValue("delta", Value: true);
                            value = DAIToc.ReadFromStream(lazyDisposable.Value, bundle3.GetQWordValue("offset")).GetRootEntry();
                            flag = true;
                        }
                        dictionary3.Add(bundle3, value);
                    }
                }
                string ActualFilename = tocFilename.Replace(Settings.BasePath + "Data\\Win32\\", "");
                foreach (ModBundle item5 in basePatchModJob.Meta.Bundles.FindAll((ModBundle A) => A.Action == "add" && A.TocFilename.ToLower() == ActualFilename.ToLower())) {
                    if (Settings.VerboseScan) {
                        WriteLogEntry_Threaded("[1] Adding bundle " + item5.Name);
                    }
                    DAIEntry dAIEntry10 = new DAIEntry();
                    dAIEntry10.AddStringValue("path", item5.Name.ToLower());
                    dAIEntry10.AddDWordValue("magicSalt", (uint)item5.MagicSalt);
                    dAIEntry10.AddListValue("ebx", new List<DAIEntry>());
                    dAIEntry10.AddListValue("res", new List<DAIEntry>());
                    DAIEntry dAIEntry11 = new DAIEntry();
                    dAIEntry11.AddStringValue("id", item5.Name.ToLower());
                    dAIEntry11.AddQWordValue("offset", 0L);
                    dAIEntry11.AddDWordValue("size", 0u);
                    dAIEntry11.AddBoolValue("delta", Value: true);
                    dictionary3.Add(dAIEntry11, dAIEntry10);
                    foreach (ModBundleEntry entry3 in item5.Entries) {
                        ModResourceEntry modResourceEntry3 = basePatchModJob.Meta.Resources[entry3.ResourceId];
                        ModResourceEntry.BuildDAIEntry(dAIEntry10, modResourceEntry3);
                        flag = true;
                    }
                    dAIEntry10.AddBoolValue("alignMembers", item5.AlignMembers == 1);
                    dAIEntry10.AddBoolValue("ridSupport", item5.RidSupport == 1);
                    dAIEntry10.AddBoolValue("storeCompressedSizes", item5.StoreCompressedSizes == 1);
                    dAIEntry10.AddQWordValue("totalSize", 0L);
                    dAIEntry10.AddQWordValue("dbxTotalSize", 0L);
                }
                foreach (DAIEntry value3 in dictionary3.Values) {
                    if (value3 == null) {
                        continue;
                    }
                    if (Settings.VerboseScan) {
                        WriteLogEntry_Threaded("[1] Merging " + value3.GetStringValue("path"));
                    }
                    int key4 = Util.Hasher(value3.GetStringValue("path").ToLower());
                    if (!dictionary2.ContainsKey(key4)) {
                        continue;
                    }
                    foreach (ModResourceEntry item6 in dictionary2[key4]) {
                        ModResourceEntry ResourceEntry = item6;
                        if (ResourceEntry.Action == "modify") {
                            DAIEntry dAIEntry12 = value3.GetListValue(ResourceEntry.Type).Find((DAIEntry A) => A.GetSha1Value("sha1") == ResourceEntry.OriginalSha1);
                            if (dAIEntry12 != null) {
                                ModResourceEntry.ModifyResourceEntry(item6, dAIEntry12);
                                continue;
                            }
                            ModJob modJob4 = ModJobForResource(list, item6);
                            if (modJob4 != null) {
                                WriteLogEntry_Threaded("*** Warning: " + item6.Name + " not found for " + modJob4.Name);
                            }
                        } else if (ResourceEntry.Action == "remove") {
                            string text4 = ((ResourceEntry.Type == "chunk") ? "chunks" : ResourceEntry.Type);
                            int num6 = value3.GetListValue(text4).FindIndex((DAIEntry A) => A.GetSha1Value("sha1") == ResourceEntry.OriginalSha1);
                            if (num6 != -1) {
                                value3.GetListValue(text4).RemoveAt(num6);
                                if (text4 == "chunks") {
                                    value3.GetListValue("chunkMeta").RemoveAt(num6);
                                }
                            }
                        } else {
                            ModResourceEntry.BuildDAIEntry(value3, ResourceEntry);
                        }
                    }
                }
                int num4;
                if (flag) {
                    foreach (KeyValuePair<DAIEntry, DAIEntry> item7 in dictionary3) {
                        DAIEntry value2 = item7.Value;
                        DAIEntry key5 = item7.Key;
                        if (value2 != null) {
                            value2.GetListValue("ebx").Sort((DAIEntry A, DAIEntry B) => A.GetStringValue("name").CompareTo(B.GetStringValue("name")));
                            value2.GetListValue("res").Sort((DAIEntry A, DAIEntry B) => A.GetStringValue("name").CompareTo(B.GetStringValue("name")));
                            foreach (DAIEntry item8 in value2.GetListValue("ebx")) {
                                if (item8.HasField("idata")) {
                                    item8.RemoveField("idata");
                                }
                            }
                            foreach (DAIEntry item9 in value2.GetListValue("res")) {
                                if (item9.HasField("idata")) {
                                    item9.RemoveField("idata");
                                }
                            }
                            if (value2.HasField("chunks")) {
                                foreach (DAIEntry item10 in value2.GetListValue("chunks")) {
                                    if (item10.HasField("idata")) {
                                        item10.RemoveField("idata");
                                    }
                                }
                            }
                            if (value2.HasField("chunkMeta")) {
                                foreach (DAIEntry item11 in from A in value2.GetListValue("chunkMeta")
                                                            where A.GetDWordValue("h32") == -1
                                                            select A) {
                                    value2.GetListValue("chunkMeta").Remove(item11);
                                }
                            }
                            if (value2.HasField("dbx")) {
                                value2.RemoveField("dbx");
                            }
                            value2.SetStringValue("path", value2.GetStringValue("path").ToLower());
                        }
                        key5.SetStringValue("id", key5.GetStringValue("id").ToLower());
                    }
                    string text5 = tocFilename.Replace(Settings.BasePath, directoryName + "\\");
                    string filename = text5.Replace(".toc", ".sb");
                    DAIEntry dAIEntry13 = new DAIEntry();
                    dAIEntry13.AddListValue("bundles", new List<DAIEntry>());
                    foreach (DAIEntry value4 in dictionary3.Values) {
                        if (value4 != null) {
                            dAIEntry13.GetListValue("bundles").Add(value4);
                        }
                    }
                    dAIEntry13.GetListValue("bundles").Sort((DAIEntry A, DAIEntry B) => string.Compare(A.GetStringValue("path"), B.GetStringValue("path")));
                    DAIToc dAIToc6 = new DAIToc();
                    dAIToc6.SetRootEntry(dAIEntry13);
                    dAIToc6.WriteToFile(filename);
                    DAIToc dAIToc7 = new DAIToc();
                    DAIEntry dAIEntry14 = new DAIEntry();
                    List<DAIEntry> list6 = dictionary3.Keys.Where((DAIEntry A) => A.HasField("base")).ToList();
                    List<DAIEntry> list7 = dictionary3.Keys.Where((DAIEntry A) => A.HasField("delta")).ToList();
                    list6.Sort((DAIEntry A, DAIEntry B) => string.Compare(A.GetStringValue("id"), B.GetStringValue("id")));
                    list7.Sort((DAIEntry A, DAIEntry B) => string.Compare(A.GetStringValue("id"), B.GetStringValue("id")));
                    list6.AddRange(list7);
                    dAIEntry14.AddListValue("bundles", list6);
                    dAIEntry14.AddListValue("chunks", new List<DAIEntry>());
                    dAIEntry14.AddBoolValue("cas", dAIToc5.GetRootEntry().GetBoolValue("cas"));
                    dAIToc7.SetRootEntry(dAIEntry14);
                    int num7 = 0;
                    for (int num8 = 0; num8 < dictionary3.Count; num8 = num4) {
                        DAIEntry dAIEntry15 = dAIToc7.GetBundles()[num8];
                        if (dAIEntry15.HasField("delta")) {
                            DAIEntry dAIEntry16 = dAIToc6.GetBundles()[num7];
                            dAIEntry15.SetQWordValue("offset", dAIEntry16.EntryOffset);
                            dAIEntry15.SetDWordValue("size", (uint)dAIEntry16.GetSize());
                            num4 = num7 + 1;
                            num7 = num4;
                        }
                        num4 = num8 + 1;
                    }
                    dAIToc7.WriteToFile(text5, bWriteTocHeader: true);
                }
                num4 = num2 + 1;
                num2 = num4;
                Sha1 LayoutNameHash = Util.CalculateStringSha1(tocFilename.Replace(Settings.BasePath + "Data\\", "").Replace(".toc", "").Replace("\\", "/")
                    .ToLower());
                DAIEntry dAIEntry17 = layoutToc.GetRootEntry().GetListValue("superBundles").Find((DAIEntry A) => A.GetStringHashValue("name") == LayoutNameHash);
                if (dAIEntry17?.HasField("same") ?? false) {
                    dAIEntry17.RemoveField("same");
                    dAIEntry17.AddBoolValue("delta", Value: true);
                }
            }
            layoutToc.GetRootEntry().RemoveField("fs");
            layoutToc.GetRootEntry().AddListValue("fs", new List<DAIEntry>());
            layoutToc.GetRootEntry().AddListStringChild("fs", "initfs_Win32");
            layoutToc.WriteToFile(directoryName + "\\Data\\layout.toc", bWriteTocHeader: true);
            dAIToc.WriteToFile(directoryName + "\\Data\\Win32\\chunks0.toc", bWriteTocHeader: true);
            StreamWriter streamWriter = new StreamWriter(directoryName + "\\package.mft");
            streamWriter.WriteLine("Name patch");
            streamWriter.WriteLine("Authoritative");
            streamWriter.WriteLine("Version " + (Settings.PatchVersion + 1));
            streamWriter.WriteLine("ModManager v0.60 alpha");
            streamWriter.Close();
        }

        private IEnumerable<ModJob> ProcessModList(PatchPayloadData patchPayloadData) {
            return patchPayloadData.ModList.Select(delegate (ModContainer ModCont) {
                if (!ModCont.IsDAIMod()) {
                    return GenerateModJobFromDistPatch(ModCont);
                }
                BGWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Processing DAI mod \"" + ModCont.Name + "\""));
                if (ModCont.Mod.ScriptObject != null) {
                    Scripting.CurrentMod = ModCont.Mod;
                    ModCont.Mod.ScriptObject.RunScript();
                }
                return ModCont.Mod;
            });
        }

        private ModJob GetBasePatchModJob(PatchPayloadData patchPayloadData) {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\patch.daimod") || Settings.RescanPatch) {
                return GenerateModJobFromPatch(patchPayloadData.ModList[0].Version);
            }
            BGWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Loading official patch."));
            return ModJob.CreateFromFile(Directory.GetCurrentDirectory() + "\\patch.daimod");
        }

        private void PrepareDirectory(string directoryName, ModJob basePatchModJob, Dictionary<Sha1, byte[]> modResources, string patchDataPath, out DAIToc layoutToc) {
            if (Directory.Exists(directoryName + "\\Data")) {
                Directory.Delete(directoryName + "\\Data", recursive: true);
            }
            BGWorker.ReportProgress(0, new LoadingProgressState(InUpdateStatus: true, InUpdateProgress: true, InUpdateLog: true, "", "Creating cas files."));
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

        private ModJob ModJobForResource(IEnumerable<ModJob> modJobs, ModResourceEntry entry) {
            foreach (ModJob modJob in modJobs) {
                if (modJob.Meta.Resources.Contains(entry)) {
                    return modJob;
                }
            }
            return null;
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

        private bool CheckBasePatch() {
            if (DAIMft.SerializeFromFile(Settings.BasePath + "Update\\Patch\\package.mft").HasKey("ModManager")) {
                return false;
            }
            DAIToc dAIToc = DAIToc.ReadFromFile(Settings.BasePath + "Update\\Patch\\Data\\Win32\\globals.toc", 0L);
            IEnumerable<string> enumerable = from b in dAIToc.GetBundles()
                                             where b.HasField("base")
                                             select b.GetStringValue("id");
            return enumerable.SequenceEqual(enumerable.OrderBy((string id) => id));
        }

        private void LoadMods() {
            ModListBox.Items.Clear();
            ModManagerGrid.IsEnabled = false;
            MergeButton.IsEnabled = false;
            if (!File.Exists(Settings.BasePath + "DragonAgeInquisition.exe")) {
                System.Windows.MessageBox.Show("Dragon Age path has not been setup correctly. Please click on Browse and locate.", "Warning");
                return;
            }
            if (Settings.PatchVersion == -1) {
                System.Windows.MessageBox.Show("You *MUST* have a version of the Official Patch to be able to use mods.", "Error");
                return;
            }
            if (!CheckBasePatch()) {
                System.Windows.MessageBox.Show("The official patch folder contains a merged mod manager patch. Please restore the official patch to the correct location, or use 'Repair Game' in Origin to correct it.");
                return;
            }
            ModManagerGrid.IsEnabled = true;
            if (Settings.ModPath == "") {
                return;
            }
            ModListBox.Items.Add(new ModContainer(Settings.BasePath + "Update\\Patch\\", "Official Patch", "Bioware", "", "") {
                IsOfficialPatch = true,
                Version = Settings.PatchVersion.ToString()
            });
            int num = 1;
            foreach (string item in Directory.EnumerateDirectories(Settings.ModPath)) {
                if (File.Exists(item + "\\package.mft")) {
                    DAIMft dAIMft = DAIMft.SerializeFromFile(item + "\\package.mft");
                    if (dAIMft.HasKey("ModTitle")) {
                        ModListBox.Items.Add(new ModContainer(item, dAIMft.GetValue("ModTitle"), dAIMft.GetValue("ModAuthor"), dAIMft.GetValue("ModVersion"), dAIMft.GetValue("ModDescription")) {
                            Index = num++
                        });
                    }
                }
            }
            string[] files = Directory.GetFiles(Settings.ModPath, "*.daimod", SearchOption.AllDirectories);
            foreach (string inPath in files) {
                ModJob modJob = ModJob.CreateFromFile(inPath);
                ModListBox.Items.Add(new ModContainer(inPath, modJob.Meta.Details.Name, modJob.Meta.Details.Author, modJob.Meta.Details.Version, modJob.Meta.Details.Description, modJob.Meta.MinPatchVersion) {
                    Mod = modJob,
                    Index = num++
                });
                if (modJob.ScriptObject != null) {
                    ModConfigElementsList modConfigElementsList = new ModConfigElementsList();
                    modJob.ScriptObject.ConstructUI(modConfigElementsList);
                    modJob.ConfigValues = new Dictionary<string, object>();
                    foreach (ModConfigElement uIElement in modConfigElementsList.UIElements) {
                        modJob.ConfigValues.Add(uIElement.ParameterName, uIElement.ParameterDefaultValue);
                    }
                }
                if (modJob.Meta.Toolset >= 1000 && modJob.Meta.Toolset < 1016) {
                    System.Windows.MessageBox.Show("Warning: Mod " + modJob.Meta.Details.Name + " was created with an unstable toolset version and may not function correctly");
                }
            }
            MergeButton.IsEnabled = true;
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
