using System.Collections.Generic;

using DAI.Mod.Manager.Frostbite;
using DAI.Utilities;

namespace DAI.Mod.Manager.Utilities {
    public static class ModResourceEntryExt {
        public static void CopyPatchSha1(ModResourceEntry mre, DAIEntry copyFromEntry) {
            int num = copyFromEntry.HasField("casPatchType") ? copyFromEntry.GetDWordValue("casPatchType") : 0;
            mre.PatchType = (byte)num;
            mre.OriginalSha1 = copyFromEntry.GetSha1Value("sha1");
            if (num == 2) {
                mre.DeltaSha1 = copyFromEntry.GetSha1Value("deltaSha1");
                mre.BaseSha1 = copyFromEntry.GetSha1Value("baseSha1");
            }
        }

        public static void CopyChunkFields(ChunkModResourceEntry chunkEntry, DAIEntry Entry, DAIEntry ChunkMetaEntry) {
            chunkEntry.LogicalOffset = Entry.GetDWordValue("logicalOffset");
            chunkEntry.LogicalSize = Entry.GetDWordValue("logicalSize");
            if (Entry.HasField("rangeStart")) {
                chunkEntry.RangeStart = Entry.GetDWordValue("rangeStart");
                chunkEntry.RangeEnd = Entry.GetDWordValue("rangeEnd");
            }
            chunkEntry.ChunkH32 = ChunkMetaEntry.GetDWordValue("h32");
            chunkEntry.Meta = Meta.MetaToString(ChunkMetaEntry.GetByteArrayValue("meta"));
            CopyPatchSha1(chunkEntry, Entry);
        }

        public static void ModifyResourceEntry(ModResourceEntry newEntry, DAIEntry entryToModify) {
            entryToModify.RemoveField("casPatchType");
            entryToModify.RemoveField("baseSha1");
            entryToModify.RemoveField("deltaSha1");
            entryToModify.SetSha1Value("sha1", newEntry.NewSha1);
            entryToModify.SetQWordValue("size", newEntry.Size);
            entryToModify.SetQWordValue("originalSize", newEntry.OriginalSize);
            if (newEntry is ResModResourceEntry resEntry) {
                entryToModify.SetDWordValue("resType", (uint)resEntry.ResType);
                entryToModify.SetByteArrayValue("resMeta", Meta.StringToMeta(resEntry.Meta));
                entryToModify.SetQWordValue("resRid", resEntry.ResRid);
            }
            entryToModify.AddDWordValue("casPatchType", newEntry.PatchType);
            if (newEntry.PatchType == 2) {
                entryToModify.AddSha1Value("baseSha1", newEntry.BaseSha1);
                entryToModify.AddSha1Value("deltaSha1", newEntry.DeltaSha1);
            }
        }

        public static void BuildDAIEntry(DAIEntry existingEntry, ModResourceEntry newMre) {
            DAIEntry newEntry = new DAIEntry();
            string mreType = (newMre.Type == "chunk") ? "chunks" : newMre.Type;
            if (newMre is ChunkModResourceEntry) {
                newEntry.AddDQWordValue("id", DQWord.StringToDQWord(newMre.Name));
            } else {
                newEntry.AddStringValue("name", newMre.Name);
            }
            newEntry.AddSha1Value("sha1", newMre.OriginalSha1);
            if (!(newMre is ChunkModResourceEntry)) {
                if (!existingEntry.HasField(mreType)) {
                    existingEntry.AddListValue(mreType, new List<DAIEntry>());
                }
                newEntry.AddQWordValue("size", newMre.Size);
                newEntry.AddQWordValue("originalSize", newMre.OriginalSize);
                if (newMre is ResModResourceEntry rMre) {
                    newEntry.AddDWordValue("resType", (uint)rMre.ResType);
                    DAIField dAIField = newEntry.AddByteArrayValue("resMeta", Meta.StringToMeta(rMre.Meta));
                    dAIField.DataType = 19;
                    newEntry.AddQWordValue("resRid", rMre.ResRid);
                }
            } else {
                ChunkModResourceEntry cMre = newMre as ChunkModResourceEntry;
                if (!existingEntry.HasField("chunks")) {
                    existingEntry.AddListValue("chunks", new List<DAIEntry>());
                    existingEntry.AddListValue("chunkMeta", new List<DAIEntry>());
                }
                newEntry.AddDWordValue("size", (uint)cMre.Size);
                if (cMre.RangeStart != cMre.RangeEnd) {
                    newEntry.AddDWordValue("rangeStart", (uint)cMre.RangeStart);
                    newEntry.AddDWordValue("rangeEnd", (uint)cMre.RangeEnd);
                }
                newEntry.AddDWordValue("logicalOffset", (uint)cMre.LogicalOffset);
                newEntry.AddDWordValue("logicalSize", (uint)cMre.LogicalSize);
                DAIEntry metaEntry = new DAIEntry();
                metaEntry.AddDWordValue("h32", (uint)cMre.ChunkH32);
                metaEntry.AddByteArrayValue("meta", Meta.StringToMeta(cMre.Meta));
                existingEntry.AddListChild("chunkMeta", metaEntry);
            }
            newEntry.AddDWordValue("casPatchType", newMre.PatchType);
            if (newMre.PatchType == 2) {
                newEntry.AddSha1Value("baseSha1", newMre.BaseSha1);
                newEntry.AddSha1Value("deltaSha1", newMre.DeltaSha1);
            } else if (newMre.PatchType == 0) {
                newEntry.RemoveField("casPatchType");
            }
            existingEntry.AddListChild(mreType, newEntry);
        }
    }
}
