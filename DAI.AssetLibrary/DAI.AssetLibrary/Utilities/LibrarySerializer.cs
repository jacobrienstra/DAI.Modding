using System;
using System.Collections.Generic;
using System.IO;

using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Utilities {
    internal static class LibrarySerializer {
        internal static void Serialize(BinaryWriter writer) {
            writer.Write(Library.AllEbx.Count);
            foreach (EbxRef ebx in Library.AllEbx.Values) {
                SerializeEbx(writer, ebx);
            }
            writer.Write(Library.AllRes.Count);
            foreach (ResRef res in Library.AllRes.Values) {
                SerializeRes(writer, res);
            }
            writer.Write(Library.AllChunks.Count);
            foreach (ChunkRef chunk in Library.AllChunks.Values) {
                SerializeChunk(writer, chunk);
            }
            writer.Write(Library.AllSubBundles.Count);
            foreach (SubBundleRef sb in Library.AllSubBundles.Values) {
                SerializeSb(writer, sb);
            }
        }

        private static void SerializeSb(BinaryWriter writer, SubBundleRef sb) {
            SerializeEntry(writer, sb);
            writer.Write(sb.Base);
            writer.Write(sb.BinaryName);
            writer.Write(sb.Delta);
            writer.Write(sb.Path);
            writer.Write(sb.IsJson);
            writer.Write(sb.Ebx.Count);
            foreach (EbxRef ebx in sb.Ebx) {
                writer.Write(ebx.LibraryId);
            }
            writer.Write(sb.Res.Count);
            foreach (ResRef res in sb.Res) {
                writer.Write(res.LibraryId);
            }
            writer.Write(sb.Chunks.Count);
            foreach (ChunkRef chunk in sb.Chunks) {
                writer.Write(chunk.LibraryId);
            }
        }

        private static void SerializeChunk(BinaryWriter writer, ChunkRef chunk) {
            SerializeAssetEntry(writer, chunk);
            writer.Write(chunk.CasPatchType);
            writer.Write(chunk.ChunkId);
            writer.Write(chunk.LogicalOffset);
            writer.Write(chunk.LogicalSize);
            writer.Write(chunk.Offset.HasValue);
            if (chunk.Offset.HasValue) {
                writer.Write(chunk.Offset.Value);
            }
            writer.Write(chunk.RangeEnd.HasValue);
            if (chunk.RangeEnd.HasValue) {
                writer.Write(chunk.RangeEnd.Value);
            }
            writer.Write(chunk.RangeStart.HasValue);
            if (chunk.RangeStart.HasValue) {
                writer.Write(chunk.RangeStart.Value);
            }
            writer.Write(chunk.Sha1);
            writer.Write(chunk.Size);
            if (chunk.H32.HasValue) {
                writer.Write(true);
                writer.Write(chunk.H32.Value);
                SerializeByteArray(writer, chunk.Meta);
            } else {
                writer.Write(false);
            }
        }

        private static void SerializeEbx(BinaryWriter writer, EbxRef ebx) {
            SerializeAssetEntry(writer, ebx);
            writer.Write(ebx.AssetType);
            writer.Write(ebx.BaseSha1);
            writer.Write(ebx.BinaryName);
            writer.Write(ebx.CasPatchType);
            writer.Write(ebx.DeltaSha1);
            writer.Write(ebx.FileGuid);
            writer.Write(ebx.IsDelta);
            writer.Write(ebx.Name);
            writer.Write(ebx.OriginalSize);
            writer.Write(ebx.Sha1);
            writer.Write(ebx.Size);
        }

        private static void SerializeRes(BinaryWriter writer, ResRef res) {
            SerializeAssetEntry(writer, res);
            writer.Write(res.BaseSha1);
            writer.Write(res.BinaryName);
            writer.Write(res.CasPatchType);
            writer.Write(res.DeltaSha1);
            writer.Write(res.IsDelta);
            writer.Write(res.Name);
            SerializeByteArray(writer, res.ResMeta);
            writer.Write(res.ResRid);
            writer.Write(res.ResType);
            writer.Write(res.Sha1);
            writer.Write(res.Size);
        }

        private static void SerializeEntry(BinaryWriter writer, EntryRef entry) {
            writer.Write(entry.EntryPath);
            writer.Write(entry.EntryOffset);
            writer.Write(entry.FromDLC);
        }

        private static void SerializeAssetEntry(BinaryWriter writer, AssetEntryRef entry) {
            SerializeEntry(writer, entry);
            writer.Write(entry.LibraryId);
        }

        private static void SerializeByteArray(BinaryWriter writer, byte[] bArray) {
            if (bArray == null) {
                writer.Write(false);
                return;
            }
            writer.Write(true);
            writer.Write(bArray.Length);
            writer.Write(bArray);
        }

        internal static void Deserialize(BinaryReader reader) {
            Dictionary<Guid, EbxRef> allEbx = new Dictionary<Guid, EbxRef>();
            Dictionary<Guid, ResRef> allRes = new Dictionary<Guid, ResRef>();
            Dictionary<Guid, ChunkRef> allChunks = new Dictionary<Guid, ChunkRef>();
            int ebxCount = reader.ReadInt32();
            for (int l = 0; l < ebxCount; l++) {
                EbxRef ebx = DeserializeEbx(reader);
                allEbx.Add(ebx.LibraryId, ebx);
                Library.AddEbx(ebx);
            }
            int resCount = reader.ReadInt32();
            for (int k = 0; k < resCount; k++) {
                ResRef res = DeserializeRes(reader);
                allRes.Add(res.LibraryId, res);
                Library.AddRes(res);
            }
            int chunkCount = reader.ReadInt32();
            for (int j = 0; j < chunkCount; j++) {
                ChunkRef chunk = DeserializeChunk(reader);
                allChunks.Add(chunk.LibraryId, chunk);
                Library.AddChunk(chunk);
            }
            int sbcount = reader.ReadInt32();
            for (int i = 0; i < sbcount; i++) {
                Library.AddSubBundle(DeserializeSb(reader, allEbx, allRes, allChunks));
            }
        }

        private static SubBundleRef DeserializeSb(BinaryReader reader, Dictionary<Guid, EbxRef> ebx, Dictionary<Guid, ResRef> res, Dictionary<Guid, ChunkRef> chunks) {
            SubBundleRef sb = new SubBundleRef();
            DeserializeEntry(reader, sb);
            sb.Base = reader.ReadBoolean();
            sb.BinaryName = reader.ReadString();
            sb.Delta = reader.ReadBoolean();
            sb.Path = reader.ReadString();
            sb.IsJson = reader.ReadBoolean();
            int ebxCount = reader.ReadInt32();
            for (int k = 0; k < ebxCount; k++) {
                Library.AddToBundle(ebx[reader.ReadGuid()], sb);
            }
            int resCount = reader.ReadInt32();
            for (int j = 0; j < resCount; j++) {
                Library.AddToBundle(res[reader.ReadGuid()], sb);
            }
            int chunkCount = reader.ReadInt32();
            for (int i = 0; i < chunkCount; i++) {
                Library.AddToBundle(chunks[reader.ReadGuid()], sb);
            }
            Library.AddSubBundle(sb);
            return sb;
        }

        private static ChunkRef DeserializeChunk(BinaryReader reader) {
            ChunkRef chunk = new ChunkRef();
            DeserializeAssetEntry(reader, chunk);
            chunk.CasPatchType = reader.ReadInt32();
            chunk.ChunkId = reader.ReadGuid();
            chunk.LogicalOffset = reader.ReadInt32();
            chunk.LogicalSize = reader.ReadInt32();
            if (reader.ReadBoolean()) {
                chunk.Offset = reader.ReadInt64();
            }
            if (reader.ReadBoolean()) {
                chunk.RangeEnd = reader.ReadInt32();
            }
            if (reader.ReadBoolean()) {
                chunk.RangeStart = reader.ReadInt32();
            }
            chunk.Sha1 = reader.ReadString();
            chunk.Size = reader.ReadInt32();
            if (reader.ReadBoolean()) {
                chunk.H32 = reader.ReadInt32();
                chunk.Meta = DeserializeByteArray(reader);
            }
            return chunk;
        }

        private static EbxRef DeserializeEbx(BinaryReader reader) {
            EbxRef ebx = new EbxRef();
            DeserializeAssetEntry(reader, ebx);
            ebx.AssetType = reader.ReadString();
            ebx.BaseSha1 = reader.ReadString();
            ebx.BinaryName = reader.ReadString();
            ebx.CasPatchType = reader.ReadInt32();
            ebx.DeltaSha1 = reader.ReadString();
            ebx.FileGuid = reader.ReadGuid();
            ebx.IsDelta = reader.ReadBoolean();
            ebx.Name = reader.ReadString();
            ebx.OriginalSize = reader.ReadInt64();
            ebx.Sha1 = reader.ReadString();
            ebx.Size = reader.ReadInt64();
            return ebx;
        }

        private static ResRef DeserializeRes(BinaryReader reader) {
            ResRef res = new ResRef();
            DeserializeAssetEntry(reader, res);
            res.BaseSha1 = reader.ReadString();
            res.BinaryName = reader.ReadString();
            res.CasPatchType = reader.ReadInt32();
            res.DeltaSha1 = reader.ReadString();
            res.IsDelta = reader.ReadBoolean();
            res.Name = reader.ReadString();
            res.ResMeta = DeserializeByteArray(reader);
            res.ResRid = reader.ReadInt64();
            res.ResType = reader.ReadInt32();
            res.Sha1 = reader.ReadString();
            res.Size = reader.ReadInt64();
            return res;
        }

        private static void DeserializeAssetEntry(BinaryReader reader, AssetEntryRef entry) {
            DeserializeEntry(reader, entry);
            entry.LibraryId = reader.ReadGuid();
        }

        private static void DeserializeEntry(BinaryReader reader, EntryRef entry) {
            entry.EntryPath = reader.ReadString();
            entry.EntryOffset = reader.ReadInt32();
            entry.FromDLC = reader.ReadBoolean();
        }

        private static byte[] DeserializeByteArray(BinaryReader reader) {
            if (!reader.ReadBoolean()) {
                return null;
            }
            return reader.ReadBytes(reader.ReadInt32());
        }
    }
}
