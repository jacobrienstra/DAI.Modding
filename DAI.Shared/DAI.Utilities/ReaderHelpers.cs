using System.IO;
using System.Text;

namespace DAI.ModManager.Utils {
    public static class ReaderHelpers {
        public static Sha1 ReadSha1(this BinaryReader Reader) {
            Sha1 sha = new Sha1();
            int num = 0;
            while (num < 20) {
                sha.Sha1Value[num] = Reader.ReadByte();
                int num2 = num + 1;
                num = num2;
            }
            return sha;
        }

        public static uint ReadUInt32BE(this BinaryReader Reader) {
            return 0u | (uint)(Reader.ReadByte() << 24) | (uint)(Reader.ReadByte() << 16) | (uint)(Reader.ReadByte() << 8) | Reader.ReadByte();
        }

        public static uint ReadUInt16BE(this BinaryReader Reader) {
            return 0u | (uint)(Reader.ReadByte() << 8) | Reader.ReadByte();
        }

        public static Vector ReadVector(this BinaryReader Reader) {
            Vector vector = new Vector();
            vector.X = Reader.ReadSingle();
            vector.Y = Reader.ReadSingle();
            vector.Z = Reader.ReadSingle();
            return vector;
        }

        public static string ReadNullTerminatedString(this BinaryReader Reader) {
            StringBuilder stringBuilder = new StringBuilder();
            char value;
            while ((value = (char)Reader.ReadByte()) != 0) {
                stringBuilder.Append(value);
            }
            return stringBuilder.ToString();
        }

        public static string ReadTerminatedString(this BinaryReader Reader, byte Terminater) {
            string text = "";
            char c;
            do {
                c = (char)Reader.ReadByte();
                text += c;
            }
            while (c != Terminater);
            return text.Remove(text.Length - 1);
        }

        public static string ReadChunkID(this BinaryReader Reader) {
            string text = "";
            int num = 0;
            while (num < 16) {
                text += Reader.ReadByte().ToString("X2");
                int num2 = num + 1;
                num = num2;
            }
            return text;
        }

        public static DQWord ReadDQWord(this BinaryReader Reader) {
            DQWord dQWord = new DQWord(0uL, 0uL);
            dQWord.Value1 = Reader.ReadUInt64();
            dQWord.Value2 = Reader.ReadUInt64();
            return dQWord;
        }

        public static void Write(this BinaryWriter Writer, DQWord Value) {
            Writer.Write(Value.Value1);
            Writer.Write(Value.Value2);
        }

        public static void Write(this BinaryWriter Writer, Sha1 Value) {
            Writer.Write(Value.Sha1Value);
        }

        public static void WriteNullTerminatedString(this BinaryWriter Writer, string Value) {
            int num = 0;
            while (num < Value.Length) {
                Writer.Write((byte)Value[num]);
                int num2 = num + 1;
                num = num2;
            }
            Writer.Write((byte)0);
        }
    }
}
