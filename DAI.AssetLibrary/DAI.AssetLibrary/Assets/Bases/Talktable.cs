using System.Collections.Generic;
using System.IO;
using System.Text;

using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;

namespace DAI.AssetLibrary.Assets.Bases {
    public class Talktable {
        public class AlphaEntry {
            public bool[] list;

            public char c;
        }

        public class HuffNode {
            public HuffNode e0;

            public HuffNode e1;

            public char c;

            public long w;

            public int index;

            public bool hasIndex;

            public HuffNode(char chr, long weight) {
                object obj = null;
                HuffNode huffNode = (HuffNode)obj;
                e1 = (HuffNode)obj;
                e0 = huffNode;
                c = chr;
                w = weight;
                hasIndex = false;
            }
        }

        public class TalktableString {
            public string DisplayValue => "[" + ID.ToString("X8") + "] " + Value;

            public uint ID { get; set; }

            public TalktableStringState State { get; internal set; }

            public string SanitizedDisplayValue {
                get {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("[" + ID.ToString("X8") + "] ");
                    stringBuilder.Append(Value.Replace("\n", "[n]").Replace("\r", "[r]").Replace("\t", "[t]"));
                    return stringBuilder.ToString();
                }
            }

            public string Value { get; internal set; }

            internal string OriginalValue { get; set; }

            public TalktableString() {
                State = TalktableStringState.NoChanges;
            }
        }

        public class StringID {
            public uint ID;

            public uint offset;
        }

        public enum TalktableStringState {
            NoChanges,
            Added,
            Modified
        }

        public List<TalktableString> Strings;

        private List<int> NodeList;

        private List<StringID> StringList;

        private List<uint> BitStream;

        public uint magic;

        public int unk01;

        public int DataOffset;

        public int unk02;

        public int unk03;

        public int unk04;

        public int Data1Count;

        public int Data1Offset;

        public int Data2Count;

        public int Data2Offset;

        public int Data3Count;

        public int Data3Offset;

        public int Data4Count;

        public int Data4Offset;

        public int Data5Count;

        public int Data5Offset;

        public List<int> Data1;

        public List<uint> StringIDs;

        public List<int> StringData;

        public List<uint> Data;

        public List<ulong> Data3;

        public List<ulong> Data4;

        public List<ulong> Data5;

        public void CalcIndex(HuffNode h) {
            if (h.e0 == null && h.e1 == null && !h.hasIndex) {
                int num = (h.index = ((h.c < 'Ā') ? ((short)(65535 - (short)h.c)) : (-1 - h.c)));
                h.hasIndex = true;
                return;
            }
            CalcIndex(h.e0);
            CalcIndex(h.e1);
            if (h.e0.hasIndex && h.e1.hasIndex) {
                h.index = NodeList.Count / 2;
                h.hasIndex = true;
                NodeList.Add(h.e0.index);
                NodeList.Add(h.e1.index);
            }
        }

        public AlphaEntry[] GetAlphabet(HuffNode h, List<bool> list) {
            List<AlphaEntry> alphaEntries = new List<AlphaEntry>();
            if (h.e0.e0 != null) {
                List<bool> flags = new List<bool>();
                flags.AddRange(list);
                flags.Add(false);
                alphaEntries.AddRange(GetAlphabet(h.e0, flags));
            } else {
                AlphaEntry alphaEntry = new AlphaEntry {
                    c = h.e0.c
                };
                List<bool> flags2 = new List<bool>();
                flags2.AddRange(list);
                flags2.Add(false);
                alphaEntry.list = flags2.ToArray();
                alphaEntries.Add(alphaEntry);
            }
            if (h.e1.e0 != null) {
                List<bool> flags3 = new List<bool>();
                flags3.AddRange(list);
                flags3.Add(true);
                alphaEntries.AddRange(GetAlphabet(h.e1, flags3));
            } else {
                AlphaEntry array = new AlphaEntry {
                    c = h.e1.c
                };
                List<bool> flags4 = new List<bool>();
                flags4.AddRange(list);
                flags4.Add(true);
                array.list = flags4.ToArray();
                alphaEntries.Add(array);
            }
            return alphaEntries.ToArray();
        }

