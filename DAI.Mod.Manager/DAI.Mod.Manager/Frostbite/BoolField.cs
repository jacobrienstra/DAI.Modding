using System.IO;

namespace DAI.Mod.Manager.Frostbite {
    public class BoolField : DAIField {
        public bool BoolValue;

        public BoolField() {
            DataType = 6;
        }

        public override int GetSize() {
            return base.GetSize() + 1;
        }

        public override void Write(BinaryWriter Writer) {
            base.Write(Writer);
            Writer.Write(BoolValue);
        }

        public override string ToString() {
            return "{ " + FieldName + " = " + BoolValue + " }";
        }
    }
}
