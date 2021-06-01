using System.IO;

using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Assets.Bases {
    public class ComplexObjectDescriptor {
        public string FieldName { get; set; }

        public int FieldStartIndex { get; set; }

        public byte FieldCount { get; set; }

        public byte Alignment { get; set; }

        public ComplexObjectType FieldType { get; set; }

        public short FieldSize { get; set; }

        public short SecondarySize { get; set; }

        public ComplexObjectDescriptor() {
        }

        public ComplexObjectDescriptor(string InFieldName, int InStartIndex, byte InCount, byte InAlignment, ushort InType, short InSize, short InSecondarySize) {
            FieldName = InFieldName;
            FieldStartIndex = InStartIndex;
            FieldCount = InCount;
            Alignment = InAlignment;
            FieldType = (ComplexObjectType)InType;
            FieldSize = InSize;
            SecondarySize = InSecondarySize;
        }

        public void Read(BinaryReader Reader, EbxBase EbxFile) {
            FieldName = EbxFile.KeywordDict[Reader.ReadInt32()];
            FieldStartIndex = Reader.ReadInt32();
            FieldCount = Reader.ReadByte();
            Alignment = Reader.ReadByte();
            FieldType = (ComplexObjectType)Reader.ReadUInt16();
            FieldSize = Reader.ReadInt16();
            SecondarySize = Reader.ReadInt16();
        }

        public override string ToString() {
            return FieldName;
        }

        public void Write(BinaryWriter Writer) {
            Writer.Write(FieldName.Hash());
            Writer.Write(FieldStartIndex);
            Writer.Write(FieldCount);
            Writer.Write(Alignment);
            Writer.Write((ushort)FieldType);
            Writer.Write(FieldSize);
            Writer.Write(SecondarySize);
        }
    }
}
