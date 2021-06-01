using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

using DAI.Mod;
using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Parsers;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.Mod {
    internal static class ModParser {
        internal static ModJob DoOpenPatch(string patchPath, bool isImport, out List<string> errors) {
            ModJob job = null;
            errors = new List<string>();
            if (patchPath.Contains(".daimod")) {
                job = OpenDaimod(patchPath, isImport, errors);
            } else if (patchPath.Contains(".mft")) {
                job = OpenMftMod(patchPath, isImport);
            }
            return job;
        }

        private static ModJob OpenDaimod(string patchPath, bool isImport, List<string> errors) {
            Dictionary<int, string> sha1s = new Dictionary<int, string>();
            Dictionary<int, Guid> ids = new Dictionary<int, Guid>();
            ModJob modJob = ModJob.CreateFromFile(patchPath);
            if (!isImport) {
                modJob.FileName = patchPath;
            }
            for (int i = 0; i < modJob.Meta.Resources.Count; i++) {
                LoadEntries(sha1s, ids, modJob, i, errors);
            }
            foreach (ModBundle bundle in modJob.Meta.Bundles) {
                if (bundle.Action != "modify") {
                    continue;
                }
                SubBundleRef sb = Library.GetAllSubBundles().Find((SubBundleRef x) => x.Path.ToLower() == bundle.Name.ToLower());
                if (sb != null) {
                    foreach (ModBundleEntry entry in bundle.Entries) {
                        LoadBundleEntries(entry, modJob, sb, ids, errors);
                    }
                } else {
                    errors.Add($"Bundle with name {bundle.Name} does not exist or could not be found.");
                }
            }
            return modJob;
        }

        private static void LoadBundleEntries(ModBundleEntry entry, ModJob modJob, SubBundleRef sb, Dictionary<int, Guid> ids, List<string> errors) {
            ModResourceEntry modResourceEntry = modJob.Meta.Resources[entry.ResourceId];
            if (modResourceEntry.Action == "remove") {
                switch (modResourceEntry.Type) {
                    case "ebx": {
                            EbxRef ebx2 = Library.GetEbxByNameHash(modResourceEntry.NameHash);
                            if (ebx2 != null) {
                                LibraryManager.RemoveFromBundle(ebx2, sb);
                            }
                            errors.Add($"Ebx with name {modResourceEntry.Name} does not exist or could not be found.");
                            break;
                        }
                    case "res": {
                            ResRef resAsset = Library.GetResByName(modResourceEntry.Name);
                            if (resAsset != null) {
                                LibraryManager.RemoveFromBundle(resAsset, sb);
                            } else {
                                errors.Add($"Res with name {modResourceEntry.Name} does not exist or could not be found.");
                            }
                            break;
                        }
                    case "chunk": {
                            string guidPart2 = modResourceEntry.Name.Remove(16);
                            string s = modResourceEntry.Name.Remove(0, 16);
                            ulong guidValue2 = ulong.Parse(guidPart2, NumberStyles.HexNumber);
                            ulong guidValue4 = ulong.Parse(s, NumberStyles.HexNumber);
                            ChunkRef chunk2 = Library.GetChunkById(GuidExt.GetGuidFromDoubleULong(guidValue2, guidValue4).ToBig());
                            if (chunk2 != null) {
                                LibraryManager.RemoveFromBundle(chunk2, sb);
                            } else {
                                errors.Add($"Chunk with Id {modResourceEntry.Name} does not exist or could not be found.");
                            }
                            break;
                        }
                }
                return;
            }
            switch (modResourceEntry.Type) {
                case "ebx": {
                        EbxRef ebx = Library.GetEbxByNameHash(modResourceEntry.NameHash);
                        if (ebx != null) {
                            LibraryManager.AddToBundle(ebx, sb);
                        } else {
                            errors.Add($"Ebx with name {modResourceEntry.Name} does not exist or could not be found.");
                        }
                        break;
                    }
                case "res": {
                        ResRef res = null;
                        res = (((!(modResourceEntry.Action == "add") || modResourceEntry.ResourceID != -1) && !(modResourceEntry.Action == "modify")) ? Library.GetResByName(modResourceEntry.Name) : Library.GetResByResRid(((ResModResourceEntry)modResourceEntry).ResRid));
                        if (res != null) {
                            LibraryManager.AddToBundle(res, sb);
                        } else {
                            errors.Add($"Res with name {modResourceEntry.Name} does not exist or could not be found.");
                        }
                        break;
                    }
                case "chunk": {
                        ChunkRef chunk = null;
                        if ((modResourceEntry.Action == "add" && modResourceEntry.ResourceID == -1) || modResourceEntry.Action == "modify") {
                            string guidPart1 = modResourceEntry.Name.Remove(16);
                            string s2 = modResourceEntry.Name.Remove(0, 16);
                            ulong guidValue1 = ulong.Parse(guidPart1, NumberStyles.HexNumber);
                            ulong guidValue3 = ulong.Parse(s2, NumberStyles.HexNumber);
                            chunk = Library.GetChunkById(GuidExt.GetGuidFromDoubleULong(guidValue1, guidValue3).ToBig());
                        } else {
                            chunk = Library.GetChunkById(ids[entry.ResourceId]);
                        }
                        if (chunk != null) {
                            LibraryManager.AddToBundle(chunk, sb);
                        } else {
                            errors.Add($"Chunk with Id {modResourceEntry.Name} does not exist or could not be found.");
                        }
                        break;
                    }
            }
        }

        private static void LoadEntries(Dictionary<int, string> sha1s, Dictionary<int, Guid> ids, ModJob modJob, int i, List<string> errors) {
            ModResourceEntry item = modJob.Meta.Resources[i];
            switch (item.Type) {
                case "ebx":
                    switch (item.Action) {
                        case "add": {
                                string sha1 = modJob.Data[item.ResourceID].ToSha1();
                                sha1s.Add(i, sha1);
                                break;
                            }
                        case "modify": {
                                EbxRef ebx = Library.GetEbxByNameHash(item.NameHash);
                                if (ebx != null) {
                                    LibraryManager.ModifyEbx(ebx, modJob.Data[item.ResourceID], true);
                                } else {
                                    errors.Add($"Ebx with name {item.Name} does not exist or could not be found.");
                                }
                                break;
                            }
                        case "remove": {
                                EbxRef ebx2 = Library.GetEbxByNameHash(item.NameHash);
                                if (ebx2 != null) {
                                    LibraryManager.DeleteEbx(ebx2);
                                } else {
                                    errors.Add($"Ebx with name {item.Name} does not exist or could not be found.");
                                }
                                break;
                            }
                    }
                    break;
                case "res":
                    switch (item.Action) {
                        case "add": {
                                string sha2 = modJob.Data[item.ResourceID].ToSha1();
                                sha1s.Add(i, sha2);
                                break;
                            }
                        case "modify": {
                                ResModResourceEntry resItem = (ResModResourceEntry)item;
                                ResRef res = Library.GetResByResRid(resItem.ResRid);
                                if (res != null) {
                                    LibraryManager.ModifyRes(res, modJob.Data[resItem.ResourceID], true);
                                } else {
                                    errors.Add($"Res with name {item.Name} does not exist or could not be found.");
                                }
                                break;
                            }
                        case "remove": {
                                ResRef res2 = Library.GetResByResRid(((ResModResourceEntry)item).ResRid);
                                if (res2 != null) {
                                    LibraryManager.DeleteRes(res2);
                                } else {
                                    errors.Add($"Res with name {item.Name} does not exist or could not be found.");
                                }
                                break;
                            }
                    }
                    break;
                case "chunk": {
                        string guidPart1 = item.Name.Remove(16);
                        string s = item.Name.Remove(0, 16);
                        ulong guidValue1 = ulong.Parse(guidPart1, NumberStyles.HexNumber);
                        ulong guidValue2 = ulong.Parse(s, NumberStyles.HexNumber);
                        Guid id = GuidExt.GetGuidFromDoubleULong(guidValue1, guidValue2);
                        id = id.ToBig();
                        string action = item.Action;
                        if (!(action == "add")) {
                            if (action == "remove") {
                                ChunkRef chunk = Library.GetChunkById(id);
                                if (chunk != null) {
                                    LibraryManager.DeleteChunk(chunk);
                                } else {
                                    errors.Add($"Chunk with Id {item.Name} does not exist or could not be found.");
                                }
                            }
                            break;
                        }
                        string sha3 = modJob.Data[item.ResourceID].ToSha1();
                        ChunkModResourceEntry chunkItem = (ChunkModResourceEntry)item;
                        byte[] numArray = new byte[chunkItem.Meta.Length / 2];
                        string meta = chunkItem.Meta;
                        for (int j = 0; j < chunkItem.Meta.Length; j += 2) {
                            string str4 = meta.Substring(0, 2);
                            meta = meta.Remove(0, 2);
                            byte num2 = byte.Parse(str4, NumberStyles.HexNumber);
                            numArray[j / 2] = num2;
                        }
                        ChunkRef chunkAsset = new ChunkRef {
                            ChunkId = id
                        };
                        chunkAsset.ChunkId = chunkAsset.ChunkId.ToBig();
                        chunkAsset.H32 = chunkItem.ChunkH32;
                        chunkAsset.Meta = numArray;
                        chunkAsset.RangeStart = chunkItem.RangeStart;
                        chunkAsset.RangeEnd = chunkItem.RangeEnd;
                        chunkAsset.LogicalOffset = chunkItem.LogicalOffset;
                        chunkAsset.LogicalSize = chunkItem.LogicalSize;
                        chunkAsset.Size = (int)chunkItem.Size;
                        chunkAsset.Sha1 = sha3;
                        chunkAsset.Size = modJob.Data[chunkItem.ResourceID].Length;
                        LibraryManager.AddChunk(chunkAsset, modJob.Data[chunkItem.ResourceID], true);
                        ids.Add(i, chunkAsset.ChunkId);
                        break;
                    }
            }
        }

        private static ModJob OpenMftMod(string patchPath, bool isImport) {
            ModJob job = null;
            Mft dAIMft = Mft.SerializeFromFile(patchPath);
            if (!dAIMft.HasKey("ModTitle")) {
                return null;
            }
            if (!isImport) {
                job = new ModJob(dAIMft.GetValue("ModTitle"), "", "");
                job.Meta = new ModMetaData(1, 0, Guid.NewGuid().ToString().ToUpper(), (byte)Library.PatchVersion, new ModDetail(dAIMft.GetValue("ModTitle"), dAIMft.GetValue("ModVersion"), dAIMft.GetValue("ModAuthor"), dAIMft.GetValue("ModDescription")));
            }
            string directoryName = Path.GetDirectoryName(patchPath);
            Dictionary<string, CatalogEntry> catEntries = new Dictionary<string, CatalogEntry>();
            CatalogParser.Parse("", catEntries, directoryName + "\\Data\\cas.cat");
            foreach (string key in catEntries.Keys) {
                LibraryManager.AddCatalogEntry(catEntries[key]);
            }
            string[] files = Directory.GetFiles(directoryName + "\\Data\\Win32", "*.toc", SearchOption.AllDirectories);
            Func<EbxRef, bool> func = default(Func<EbxRef, bool>);
            Func<ResRef, bool> func3 = default(Func<ResRef, bool>);
            Func<ChunkRef, bool> func5 = default(Func<ChunkRef, bool>);
            for (int i = 0; i < files.Length; i++) {
                foreach (SubBundleRef sb in TocParser.ParseToc(files[i], directoryName, FolderType.Mod).SubBundles) {
                    if (!sb.Delta) {
                        continue;
                    }
                    List<EbxRef> source = new List<EbxRef>(sb.GetSbEbx());
                    List<ResRef> sbRes = new List<ResRef>(sb.GetSbRes());
                    List<ChunkRef> sbChunks = new List<ChunkRef>(sb.GetSbChunks());
                    LibraryManager.AddNewSubBundle(sb);
                    Func<EbxRef, bool> func2 = func;
                    if (func2 == null) {
                        func2 = (func = (EbxRef x) => catEntries.ContainsKey(x.Sha1));
                    }
                    foreach (EbxRef ebx in source.Where(func2)) {
                        EbxRef oldEbx = Library.GetEbxByNameHash(ebx.Name.ToSha1());
                        if (oldEbx != null) {
                            LibraryManager.AddToBundle(oldEbx, sb);
                            byte[] data3 = PayloadProvider.GetPayloadFromCas(ebx.Sha1);
                            data3 = DAI.AssetLibrary.Utilities.Utilities.CompressData(data3);
                            LibraryManager.ModifyEbx(oldEbx, data3, true);
                        }
                    }
                    Func<ResRef, bool> func4 = func3;
                    if (func4 == null) {
                        func4 = (func3 = (ResRef x) => catEntries.ContainsKey(x.Sha1));
                    }
                    foreach (ResRef res in sbRes.Where(func4)) {
                        ResRef oldRes = Library.GetResByName(res.Name);
                        if (oldRes != null) {
                            LibraryManager.AddToBundle(oldRes, sb);
                            byte[] data2 = PayloadProvider.GetPayloadFromCas(res.Sha1);
                            data2 = DAI.AssetLibrary.Utilities.Utilities.CompressData(data2);
                            LibraryManager.ModifyRes(oldRes, data2, true);
                        }
                    }
                    Func<ChunkRef, bool> func6 = func5;
                    if (func6 == null) {
                        func6 = (func5 = (ChunkRef x) => catEntries.ContainsKey(x.Sha1));
                    }
                    foreach (ChunkRef chunk in sbChunks.Where(func6)) {
                        ChunkRef oldChunk = Library.GetChunkById(chunk.ChunkId);
                        if (oldChunk == null) {
                            LibraryManager.AddToBundle(chunk, sb);
                            byte[] data = PayloadProvider.GetPayloadFromCas(chunk.Sha1);
                            data = DAI.AssetLibrary.Utilities.Utilities.CompressData(data);
                            LibraryManager.AddChunk(chunk, data, true);
                        } else {
                            LibraryManager.AddToBundle(oldChunk, sb);
                        }
                    }
                }
            }
            return job;
        }

        internal static void DoSavePatch(PatchPayloadData Payload) {
            ModJob mod = Payload.Mod;
            Dictionary<string, ModBundle> bundles = new Dictionary<string, ModBundle>();
            mod.ResetData();
            CommitStrings();
            ProcessEBX(mod, bundles);
            ProcessRes(mod, bundles);
            ProcessChunks(mod, bundles);
            foreach (ModBundle value in bundles.Values) {
                mod.Meta.Bundles.Add(value);
            }
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            mod.Meta.ToolSetVersion = version.Minor * 1000 + version.Build * 100 + version.Revision;
            mod.Save(Payload.OutputPath);
            mod.Meta.Bundles.Clear();
            mod.Meta.Resources.Clear();
            mod.Data.Clear();
        }

        private static void ProcessChunks(ModJob mod, Dictionary<string, ModBundle> nums) {
            ChunkModResourceEntry modEntry = null;
            foreach (ChunkRef chunkAsset in from x in Library.GetAllChunks()
                                            where x.State != EntryState.NoChanges
                                            select x) {
                switch (chunkAsset.State) {
                    case EntryState.Added:
                        mod.Data.Add(chunkAsset.ModifiedData);
                        modEntry = new ChunkModResourceEntry(chunkAsset, "add") {
                            ResourceID = mod.Data.Count - 1,
                            RangeStart = (chunkAsset.RangeStart.HasValue ? chunkAsset.RangeStart.Value : 0),
                            RangeEnd = (chunkAsset.RangeEnd.HasValue ? chunkAsset.RangeEnd.Value : 0),
                            LogicalOffset = chunkAsset.LogicalOffset,
                            LogicalSize = chunkAsset.LogicalSize,
                            Size = mod.Data[mod.Data.Count - 1].Length,
                            ChunkH32 = (chunkAsset.H32.HasValue ? chunkAsset.H32.Value : 0),
                            Meta = DAI.ModMaker.Utilities.Utilities.MetaToString(chunkAsset.Meta),
                            PatchType = (byte)((chunkAsset.CasPatchType == 0) ? 1 : ((byte)chunkAsset.CasPatchType)),
                            OriginalSha1 = mod.Data[mod.Data.Count - 1].ToSha1()
                        };
                        foreach (SubBundleRef sb in chunkAsset.AddedSbs) {
                            AddBundleToModJob(mod, nums, sb);
                        }
                        break;
                    case EntryState.Deleted:
                        modEntry = new ChunkModResourceEntry(chunkAsset, "remove") {
                            OriginalSha1 = chunkAsset.Sha1
                        };
                        foreach (SubBundleRef sb2 in chunkAsset.RemovedSbs) {
                            AddBundleToModJob(mod, nums, sb2);
                        }
                        break;
                }
                if (modEntry != null) {
                    mod.Meta.Resources.Add(modEntry);
                }
            }
        }

        private static void ProcessRes(ModJob mod, Dictionary<string, ModBundle> nums) {
            foreach (ResRef resAsset1 in from x in Library.GetAllRes()
                                         where x.State != EntryState.NoChanges
                                         select x) {
                ModResourceEntry modEntry = null;
                switch (resAsset1.State) {
                    case EntryState.Added:
                        mod.Data.Add(resAsset1.ModifiedData);
                        modEntry = new ResModResourceEntry(resAsset1, "add") {
                            ResourceID = mod.Data.Count - 1,
                            OriginalSha1 = resAsset1.Sha1,
                            Size = resAsset1.Size,
                            OriginalSize = resAsset1.DataOriginalSize,
                            ResType = resAsset1.ResType,
                            ResRid = resAsset1.ResRid,
                            Meta = DAI.ModMaker.Utilities.Utilities.MetaToString(resAsset1.ResMeta),
                            PatchType = (byte)((resAsset1.CasPatchType == 0) ? 1 : ((byte)resAsset1.CasPatchType))
                        };
                        if (resAsset1.IsDelta) {
                            modEntry.BaseSha1 = resAsset1.BaseSha1;
                            modEntry.DeltaSha1 = resAsset1.DeltaSha1;
                        }
                        foreach (SubBundleRef sb in resAsset1.AddedSbs) {
                            AddBundleToModJob(mod, nums, sb);
                        }
                        break;
                    case EntryState.Modified:
                        mod.Data.Add(resAsset1.ModifiedData);
                        modEntry = new ResModResourceEntry(resAsset1, "modify") {
                            ResourceID = mod.Data.Count - 1,
                            OriginalSha1 = resAsset1.Sha1,
                            NewSha1 = mod.Data[mod.Data.Count - 1].ToSha1(),
                            Size = mod.Data[mod.Data.Count - 1].Length,
                            OriginalSize = resAsset1.DataOriginalSize,
                            ResType = resAsset1.ResType,
                            ResRid = resAsset1.ResRid,
                            Meta = DAI.ModMaker.Utilities.Utilities.MetaToString(resAsset1.ResMeta),
                            PatchType = 1
                        };
                        foreach (SubBundleRef sb2 in resAsset1.ParentSbs) {
                            AddBundleToModJob(mod, nums, sb2);
                        }
                        break;
                    case EntryState.Deleted:
                        modEntry = new ResModResourceEntry(resAsset1, "remove") {
                            OriginalSha1 = resAsset1.Sha1
                        };
                        foreach (SubBundleRef sb3 in resAsset1.RemovedSbs) {
                            AddBundleToModJob(mod, nums, sb3);
                        }
                        break;
                }
                if (modEntry != null) {
                    mod.Meta.Resources.Add(modEntry);
                }
            }
        }

        private static void ProcessEBX(ModJob mod, Dictionary<string, ModBundle> nums) {
            foreach (EbxRef ebxAsset in from x in Library.GetAllEbx()
                                        where x.State != EntryState.NoChanges
                                        select x) {
                ModResourceEntry modEntry = null;
                switch (ebxAsset.State) {
                    case EntryState.Added:
                        mod.Data.Add(ebxAsset.ModifiedData);
                        modEntry = new EbxModResourceEntry(ebxAsset, "add") {
                            ResourceID = mod.Data.Count - 1,
                            Size = mod.Data[mod.Data.Count - 1].Length,
                            OriginalSize = ebxAsset.DataOriginalSize,
                            PatchType = (byte)((ebxAsset.CasPatchType == 0) ? 1 : ((byte)ebxAsset.CasPatchType)),
                            OriginalSha1 = mod.Data[mod.Data.Count - 1].ToSha1()
                        };
                        foreach (SubBundleRef sb in ebxAsset.ParentSbs) {
                            AddBundleToModJob(mod, nums, sb);
                        }
                        break;
                    case EntryState.Modified:
                        mod.Data.Add(ebxAsset.ModifiedData);
                        modEntry = new EbxModResourceEntry(ebxAsset, "modify") {
                            ResourceID = mod.Data.Count - 1,
                            OriginalSha1 = ebxAsset.Sha1,
                            NewSha1 = mod.Data[mod.Data.Count - 1].ToSha1(),
                            Size = mod.Data[mod.Data.Count - 1].Length,
                            OriginalSize = ebxAsset.DataOriginalSize,
                            PatchType = 1
                        };
                        foreach (SubBundleRef sb2 in ebxAsset.ParentSbs) {
                            AddBundleToModJob(mod, nums, sb2);
                        }
                        break;
                    case EntryState.Deleted:
                        modEntry = new EbxModResourceEntry(ebxAsset, "remove") {
                            OriginalSha1 = ebxAsset.Sha1
                        };
                        foreach (SubBundleRef sb3 in ebxAsset.RemovedSbs) {
                            AddBundleToModJob(mod, nums, sb3);
                        }
                        break;
                }
                if (modEntry != null) {
                    mod.Meta.Resources.Add(modEntry);
                }
            }
        }

        private static void AddBundleToModJob(ModJob mod, Dictionary<string, ModBundle> bundles, SubBundleRef sb) {
            if (sb.IsJson) {
                if (!bundles.ContainsKey(sb.Path)) {
                    bundles.Add(sb.Path, new ModBundle(sb.Path, "modify"));
                }
                ModBundle modBundle = bundles[sb.Path];
                ModBundleEntry modBundleEntry = new ModBundleEntry(mod.Meta.Resources.Count);
                modBundle.Entries.Add(modBundleEntry);
            }
        }

        private static void CommitStrings() {
            Func<ResRef, bool> func = default(Func<ResRef, bool>);
            foreach (string allLanguage in Library.GetAllLanguages()) {
                if (Library.GetAllStrings(allLanguage).Count((Talktable.TalktableString A) => A.State != Talktable.TalktableStringState.NoChanges) <= 0) {
                    continue;
                }
                List<ResRef> allRes = Library.GetAllRes();
                Func<ResRef, bool> func2 = func;
                if (func2 == null) {
                    func2 = (func = (ResRef x) => (long)x.ResType == 1585851909 && x.Name.Contains($"/{allLanguage}/"));
                }
                foreach (ResRef resAsset in allRes.Where(func2)) {
                    Talktable dAITalktable = Talktable.FromRes(resAsset);
                    bool flag = false;
                    foreach (Talktable.TalktableString @string in dAITalktable.Strings) {
                        Talktable.TalktableString str = Library.GetString(allLanguage, @string.ID);
                        if (str.State != 0) {
                            LibraryManager.ModifyString(@string, str.Value);
                            flag = true;
                        }
                    }
                    if (flag) {
                        LibraryManager.ModifyRes(resAsset, dAITalktable.Save().ToArray(), false);
                    }
                }
            }
        }
    }
}
