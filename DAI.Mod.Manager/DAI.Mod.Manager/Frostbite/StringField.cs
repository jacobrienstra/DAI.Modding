using System.IO;

using DAI.Utilities;
using DAI.Mod.Manager.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.Mod.Manager.Frostbite {
    public class StringField : DAIField {
        public string StringValue;

        private Sha1 _stringHash = null;

        public Sha1 StringHash => _stringHash ?? (_stringHash = new Sha1(StringValue.ToLower()));

        public StringField() {
            DataType = 7;
        }

        public override int GetSize() {
            return base.GetSize() + DAIToc.GetSize128(StringValue.Length + 1) + StringValue.Length + 1;
        }

        public override void Write(BinaryWriter Writer) {
            base.Write(Writer);
            DAIToc.Write128(Writer, StringValue.Length + 1);
            Writer.WriteNullTerminatedString(StringValue);
        }

        public override string ToString() {
            return "<" + StringValue + ">";
        }
    }
}
