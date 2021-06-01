using System;
using System.IO;

using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Parsers;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Utilities {
    public static class PayloadProvider {
        public static byte[] GetAssetPayload(ResRef r) {
            if (r == null) {
                return null;
            }
            if (r.State == EntryState.Deleted) {
                return null;
            }
            if (r.State != 0 && r.ModifiedData != null) {
                return Utilities.DecompressData(r.ModifiedData, -1L);
            }
            if (!r.IsDelta) {
                if (!string.IsNullOrEmpty(r.Sha1)) {
                    return GetPayloadFromCas(r.Sha1);
                }
                return GetPayloadFromSB(r.EntryPath, r.EntryOffset, r.Size);
            }
            if (r.IsDelta) {
                byte[] compressedPayloadFromCas = GetCompressedPayloadFromCas(r.BaseSha1);
                byte[] deltaBytes = GetCompressedPayloadFromCas(r.DeltaSha1);
                return ApplyDelta(compressedPayloadFromCas, deltaBytes);
            }
            return null;
        }

        public static byte[] GetAssetPayload(EbxRef ebx) {
            if (ebx == null) {
                return null;
            }
            if (ebx.State == EntryState.Deleted) {
                return null;
            }
            if (ebx.State != 0 && ebx.ModifiedData != null) {
                return Utilities.DecompressData(ebx.ModifiedData, -1L);
            }
            if (!ebx.IsDelta) {
                if (!string.IsNullOrEmpty(ebx.Sha1)) {
                    return GetPayloadFromCas(ebx.Sha1);
                }
                return GetPayloadFromSB(ebx.EntryPath, ebx.EntryOffset, ebx.Size);
            }
            byte[] compressedPayloadFromCas = GetCompressedPayloadFromCas(ebx.BaseSha1);
            byte[] deltaData = GetCompressedPayloadFromCas(ebx.DeltaSha1);
            return ApplyDelta(compressedPayloadFromCas, deltaData);
        }

        public static byte[] GetAssetPayload(ChunkRef c) {
            if (c == null) {
                return null;
            }
            if (c.State == EntryState.Deleted) {
                return null;
            }
            if (c.State != 0 && c.ModifiedData != null) {
                return Utilities.DecompressData(c.ModifiedData, -1L);
            }
            if (!c.Offset.HasValue && !string.IsNullOrEmpty(c.Sha1)) {
                return GetPayloadFromCas(c.Sha1);
            }
            if (c.Offset.HasValue) {
                return GetPayloadFromSB(c.EntryPath.Replace(".toc", ".sb"), c.Offset.Value, c.Size);
            }
            return null;
        }

        public static byte[] GetPayloadFromSB(string sbPath, long offset, long size) {
            string path = Path.Combine(Library.BasePath, sbPath);
            if (!File.Exists(path)) {
                return null;
            }
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader reader = new BinaryReader(fs)) {
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    return GetCompressedPayload(reader, (int)size);
                }
            }
        }

        internal static byte[] GetCompressedPayload(BinaryReader reader, int size, bool justGetSize = false) {
            using (MemoryStream tmp = new MemoryStream()) {
                int length = 0;
                while (length < size && reader.BaseStream.Position < reader.BaseStream.Length) {
                    int ucsize = reader.ReadLEInt();
                    int magic = reader.ReadLEUInt16();
                    int csize = reader.ReadLEUInt16();
                    byte[] buff = new byte[0];
                    if (justGetSize) {
                        switch (magic) {
                            case 624:
                                length += ucsize;
                                reader.BaseStream.Position += csize;
                                break;
                            case 112:
                            case 113:
                                length += ucsize;
                                reader.BaseStream.Position += ucsize;
                                break;
                        }
                        continue;
                    }
                    switch (magic) {
                        case 624:
                            buff = new byte[csize];
                            reader.Read(buff, 0, csize);
                            buff = Utilities.DecompressZlib(buff, ucsize);
                            break;
                        case 112:
                        case 113:
                            buff = new byte[ucsize];
                            reader.Read(buff, 0, ucsize);
                            break;
                    }
                    tmp.Write(buff, 0, buff.Length);
                    length = (int)tmp.Length;
                }
                return tmp.ToArray();
            }
        }

        public static T GetEntryFromSB<T>(string path, long offset) where T : EntryRef, new() {
            if (!File.Exists(path)) {
                return null;
            }
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader reader = new BinaryReader(fs)) {
                    T entry = new T();
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    reader.ParseEntry(entry);
                    return entry;
                }
            }
        }

        public static byte[] GetPayloadFromCas(string sha1) {
            if (!Library.CasEntries.ContainsKey(sha1)) {
                return null;
            }
            CatalogEntry entry = Library.CasEntries[sha1];
            string casPath = string.Empty;
            casPath = ((!entry.IsNew) ? Path.Combine(Library.BasePath, entry.Path) : entry.Path);
            if (!File.Exists(casPath)) {
                return null;
            }
            using (FileStream fs = new FileStream(casPath, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader reader = new BinaryReader(fs)) {
                    reader.BaseStream.Seek(entry.Offset, SeekOrigin.Begin);
                    return reader.DecompressData(entry.Size);
                }
            }
        }

        public static byte[] GetCompressedPayloadFromCas(string sha1) {
            if (!Library.CasEntries.ContainsKey(sha1)) {
                return null;
            }
            CatalogEntry item = Library.CasEntries[sha1];
            if (!File.Exists(Path.Combine(Library.BasePath, item.Path))) {
                return null;
            }
            using (FileStream fs = new FileStream(Path.Combine(Library.BasePath, item.Path), FileMode.Open, FileAccess.Read)) {
                using (BinaryReader binaryReader = new BinaryReader(fs)) {
                    binaryReader.BaseStream.Seek(item.Offset, SeekOrigin.Begin);
                    return binaryReader.ReadBytes(item.Size);
                }
            }
        }

        public static byte[] ApplyDelta(byte[] baseData, byte[] deltaData, bool firstTry = true) {
            try {
                using (MemoryStream baseMs = new MemoryStream(baseData)) {
                    using (MemoryStream deltaMs = new MemoryStream(deltaData)) {
                        using (BinaryReader baseReader = new BinaryReader(baseMs)) {
                            using (BinaryReader deltaReader = new BinaryReader(deltaMs)) {
                                byte[] delta = ApplyDelta(baseReader, deltaReader);
                                if (delta == null && firstTry) {
                                    return ApplyDelta(baseData, deltaData, false);
                                }
                                return delta;
                            }
                        }
                    }
                }
            } catch (Exception) {
                if (firstTry) {
                    return ApplyDelta(baseData, deltaData, false);
                }
                return null;
            }
        }

        public static byte[] ApplyDelta(BinaryReader baseBinaryReader, BinaryReader deltaBinaryReader) {
            using (MemoryStream memoryStream = new MemoryStream()) {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream)) {
                    while (deltaBinaryReader.BaseStream.Position < deltaBinaryReader.BaseStream.Length) {
                        ushort patchType = (ushort)(deltaBinaryReader.ReadLEInt16() >> 12);
                        ushort blockSize = deltaBinaryReader.ReadLEUInt16();
                        switch (patchType) {
                            case 0:
                                ReadPatch0(baseBinaryReader, binaryWriter, blockSize);
                                break;
                            case 1:
                                ReadPatch1(deltaBinaryReader, baseBinaryReader, binaryWriter, blockSize);
                                break;
                            case 2:
                                ReadPatch2(deltaBinaryReader, baseBinaryReader, binaryWriter, blockSize);
                                break;
                            case 3:
                                ReadPatch3(deltaBinaryReader, baseBinaryReader, binaryWriter, blockSize);
                                break;
                            case 4:
                                ReadPatch4(deltaBinaryReader, baseBinaryReader, binaryWriter, blockSize);
                                break;
                            default:
                                return null;
                        }
                    }
                    while (baseBinaryReader.BaseStream.Position < baseBinaryReader.BaseStream.Length) {
                        binaryWriter.Write(Utilities.DecompressBlock(baseBinaryReader));
                    }
                    return memoryStream.ToArray();
                }
            }
        }

        private static void ReadPatch0(BinaryReader baseBinaryReader, BinaryWriter binaryWriter, ushort nbBlocks) {
            for (int i = 0; (long)i < (long)nbBlocks; i++) {
                binaryWriter.Write(Utilities.DecompressBlock(baseBinaryReader));
            }
        }

        private static void ReadPatch1(BinaryReader deltaBinaryReader, BinaryReader baseBinaryReader, BinaryWriter binaryWriter, ushort nbBlocks) {
            using (MemoryStream ms = new MemoryStream(Utilities.DecompressBlock(baseBinaryReader))) {
                using (BinaryReader blockReader = new BinaryReader(ms)) {
                    for (int i = 0; (long)i < (long)nbBlocks; i++) {
                        uint endOfBlock = deltaBinaryReader.ReadUInt16BE();
                        uint padding = deltaBinaryReader.ReadUInt16BE();
                        while (blockReader.BaseStream.Position != endOfBlock) {
                            binaryWriter.Write(blockReader.ReadByte());
                        }
                        binaryWriter.Write(Utilities.DecompressBlock(deltaBinaryReader));
                        blockReader.BaseStream.Seek(padding, SeekOrigin.Current);
                    }
                    binaryWriter.Write(blockReader.ReadBytes((int)(blockReader.BaseStream.Length - blockReader.BaseStream.Position)));
                }
            }
        }

        private static void ReadPatch2(BinaryReader deltaBinaryReader, BinaryReader baseBinaryReader, BinaryWriter binaryWriter, ushort nbBlocks) {
            using (MemoryStream ms = new MemoryStream(Utilities.DecompressBlock(baseBinaryReader))) {
                using (BinaryReader reader = new BinaryReader(ms)) {
                    uint writerPosition = (uint)((int)binaryWriter.BaseStream.Position + (int)deltaBinaryReader.ReadUInt16BE() + 1);
                    long deltaReaderPosition = deltaBinaryReader.BaseStream.Position;
                    while (deltaBinaryReader.BaseStream.Position - deltaReaderPosition < nbBlocks) {
                        int sizeOfWriteBlock = 0;
                        sizeOfWriteBlock |= deltaBinaryReader.ReadByte() << 8;
                        sizeOfWriteBlock |= deltaBinaryReader.ReadByte();
                        int offsetOfNextWriteBlock = deltaBinaryReader.ReadByte();
                        int sizeToTransferFromDeltaBlock = deltaBinaryReader.ReadByte();
                        while (reader.BaseStream.Position < sizeOfWriteBlock) {
                            binaryWriter.Write(reader.ReadByte());
                        }
                        reader.BaseStream.Seek(offsetOfNextWriteBlock, SeekOrigin.Current);
                        binaryWriter.Write(deltaBinaryReader.ReadBytes(sizeToTransferFromDeltaBlock));
                    }
                    while (binaryWriter.BaseStream.Position < writerPosition) {
                        binaryWriter.Write(reader.ReadByte());
                    }
                }
            }
        }

        private static void ReadPatch3(BinaryReader deltaBinaryReader, BinaryReader baseBinaryReader, BinaryWriter binaryWriter, ushort nbBlocks) {
            for (int i = 0; (long)i < (long)nbBlocks; i++) {
                binaryWriter.Write(Utilities.DecompressBlock(deltaBinaryReader));
            }
        }

        private static void ReadPatch4(BinaryReader deltaBinaryReader, BinaryReader baseBinaryReader, BinaryWriter binaryWriter, ushort nbBlocks) {
            for (int i = 0; i < nbBlocks; i++) {
                Utilities.DecompressBlock(baseBinaryReader);
            }
        }
    }
}
