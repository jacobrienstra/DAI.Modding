using System;
using System.IO;

using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Assets.Bases {
    public class Texture {
        public uint MipOneEndOffset;

        public uint MipTwoEndOffset;

        public TextureType TextureType;

        public TextureFormat PixelFormat;

        public ushort Unknown04;

        public short Width;

        public short Height;

        public short Depth;

        public short SliceCount;

        public byte NumSizes;

        public byte FirstMip;

        public Guid ChunkID;

        public int[] MipSizes;

        public byte[] Data;

        public int ChunkSize;

        public uint NameHash;

        public byte[] Name;

        public Texture() {
            MipSizes = new int[15];
        }

        public static Texture FromRes(ResRef res) {
            using (MemoryStream ms = new MemoryStream(PayloadProvider.GetAssetPayload(res))) {
                using (BinaryReader binaryReader = new BinaryReader(ms)) {
                    Texture texture = new Texture();
                    texture.Serialize(binaryReader);
                    return texture;
                }
            }
        }

        public void Serialize(BinaryReader Reader) {
            MipOneEndOffset = Reader.ReadUInt32();
            MipTwoEndOffset = Reader.ReadUInt32();
            TextureType = (TextureType)Reader.ReadUInt32();
            PixelFormat = (TextureFormat)Reader.ReadInt32();
            Unknown04 = Reader.ReadUInt16();
            Width = Reader.ReadInt16();
            Height = Reader.ReadInt16();
            Depth = Reader.ReadInt16();
            SliceCount = Reader.ReadInt16();
            NumSizes = Reader.ReadByte();
            FirstMip = Reader.ReadByte();
            ChunkID = Reader.ReadGuid();
            for (int i = 0; i < 15; i++) {
                MipSizes[i] = Reader.ReadInt32();
            }
            ChunkSize = Reader.ReadInt32();
            NameHash = Reader.ReadUInt32();
            Name = new byte[16];
            Name = Reader.ReadBytes(16);
            Data = PayloadProvider.GetAssetPayload(Library.GetChunkById(ChunkID));
        }

        public MemoryStream WriteToStream() {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            binaryWriter.Write(MipOneEndOffset);
            binaryWriter.Write(MipTwoEndOffset);
            binaryWriter.Write((uint)TextureType);
            binaryWriter.Write((uint)PixelFormat);
            binaryWriter.Write(Unknown04);
            binaryWriter.Write(Width);
            binaryWriter.Write(Height);
            binaryWriter.Write(Depth);
            binaryWriter.Write(SliceCount);
            binaryWriter.Write(NumSizes);
            binaryWriter.Write(FirstMip);
            binaryWriter.Write(ChunkID);
            for (int i = 0; i < 15; i++) {
                binaryWriter.Write(MipSizes[i]);
            }
            binaryWriter.Write(ChunkSize);
            binaryWriter.Write(NameHash);
            binaryWriter.Write(Name);
            binaryWriter.Close();
            return memoryStream;
        }
    }
}
