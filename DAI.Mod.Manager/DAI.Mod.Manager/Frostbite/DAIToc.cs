using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

using DAI.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;
using DAI.Mod.Manager.Utilities;

namespace DAI.Mod.Manager.Frostbite {
    public class DAIToc {
        private static readonly byte[] TocHeader = new byte[556]
        {
            0, 209, 206, 3, 0, 0, 0, 0, 120, 97,
            51, 55, 100, 100, 52, 53, 102, 102, 101, 49,
            48, 48, 98, 102, 102, 102, 99, 99, 57, 55,
            53, 51, 97, 97, 98, 97, 99, 51, 50, 53,
            102, 48, 55, 99, 98, 51, 102, 97, 50, 51,
            49, 49, 52, 52, 102, 101, 50, 101, 51, 51,
            97, 101, 52, 55, 56, 51, 102, 101, 101, 97,
            100, 50, 98, 56, 97, 55, 51, 102, 102, 48,
            50, 49, 102, 97, 99, 51, 50, 54, 100, 102,
            48, 101, 102, 57, 55, 53, 51, 97, 98, 57,
            99, 100, 102, 54, 53, 55, 51, 100, 100, 102,
            102, 48, 51, 49, 50, 102, 97, 98, 48, 98,
            48, 102, 102, 51, 57, 55, 55, 57, 101, 97,
            102, 102, 51, 49, 50, 97, 52, 102, 53, 100,
            101, 54, 53, 56, 57, 50, 102, 102, 101, 101,
            51, 51, 97, 52, 52, 53, 54, 57, 98, 101,
            98, 102, 50, 49, 102, 54, 54, 100, 50, 50,
            101, 53, 52, 97, 50, 50, 51, 52, 55, 101,
            102, 100, 51, 55, 53, 57, 56, 49, 49, 56,
            56, 55, 52, 51, 97, 102, 100, 57, 57, 98,
            97, 97, 99, 99, 51, 52, 50, 100, 56, 56,
            97, 57, 57, 51, 50, 49, 50, 51, 53, 55,
            57, 56, 55, 50, 53, 102, 101, 100, 99, 98,
            102, 52, 51, 50, 53, 50, 54, 54, 57, 100,
            97, 100, 101, 51, 50, 52, 49, 53, 102, 101,
            101, 56, 57, 100, 97, 53, 52, 51, 98, 102,
            50, 51, 100, 52, 101, 120, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0
        };

        private static ThreadLocal<StringBuilder> _builder = new ThreadLocal<StringBuilder>(() => new StringBuilder());

        public DAIEntry RootEntry;

        public bool HasBundles() {
            return RootEntry.HasField("bundles");
        }

        public bool HasChunks() {
            return RootEntry.HasField("chunks");
        }

        public List<DAIEntry> GetBundles() {
            return RootEntry.GetListValue("bundles");
        }

        public DAIEntry GetRootEntry() {
            return RootEntry;
        }

        public void SetRootEntry(DAIEntry Entry) {
            RootEntry = Entry;
        }

        public void WriteToFile(string Filename, bool bWriteTocHeader = false) {
            if (RootEntry.HasField("bundles")) {
                foreach (DAIEntry item in RootEntry.GetListValue("bundles")) {
                    if (!item.HasField("totalSize")) {
                        continue;
                    }
                    long num = 0L;
                    if (item.HasField("ebx")) {
                        num += item.GetListValue("ebx").Sum((DAIEntry daiEntry2) => daiEntry2.GetQWordValue("size"));
                    }
                    if (item.HasField("res")) {
                        num += item.GetListValue("res").Sum((DAIEntry daiEntry2) => daiEntry2.GetQWordValue("size"));
                    }
                    if (item.HasField("chunks")) {
                        num = item.GetListValue("chunks").Aggregate(num, (long current, DAIEntry daiEntry2) => current + daiEntry2.GetDWordValue("size"));
                    }
                    item.SetQWordValue("totalSize", num);
                }
            }
            string path = Filename.Remove(Filename.LastIndexOf('\\'));
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(Filename, FileMode.Create));
            if (bWriteTocHeader) {
                binaryWriter.Write(TocHeader);
            }
            RootEntry.Write(binaryWriter);
            binaryWriter.Close();
        }

        public static DAIToc ReadFromMemory(MemoryStream MemStream) {
            DAIToc dAIToc = new DAIToc();
            BinaryReader binaryReader = new BinaryReader(MemStream);
            dAIToc.Read(binaryReader);
            binaryReader.Close();
            return dAIToc;
        }