        public bool Read(BinaryReader Reader) {
            magic = Reader.ReadUInt32();
            unk01 = Reader.ReadInt32();
            DataOffset = Reader.ReadInt32();
            unk02 = Reader.ReadInt32();
            unk03 = Reader.ReadInt32();
            unk04 = Reader.ReadInt32();
            Data1Count = Reader.ReadInt32();
            Data1Offset = Reader.ReadInt32();
            Data2Count = Reader.ReadInt32();
            Data2Offset = Reader.ReadInt32();
            Data3Count = Reader.ReadInt32();
            Data3Offset = Reader.ReadInt32();
            Data4Count = Reader.ReadInt32();
            Data4Offset = Reader.ReadInt32();
            if (Data4Count > 0) {
                Data5Count = Reader.ReadInt32();
                Data5Offset = Reader.ReadInt32();
            }
            Reader.BaseStream.Seek(DataOffset, SeekOrigin.Begin);
            Data = new List<uint>();
            while (Reader.BaseStream.Position < Reader.BaseStream.Length) {
                Data.Add(Reader.ReadUInt32());
            }
            Reader.BaseStream.Seek(Data1Offset, SeekOrigin.Begin);
            Data1 = new List<int>();
            for (int i = 0; i < Data1Count; i++) {
                Data1.Add(Reader.ReadInt32());
            }
            Reader.BaseStream.Seek(Data2Offset, SeekOrigin.Begin);
            StringIDs = new List<uint>();
            StringData = new List<int>();
            for (int j = 0; j < Data2Count; j++) {
                StringIDs.Add(Reader.ReadUInt32());
                StringData.Add(Reader.ReadInt32());
            }
            Reader.BaseStream.Seek(Data3Offset, SeekOrigin.Begin);
            Data3 = new List<ulong>();
            for (int k = 0; k < Data3Count; k++) {
                Data3.Add(Reader.ReadUInt64());
            }
            Reader.BaseStream.Seek(Data4Offset, SeekOrigin.Begin);
            Data4 = new List<ulong>();
            for (int l = 0; l < Data4Count; l++) {
                Data4.Add(Reader.ReadUInt64());
            }
            Data5 = new List<ulong>();
            if (Data4Count > 0) {
                Reader.BaseStream.Seek(Data5Offset, SeekOrigin.Begin);
                for (int m = 0; m < Data5Count; m++) {
                    Data5.Add(Reader.ReadUInt64());
                }
            }
            Strings = new List<TalktableString>();
            for (int n = 0; n < StringIDs.Count; n++) {
                TalktableString sTR = new TalktableString {
                    ID = StringIDs[n],
                    Value = ""
                };
                int item = StringData[n] >> 5;
                int num = StringData[n] & 0x1F;
                StringBuilder stringBuilder = new StringBuilder();
                while (true) {
                    int count = Data1.Count / 2 - 1;
                    while (count >= 0) {
                        int num2 = (int)((Data[item] >> num) & 1);
                        count = Data1[count * 2 + num2];
                        num++;
                        item += num >> 5;
                        num %= 32;
                    }
                    ushort num3 = (ushort)(-1 - count);
                    if (num3 == 0) {
                        break;
                    }
                    stringBuilder.Append((char)num3);
                }
                sTR.Value = stringBuilder.ToString();
                Strings.Add(sTR);
            }
            return true;
        }

        public static Talktable FromRes(ResRef res) {
            byte[] payload = PayloadProvider.GetAssetPayload(res);
            if (payload == null) {
                return null;
            }
            using (MemoryStream ms = new MemoryStream(payload)) {
                using (BinaryReader binaryReader = new BinaryReader(ms)) {
                    Talktable talktable = new Talktable();
                    talktable.Read(binaryReader);
                    return talktable;
                }
            }
        }

