using System;
using System.Collections.Generic;
using System.IO;

using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Parsers {
    internal static class SBParser {
        internal static SubBundleRef ParseSubBundle(string filename, string basePath, long offset) {
            SubBundleRef sb = new SubBundleRef();
            sb.EntryPath = filename.Replace(basePath + "\\", "");
            sb.IsJson = true;
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader reader = new BinaryReader(fs)) {
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    if (!reader.ParseEntry(sb)) {
                        return null;
                    }
                }
            }
            for (int i = 0; i < sb.ChunkMeta.Count; i++) {
                sb.Chunks[i].H32 = sb.ChunkMeta[i].H32;
                sb.Chunks[i].Meta = sb.ChunkMeta[i].Meta;
            }
            sb.ChunkMeta.Clear();
            return sb;
        }

        internal static SubBundleRef ParseBinarySubBundle(string filename, string basePath, long offset) {
            SubBundleRef sb = new SubBundleRef();
            sb.EntryPath = filename.Replace(basePath + "\\", "");
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
                using (BinaryReader reader = new BinaryReader(fs)) {
                    List<Sha1> sha1s = new List<Sha1>();
                    reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                    uint headerSize = reader.ReadLEUInt();
                    long startOffset = reader.BaseStream.Position;
                    if (BitConverter.ToUInt32(reader.ReadBytes(4), 0) != 3582884253u) {
                        return null;
                    }
                    uint totalCount = reader.ReadLEUInt();
                    uint ebxCount = reader.ReadLEUInt();
                    uint resCount = reader.ReadLEUInt();
                    uint chunkCount = reader.ReadLEUInt();
                    uint stringOffsets = reader.ReadLEUInt();
                    reader.ReadLEUInt();
                    reader.ReadLEUInt();
                    for (int m = 0; m < totalCount; m++) {
                        sha1s.Add(reader.ReadSha1());
                    }
                    ReadEbxList(sb, reader, startOffset + stringOffsets, ebxCount);
                    ReadResList(sb, reader, startOffset + stringOffsets, resCount);
                    ReadChunkList(sb, reader, chunkCount);
                    ReadChunkMetas(sb, reader, chunkCount);
                    for (int l = 0; l < totalCount; l++) {
                        if (l < sb.Ebx.Count) {
                            sb.Ebx[l].Sha1 = sha1s[l];
                        } else if (l < sb.Ebx.Count + sb.Res.Count) {
                            sb.Res[l - sb.Ebx.Count].Sha1 = sha1s[l];
                        } else {
                            sb.Chunks[l - sb.Ebx.Count - sb.Res.Count].Sha1 = sha1s[l];
                        }
                    }
                    reader.BaseStream.Seek(startOffset + headerSize, SeekOrigin.Begin);
                    for (int k = 0; k < sb.Ebx.Count; k++) {
                        sb.Ebx[k].EntryOffset = (int)reader.BaseStream.Position;
                        PayloadProvider.GetCompressedPayload(reader, (int)sb.Ebx[k].Size, true);
                    }
                    for (int j = 0; j < sb.Res.Count; j++) {
                        sb.Res[j].EntryOffset = (int)reader.BaseStream.Position;
                        PayloadProvider.GetCompressedPayload(reader, (int)sb.Res[j].Size, true);
                    }
                    for (int i = 0; i < sb.Chunks.Count; i++) {
                        sb.Chunks[i].EntryOffset = (int)reader.BaseStream.Position;
                        sb.Chunks[i].Offset = (int)reader.BaseStream.Position;
                        PayloadProvider.GetCompressedPayload(reader, sb.Chunks[i].Size, true);
                    }
                    return sb;
                }
            }
        }

        private static void ReadChunkMetas(SubBundleRef sb, BinaryReader reader, uint chunkCount) {
            if (chunkCount != 0 && reader.ReadByte() == 1) {
                reader.ReadNullTerminatedString();
                HashedList<ChunkMetaRef> metas = reader.ParseEntryList<ChunkMetaRef>();
                for (int i = 0; i < metas.Count; i++) {
                    sb.Chunks[i].H32 = metas[i].H32;
                    sb.Chunks[i].Meta = metas[i].Meta;
                }
            }
        }

        private static void ReadChunkList(SubBundleRef sb, BinaryReader reader, uint chunkCount) {
            for (int i = 0; i < chunkCount; i++) {
                ChunkRef c = new ChunkRef();
                List<byte> bytes = new List<byte>();
                int value1 = reader.ReadLEInt();
                short value2 = reader.ReadLEInt16();
                short value3 = reader.ReadLEInt16();
                bytes.AddRange(BitConverter.GetBytes(value1));
                bytes.AddRange(BitConverter.GetBytes(value2));
                bytes.AddRange(BitConverter.GetBytes(value3));
                bytes.AddRange(BitConverter.GetBytes(reader.ReadInt64()));
                c.ChunkId = new Guid(bytes.ToArray());
                c.RangeStart = reader.ReadLEUInt16();
                c.LogicalSize = reader.ReadLEUInt16();
                c.Size = reader.ReadLEInt();
                sb.Chunks.Add(c);
            }
        }

        private static void ReadResList(SubBundleRef sb, BinaryReader reader, long stringOffset, uint resCount) {
            for (int l = 0; l < resCount; l++) {
                ResRef res = new ResRef();
                int nameOffset = reader.ReadLEInt();
                res.Size = reader.ReadLEInt();
                res.Name = ReadName(reader, stringOffset + nameOffset);
                sb.Res.Add(res);
            }
            for (int k = 0; k < resCount; k++) {
                sb.Res[k].ResType = reader.ReadLEInt();
            }
            for (int j = 0; j < resCount; j++) {
                reader.ReadBytes(16);
            }
            for (int i = 0; i < resCount; i++) {
                sb.Res[i].ResRid = reader.ReadLEInt64();
            }
        }

        private static void ReadEbxList(SubBundleRef sb, BinaryReader reader, long stringOffset, uint ebxCount) {
            for (int i = 0; i < ebxCount; i++) {
                EbxRef ebx = new EbxRef();
                int nameOffset = reader.ReadLEInt();
                ebx.Size = reader.ReadLEInt();
                ebx.Name = ReadName(reader, stringOffset + nameOffset);
                sb.Ebx.Add(ebx);
            }
        }

        private static string ReadName(BinaryReader reader, long offset) {
            long pos = reader.BaseStream.Position;
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            string result = reader.ReadNullTerminatedString();
            reader.BaseStream.Seek(pos, SeekOrigin.Begin);
            return result;
        }
    }
}
