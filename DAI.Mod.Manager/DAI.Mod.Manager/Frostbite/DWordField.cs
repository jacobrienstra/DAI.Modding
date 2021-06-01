using System.IO;

namespace DAI.ModManager.Frostbite {
    public class DWordField : DAIField {
        public int DWordValue;

        public DWordField() {
            DataType = 8;
        }

        public override int GetSize() {
            return base.GetSize() + 4;
        }

        public override void Write(BinaryWriter Writer) {
            base.Write(Writer);
            Writer.Write(DWordValue);
        }
    }
}
