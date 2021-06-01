using System.IO;

using DAI.ModManager.Utils;

namespace DAI.ModManager.Frostbite {
    public class DQWordField : DAIField {
        public DQWord DQWordValue;

        public DQWordField() {
            DataType = 15;
        }

        public override int GetSize() {
            return base.GetSize() + 16;
        }

        public override void Write(BinaryWriter Writer) {
            base.Write(Writer);
            Writer.Write(DQWordValue);
        }
    }
}
