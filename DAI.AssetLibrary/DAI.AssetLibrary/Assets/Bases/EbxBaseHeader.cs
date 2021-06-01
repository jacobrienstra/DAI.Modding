using System.IO;

namespace DAI.AssetLibrary.Assets.Bases {
    public class EbxBaseHeader {
        public int StringOffset;

        public int StringLengthToEOF;

        public int ExternalGuidCount;

        public short InstanceRepeaterCount;

        public short GuidRepeaterCount;

        public short Unknown01;

        public short ComplexEntryCount;

        public short FieldCount;

        public short NameLength;

        public int StringsLength;

        public int ArrayRepeaterCount;

        public int PayloadLength;

        public int ArraySectionStart;

        public int PayloadStart => StringOffset + StringsLength;

        public void Read(BinaryReader Reader) {
            StringOffset = (int)Reader.ReadUInt32();
            StringLengthToEOF = (int)Reader.ReadUInt32();
            ExternalGuidCount = (int)Reader.ReadUInt32();
            InstanceRepeaterCount = (short)Reader.ReadUInt16();
            GuidRepeaterCount = (short)Reader.ReadUInt16();
            Unknown01 = (short)Reader.ReadUInt16();
            ComplexEntryCount = (short)Reader.ReadUInt16();
            FieldCount = (short)Reader.ReadUInt16();
            NameLength = (short)Reader.ReadUInt16();
            StringsLength = (int)Reader.ReadUInt32();
            ArrayRepeaterCount = (int)Reader.ReadUInt32();
            PayloadLength = (int)Reader.ReadUInt32();
            ArraySectionStart = StringOffset + StringsLength + PayloadLength;
        }

        public void Write(BinaryWriter Writer) {
            Writer.Write((uint)StringOffset);
            Writer.Write((uint)StringLengthToEOF);
            Writer.Write((uint)ExternalGuidCount);
            Writer.Write((ushort)InstanceRepeaterCount);
            Writer.Write((ushort)GuidRepeaterCount);
            Writer.Write((ushort)Unknown01);
            Writer.Write((ushort)ComplexEntryCount);
            Writer.Write((ushort)FieldCount);
            Writer.Write((ushort)NameLength);
            Writer.Write((uint)StringsLength);
            Writer.Write((uint)ArrayRepeaterCount);
            Writer.Write((uint)PayloadLength);
        }
    }
}
