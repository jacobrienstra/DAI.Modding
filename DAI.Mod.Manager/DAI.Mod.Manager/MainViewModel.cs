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

namespace DAI.Mod.Manager {
    public class MainViewModel {

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

    }
}
