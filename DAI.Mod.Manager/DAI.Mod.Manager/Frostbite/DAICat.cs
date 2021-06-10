using System.Collections.Generic;
using System.IO;
using System.Threading;

using DAI.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;
using DAI.AssetLibrary.Utilities;

namespace DAI.Mod.Manager.Frostbite {
    public class DAICat {
        private static DAICat Instance;

        public Dictionary<Sha1, DAICatEntry> Entries;

        private DAICat() {
            Entries = new Dictionary<Sha1, DAICatEntry>();
        }

        public static DAICat Get() {
            return Instance ?? (Instance = new DAICat());
        }

        public void Serialize(string CatPath) {
            BinaryReader binaryReader = new BinaryReader(FileHelpers.UnXorFile(CatPath));
            binaryReader.BaseStream.Seek(16L, SeekOrigin.Begin);
            while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length) {
                DAICatEntry dAICatEntry = new DAICatEntry();
                Sha1 key = binaryReader.ReadSha1();
                dAICatEntry.Offset = binaryReader.ReadInt32();
                dAICatEntry.Size = binaryReader.ReadInt32();
                int num = binaryReader.ReadInt32();
                dAICatEntry.Path = CatPath.Replace("cas.cat", "") + "cas_" + ((num < 10) ? "0" : "") + num + ".cas";
                if (Entries.ContainsKey(key)) {
                    Entries[key] = dAICatEntry;
                } else {
                    Entries.Add(key, dAICatEntry);
                }
            }
            binaryReader.Close();
        }

        public static Dictionary<Sha1, DAICatEntry> SerializeLocal(string CatPath) {
            Dictionary<Sha1, DAICatEntry> dictionary = new Dictionary<Sha1, DAICatEntry>();
            BinaryReader binaryReader = new BinaryReader(FileHelpers.UnXorFile(CatPath));
            binaryReader.BaseStream.Seek(16L, SeekOrigin.Begin);
            while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length) {
                DAICatEntry dAICatEntry = new DAICatEntry();
                Sha1 key = binaryReader.ReadSha1();
                dAICatEntry.Offset = binaryReader.ReadInt32();
                dAICatEntry.Size = binaryReader.ReadInt32();
                int num = binaryReader.ReadInt32();
                dAICatEntry.Path = CatPath.Replace("cas.cat", "") + "cas_" + ((num < 10) ? "0" : "") + num + ".cas";
                if (dictionary.ContainsKey(key)) {
                    dictionary[key] = dAICatEntry;
                } else {
                    dictionary.Add(key, dAICatEntry);
                }
            }
            binaryReader.Close();
            return dictionary;
        }

        public MemoryStream GetCompressedPayloadFromFile(string Filename, long Offset, int Size) {
            FileStream fileStream = new FileStream(Filename, FileMode.Open);
            fileStream.Seek(Offset, SeekOrigin.Begin);
            int num = 0;
            while (num < 10) {
                try {
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    byte[] buffer = new byte[Size];
                    binaryReader.BaseStream.Read(buffer, 0, Size);
                    binaryReader.Close();
                    return new MemoryStream(buffer);
                } catch (IOException) {
                    int num2 = num + 1;
                    num = num2;
                    Thread.Sleep(100);
                }
            }
            return null;
        }

        public void GetSizes(Sha1 Sha1Value, out int Size, out int OriginalSize) {
            Size = 0;
            OriginalSize = 0;
            if (!Entries.ContainsKey(Sha1Value)) {
                return;
            }
            DAICatEntry dAICatEntry = Entries[Sha1Value];
            BinaryReader binaryReader = new BinaryReader(new FileStream(dAICatEntry.Path, FileMode.Open));
            binaryReader.BaseStream.Seek(dAICatEntry.Offset, SeekOrigin.Begin);
            uint num;
            do {
                num = binaryReader.ReadUInt32BE();
                uint num2 = binaryReader.ReadUInt16();
                uint num3 = binaryReader.ReadUInt16BE();
                if (num == 4207808496u) {
                    binaryReader.BaseStream.Seek(-8L, SeekOrigin.Current);
                    break;
                }
                switch (num2) {
                    case 28674u:
                        binaryReader.ReadBytes((int)num3);
                        OriginalSize += (int)num;
                        Size += (int)num3;
                        break;
                    case 28672u:
                        binaryReader.ReadBytes((int)num3);
                        OriginalSize += (int)num3;
                        Size += (int)num3;
                        break;
                    case 28928u:
                        binaryReader.ReadBytes((int)num);
                        OriginalSize += (int)num;
                        Size += (int)num3;
                        break;
                    default:
                        binaryReader.ReadBytes((int)num3);
                        OriginalSize += (int)num3;
                        Size += (int)num3;
                        break;
                }
            }
            while (num == 65536);
            binaryReader.Close();
        }
    }
}