        public static DAIToc ReadFromStream(BinaryReader Reader, long Offset) {
            DAIToc dAIToc = new DAIToc();
            Reader.BaseStream.Seek(Offset, SeekOrigin.Begin);
            dAIToc.Read(Reader);
            return dAIToc;
        }

        public static DAIToc ReadFromFile(string Filename, long Offset = 0L) {
            DAIToc dAIToc = new DAIToc();
            BinaryReader binaryReader = new BinaryReader(FileHelpers.UnXorFile(Filename));
            binaryReader.BaseStream.Seek(Offset, SeekOrigin.Begin);
            dAIToc.Read(binaryReader);
            binaryReader.Close();
            return dAIToc;
        }

        public void Read(BinaryReader Reader) {
            RootEntry = ReadEntry(Reader);
        }

        public DAIEntry ReadEntry(BinaryReader Reader) {
            int inEntryOffset = (int)Reader.BaseStream.Position;
            byte b = Reader.ReadByte();
            if (b != 130) {
                return null;
            }
            int num = Read128(Reader);
            int num2 = (int)Reader.BaseStream.Position;
            DAIEntry dAIEntry = new DAIEntry(b, num, inEntryOffset);
            while ((int)Reader.BaseStream.Position - num2 < num) {
                AddField(Reader, dAIEntry);
            }
            return dAIEntry;
        }

        public void AddField(BinaryReader Reader, DAIEntry TheEntry) {
            byte b = Reader.ReadByte();
            if (b == 0) {
                return;
            }
            string fieldName = Reader.ReadNullTerminatedString();
            DAIField dAIField = null;
            if (b == 1) {
                dAIField = new ListField();
                ((ListField)dAIField).ChildEntries = new List<DAIEntry>();
                int num = Read128(Reader);
                int num2 = (int)Reader.BaseStream.Position;
                ((ListField)dAIField).ListSize = num;
                while ((int)Reader.BaseStream.Position - num2 < num - 1) {
                    ((ListField)dAIField).ChildEntries.Add(ReadEntry(Reader));
                }
                Reader.ReadByte();
            } else if (b == 7) {
                dAIField = new StringField();
                ((StringField)dAIField).StringValue = "";
                int num3 = Read128(Reader) - 1;
                StringBuilder value = _builder.Value;
                value.Clear();
                int num4 = 0;
                while (num4 < num3) {
                    value.Append((char)Reader.ReadByte());
                    int num5 = num4 + 1;
                    num4 = num5;
                }
                  ((StringField)dAIField).StringValue = value.ToString();
            } else if (b == 9) {
                dAIField = new QWordField();
                ((QWordField)dAIField).QWordValue = Reader.ReadInt64();
            } else if (b == 8) {
                dAIField = new DWordField();
                ((DWordField)dAIField).DWordValue = Reader.ReadInt32();
            } else if (b == 6) {
                dAIField = new BoolField();
                ((BoolField)dAIField).BoolValue = Reader.ReadByte() == 1;
            } else if (b == 16) {
                dAIField = new Sha1Field();
                ((Sha1Field)dAIField).Sha1Value = Reader.ReadSha1();
            } else if (b == 2 || b == 19) {
                dAIField = new ByteArrayField();
                int num6 = Read128(Reader);
                ((ByteArrayField)dAIField).ByteValue = new byte[num6];
                ((ByteArrayField)dAIField).ByteValue = Reader.ReadBytes(num6);
            } else if (b == 15) {
                dAIField = new DQWordField();
                ((DQWordField)dAIField).DQWordValue = Reader.ReadDQWord();
            }
            dAIField.DataType = b;
            dAIField.FieldName = fieldName;
            TheEntry.AddField(fieldName, dAIField);
        }

        public static int Read128(BinaryReader Reader) {
            int num = 0;
            int num2 = 0;
            while (true) {
                int num3 = Reader.ReadByte();
                num |= (num3 & 0x7F) << num2;
                if (num3 >> 7 != 0) {
                    num2 += 7;
                    continue;
                }
                break;
            }
            return num;
        }

        public static void Write128(BinaryWriter Writer, int Value) {
            int num = Value;
            while (num != 0) {
                int num2 = num & 0x7F;
                num >>= 7;
                if (num > 0) {
                    num2 |= 0x80;
                }
                Writer.Write((byte)num2);
            }
        }

        public static int GetSize128(int Value) {
            int num = 0;
            int num2 = Value;
            int num3 = num + 1;
            while (num2 != 0) {
                num2 >>= 7;
                if (num2 > 0) {
                    int num4 = num3 + 1;
                    num3 = num4;
                }
            }
            return num3;
        }
    }
}
