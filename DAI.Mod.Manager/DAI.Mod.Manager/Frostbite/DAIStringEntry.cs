using System.IO;

using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.Mod.Manager.Frostbite {
    internal class DAIStringEntry : DAIEntry {
        public string StringValue;

        public DAIStringEntry(byte InEntryType, int InEntrySize, int InEntryOffset) {
            EntryType = InEntryType;
            EntrySize = InEntrySize;
            EntryOffset = InEntryOffset;
            StringValue = "";
        }

        public DAIStringEntry() {
            StringValue = "";
        }

        public override int GetSize() {
            return DAIToc.GetSize128(StringValue.Length + 1) + (StringValue.Length + 1) + 1;
        }

        public override void Write(BinaryWriter Writer) {
            EntryOffset = (int)Writer.BaseStream.Position;
            Writer.Write((byte)135);
            DAIToc.Write128(Writer, StringValue.Length + 1);
            Writer.WriteNullTerminatedString(StringValue);
        }
    }
}
