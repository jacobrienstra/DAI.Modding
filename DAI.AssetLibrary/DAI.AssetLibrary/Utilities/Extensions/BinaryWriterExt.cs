using System;
using System.IO;

namespace DAI.AssetLibrary.Utilities.Extensions {
    public static class BinaryWriterExt {
        public static void WriteNullTerminatedString(this BinaryWriter Writer, string Value) {
            if (Value != null) {
                for (int i = 0; i < Value.Length; i++) {
                    Writer.Write((byte)Value[i]);
                }
            }
            Writer.Write((byte)0);
        }

        public static void Write(this BinaryWriter Writer, Guid Value) {
            Writer.Write(Value.ToByteArray());
        }
    }
}
