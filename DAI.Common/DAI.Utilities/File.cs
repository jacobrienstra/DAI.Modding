using System.Collections.Generic;
using System.IO;

namespace DAI.Utilities {
    public static class File {

        public static Dictionary<string, string> ReadMftFromFile(string Filename) {
            StreamReader streamReader = new StreamReader(Filename);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            while (!streamReader.EndOfStream) {
                string text = streamReader.ReadLine();
                string value = ((text.IndexOf(' ') != -1) ? text.Remove(0, text.IndexOf(' ')).Trim() : "");
                string key = ((text.IndexOf(' ') != -1) ? text.Remove(text.IndexOf(' ')) : text);
                dictionary.Add(key, value);
            }
            streamReader.Close();
            return dictionary;
        }

        public static MemoryStream UnXorFile(string Path) {
            List<byte> list = new List<byte>();
            BinaryReader binaryReader = new BinaryReader(new FileStream(Path, FileMode.Open, FileAccess.Read));
            switch (binaryReader.ReadInt32()) {
                case 13553920:
                case 30331136: {
                        binaryReader.BaseStream.Seek(296L, SeekOrigin.Begin);
                        byte[] array = new byte[260];
                        int num = 0;
                        while (num < 260) {
                            int num2 = binaryReader.ReadByte() ^ 0x7B;
                            array[num] = (byte)num2;
                            int num3 = num + 1;
                            num = num3;
                        }
                        int num4 = 0;
                        while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length) {
                            byte b = array[num4 % 257];
                            byte b2 = binaryReader.ReadByte();
                            list.Add((byte)(b ^ b2));
                        }
                        break;
                    }
                case 63885568:
                    binaryReader.BaseStream.Seek(556L, SeekOrigin.Begin);
                    list.AddRange(binaryReader.ReadBytes((int)binaryReader.BaseStream.Length - 556));
                    break;
                default:
                    binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
                    list.AddRange(binaryReader.ReadBytes((int)binaryReader.BaseStream.Length));
                    break;
            }
            binaryReader.Close();
            return new MemoryStream(list.ToArray());
        }
    }
}