        public MemoryStream Save() {
            long[] numArray = new long[65536];
            foreach (TalktableString @string in Strings) {
                numArray[0]++;
                string value = @string.Value;
                for (int i = 0; i < value.Length; i++) {
                    numArray[(uint)value[i]] = numArray[(uint)value[i]] + 1;
                }
            }
            Dictionary<char, long> chrs = new Dictionary<char, long>();
            for (int j = 0; j < 65536; j++) {
                if (numArray[j] > 0) {
                    chrs.Add((char)j, numArray[j]);
                }
            }
            List<HuffNode> huffNodes = new List<HuffNode>();
            foreach (KeyValuePair<char, long> chr in chrs) {
                huffNodes.Add(new HuffNode(chr.Key, chr.Value));
            }
            while (huffNodes.Count > 1) {
                bool flag = true;
                while (flag) {
                    flag = false;
                    for (int k = 0; k < huffNodes.Count - 1; k++) {
                        if (huffNodes[k].w > huffNodes[k + 1].w) {
                            flag = true;
                            HuffNode item = huffNodes[k];
                            huffNodes[k] = huffNodes[k + 1];
                            huffNodes[k + 1] = item;
                        }
                    }
                }
                HuffNode huffNode = huffNodes[0];
                HuffNode item2 = huffNodes[1];
                HuffNode huffNode2 = new HuffNode(' ', huffNode.w + item2.w) {
                    e0 = huffNode,
                    e1 = item2
                };
                huffNodes.RemoveAt(1);
                huffNodes.RemoveAt(0);
                huffNodes.Add(huffNode2);
            }
            HuffNode item3 = huffNodes[0];
            NodeList = new List<int>();
            while (!item3.hasIndex) {
                CalcIndex(item3);
            }
            AlphaEntry[] alphabet = GetAlphabet(item3, new List<bool>());
            BitStream = new List<uint>();
            StringList = new List<StringID>();
            uint num = 0u;
            uint num2 = 0u;
            byte num3 = 0;
            foreach (TalktableString sTR in Strings) {
                StringID stringID = new StringID {
                    ID = sTR.ID,
                    offset = num2 << 5
                };
                stringID.offset += num3;
                string str = sTR.Value + "\0";
                foreach (char chr2 in str) {
                    AlphaEntry alphaEntry = null;
                    AlphaEntry[] alphaEntryArray = alphabet;
                    foreach (AlphaEntry alphaEntry2 in alphaEntryArray) {
                        if (alphaEntry2.c == chr2) {
                            alphaEntry = alphaEntry2;
                        }
                    }
                    bool[] flagArray = alphaEntry.list;
                    foreach (bool num5 in flagArray) {
                        byte num4 = 0;
                        if (num5) {
                            num4 = 1;
                        }
                        if (num3 < 32) {
                            num = (uint)(num + (num4 << (num3 & 0x1F)));
                            num3 = (byte)(num3 + 1);
                        }
                        if (num3 == 32) {
                            BitStream.Add(num);
                            num2++;
                            num3 = 0;
                            num = 0u;
                        }
                    }
                }
                StringList.Add(stringID);
            }
            BitStream.Add(num);
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            Data1Offset = ((Data5.Count > 0) ? 64 : 56);
            Data2Offset = Data1Offset + NodeList.Count * 4;
            Data3Offset = Data2Offset + StringList.Count * 8;
            Data4Offset = Data3Offset + Data3.Count * 8;
            Data5Offset = Data4Offset + Data4.Count * 8;
            DataOffset = Data5Offset + Data5.Count * 8;
            binaryWriter.Write((int)magic);
            binaryWriter.Write(unk01);
            binaryWriter.Write(DataOffset);
            binaryWriter.Write(unk02);
            binaryWriter.Write(unk03);
            binaryWriter.Write(unk04);
            binaryWriter.Write(NodeList.Count);
            binaryWriter.Write(Data1Offset);
            binaryWriter.Write(StringList.Count);
            binaryWriter.Write(Data2Offset);
            binaryWriter.Write(Data3.Count);
            binaryWriter.Write(Data3Offset);
            binaryWriter.Write(Data4.Count);
            binaryWriter.Write(Data4Offset);
            if (Data5.Count > 0) {
                binaryWriter.Write(Data5.Count);
                binaryWriter.Write(Data5Offset);
            }
            foreach (int nodeList in NodeList) {
                binaryWriter.Write(nodeList);
            }
            foreach (StringID stringList in StringList) {
                binaryWriter.Write((int)stringList.ID);
                binaryWriter.Write((int)stringList.offset);
            }
            foreach (ulong data3 in Data3) {
                binaryWriter.Write(data3);
            }
            foreach (ulong data4 in Data4) {
                binaryWriter.Write(data4);
            }
            foreach (ulong data5 in Data5) {
                binaryWriter.Write(data5);
            }
            foreach (uint bitStream in BitStream) {
                binaryWriter.Write((int)bitStream);
            }
            return memoryStream;
        }
    }
}
