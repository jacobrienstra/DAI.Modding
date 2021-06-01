using System.IO;

namespace DAI.Mod.Manager.Frostbite {
    public class QWordField : DAIField {
        public long QWordValue;

        public QWordField() {
            DataType = 9;
        }

        public override int GetSize() {
            return base.GetSize() + 8;
        }

        public override void Write(BinaryWriter Writer) {
            base.Write(Writer);
            Writer.Write(QWordValue);
        }
    }
}
