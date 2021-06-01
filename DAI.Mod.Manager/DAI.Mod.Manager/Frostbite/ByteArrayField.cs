using System.IO;

namespace DAI.Mod.Manager.Frostbite {
    public class ByteArrayField : DAIField {
        public byte[] ByteValue;

        public ByteArrayField() {
            DataType = 2;
        }

        public override int GetSize() {
            return base.GetSize() + DAIToc.GetSize128(ByteValue.Length) + ByteValue.Length;
        }

        public override void Write(BinaryWriter Writer) {
            base.Write(Writer);
            DAIToc.Write128(Writer, ByteValue.Length);
            Writer.Write(ByteValue);
        }
    }
}
