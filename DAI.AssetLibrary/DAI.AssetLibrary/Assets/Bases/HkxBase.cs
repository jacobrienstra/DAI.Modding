using System.Collections.Generic;
using System.IO;
using System.Reflection;

using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.AssetLibrary.Assets.Bases {
    public class HkxBase {
        public class HkxClassDescriptor {
            public uint Signature;

            public byte Version;

            public string Name;

            public void Serialize(BinaryReader Reader) {
                Signature = Reader.ReadUInt32();
                Version = Reader.ReadByte();
                Name = Reader.ReadNullTerminatedString();
            }
        }

        public class HkxHeader {
            public uint StartOffset;

            public uint Magic1;

            public uint Magic2;

            public uint UserTag;

            public uint FileVersion;

            public uint LayoutRules;

            public uint NumSections;

            public uint ContentsSectionIndex;

            public uint ContentsSectionOffset;

            public uint ContentsClassNameSectionIndex;

            public uint ContentsClassNameSectionOffset;

            public string ContentsVersion;

            public uint Flags;

            public uint Padding;

            public bool IsValid() {
                if (Magic1 != 1474355287) {
                    return false;
                }
                return Magic2 == 281067536;
            }

            public void Serialize(BinaryReader Reader) {
                Magic1 = Reader.ReadUInt32();
                do {
                    Reader.BaseStream.Seek(-3L, SeekOrigin.Current);
                    Magic1 = Reader.ReadUInt32();
                }
                while (Magic1 != 1474355287);
                StartOffset = (uint)((int)Reader.BaseStream.Position - 4);
                Magic2 = Reader.ReadUInt32();
                if (Magic2 == 281067536) {
                    UserTag = Reader.ReadUInt32();
                    FileVersion = Reader.ReadUInt32();
                    LayoutRules = Reader.ReadUInt32();
                    NumSections = Reader.ReadUInt32();
                    ContentsSectionIndex = Reader.ReadUInt32();
                    ContentsSectionOffset = Reader.ReadUInt32();
                    ContentsClassNameSectionIndex = Reader.ReadUInt32();
                    ContentsClassNameSectionOffset = Reader.ReadUInt32();
                    ContentsVersion = Reader.ReadTerminatedString(byte.MaxValue);
                    Flags = Reader.ReadUInt32();
                    Padding = Reader.ReadUInt32();
                }
            }
        }

        public HkxHeader Header { get; set; }

        public List<hkObject> Objects { get; set; }

        public static HkxBase FromRes(ResRef res) {
            byte[] payload = PayloadProvider.GetAssetPayload(res);
            if (payload == null) {
                return null;
            }
            using (MemoryStream ms = new MemoryStream(payload)) {
                using (BinaryReader reader = new BinaryReader(ms)) {
                    HkxBase hkxBase = new HkxBase();
                    hkxBase.Serialize(reader);
                    return hkxBase;
                }
            }
        }

        public void Serialize(BinaryReader Reader) {
            Header = new HkxHeader();
            Header.Serialize(Reader);
            if (!Header.IsValid()) {
                return;
            }
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            while ((ulong)num6 < (ulong)Header.NumSections) {
                string str = Reader.ReadTerminatedString(byte.MaxValue);
                if (str.Contains("__classnames__")) {
                    num = Reader.ReadInt32();
                    Reader.ReadInt64();
                    num2 = Reader.ReadInt32();
                    Reader.BaseStream.Seek(12L, SeekOrigin.Current);
                    num6++;
                } else if (!str.Contains("__types__")) {
                    if (str.Contains("__data__")) {
                        num3 = Reader.ReadInt32();
                        Reader.ReadInt32();
                        Reader.ReadInt32();
                        num4 = Reader.ReadInt32();
                        num5 = Reader.ReadInt32();
                        Reader.BaseStream.Seek(8L, SeekOrigin.Current);
                        num6++;
                    }
                } else {
                    Reader.ReadInt32();
                    Reader.BaseStream.Seek(24L, SeekOrigin.Current);
                    num6++;
                }
            }
            Reader.BaseStream.Seek(Header.StartOffset + num, SeekOrigin.Begin);
            Dictionary<long, HkxClassDescriptor> nums = new Dictionary<long, HkxClassDescriptor>();
            while (Reader.BaseStream.Position < Header.StartOffset + num + num2) {
                long position = Reader.BaseStream.Position - (Header.StartOffset + num);
                HkxClassDescriptor hkxClassDescriptor = new HkxClassDescriptor();
                hkxClassDescriptor.Serialize(Reader);
                nums.Add(position + 5, hkxClassDescriptor);
            }
            Reader.BaseStream.Seek(Header.StartOffset + num3, SeekOrigin.Begin);
            Reader.BaseStream.Seek(num4, SeekOrigin.Current);
            int startOffset = (int)(Header.StartOffset + num3 + num5);
            long position2 = 0L;
            Objects = new List<hkObject>();
            while (Reader.BaseStream.Position < startOffset) {
                long num7 = Reader.ReadInt64();
                int num8 = Reader.ReadInt32();
                if (num8 != -1 && Reader.BaseStream.Position < startOffset) {
                    HkxClassDescriptor item = nums[num8];
                    hkObject _hkBaseClass = (hkObject)Assembly.GetExecutingAssembly().CreateInstance("DAI.AssetLibrary.Assets.Bases" + item.Name);
                    if (_hkBaseClass != null) {
                        position2 = Reader.BaseStream.Position;
                        Reader.BaseStream.Seek(Header.StartOffset + num3 + num7, SeekOrigin.Begin);
                        _hkBaseClass.Serialize(Reader);
                        Objects.Add(_hkBaseClass);
                        Reader.BaseStream.Seek(position2, SeekOrigin.Begin);
                    }
                }
            }
        }
    }
}
