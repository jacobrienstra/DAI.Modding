using System.IO;

using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.Mod.Manager.Frostbite {
    public class DAIField {
        public byte DataType;

        public string FieldName;

        public DAIField() {
            DataType = 0;
            FieldName = "";
        }

        public virtual int GetSize() {
            return FieldName.Length + 2;
        }

        public virtual void Write(BinaryWriter Writer) {
            Writer.Write(DataType);
            Writer.WriteNullTerminatedString(FieldName);
        }
    }
}
