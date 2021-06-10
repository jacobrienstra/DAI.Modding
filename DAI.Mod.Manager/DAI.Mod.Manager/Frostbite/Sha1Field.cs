using System.IO;

using DAI.AssetLibrary.Utilities;

namespace DAI.Mod.Manager.Frostbite {
    public class Sha1Field : DAIField {
        public Sha1 Sha1Value;

        public Sha1Field() {
            DataType = 16;
        }

        public override int GetSize() {
            return base.GetSize() + 20;
        }

        public override void Write(BinaryWriter Writer) {
            base.Write(Writer);
            Writer.Write(Sha1Value.BytesValue);
        }

        public override string ToString() {
            return "{" + Sha1Value.ToString() + "}";
        }
    }
}
