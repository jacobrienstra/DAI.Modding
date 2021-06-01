using System;
using System.Globalization;
using System.Xml;

using DAI.AssetLibrary.Utilities.Extensions;
//TODO: reconcile w OG manager
namespace DAI.Mod {
    public abstract class ModResourceEntry {
        public string Name;

        public string NameHash;

        public string Type;

        public string Action;

        public string OriginalSha1;

        public string NewSha1;

        public int ResourceID;

        public long OriginalSize;

        public long Size;

        public byte PatchType;

        public string DeltaSha1;

        public string BaseSha1;

        public bool IsEnabled;

        public ModResourceEntry(string InName, string InType, string InAction) {
            Name = InName;
            NameHash = Name.ToSha1();
            Type = InType;
            Action = InAction;
            IsEnabled = true;
        }

        public ModResourceEntry(string type) {
            Type = type;
            IsEnabled = true;
        }

        public ModResourceEntry(XmlAttributeCollection attributes, string type)
            : this(type) {
            foreach (XmlAttribute attribute in attributes) {
                string attributeName = attribute.Name;
                if (attributeName == null) {
                    continue;
                }
                switch (attributeName.ToLower()) {
                    case "name":
                        Name = attribute.Value;
                        NameHash = attribute.Value.ToSha1();
                        break;
                    case "type":
                        Type = attribute.Value;
                        break;
                    case "action":
                        Action = attribute.Value;
                        break;
                    case "originalsha1":
                        OriginalSha1 = attribute.Value;
                        break;
                    case "sha1":
                        if (Action == "delete") {
                            NewSha1 = attribute.Value;
                        } else {
                            OriginalSha1 = attribute.Value;
                        }
                        break;
                    case "resourceid":
                        ResourceID = Convert.ToInt32(attribute.Value);
                        break;
                    case "originalsize":
                        OriginalSize = Convert.ToInt64(attribute.Value);
                        break;
                    case "size":
                        Size = Convert.ToInt64(attribute.Value);
                        break;
                    case "patch":
                        PatchType = Convert.ToByte(attribute.Value);
                        break;
                    case "deltasha1":
                        DeltaSha1 = attribute.Value;
                        break;
                    case "basesha1": {
                            char[] numArray3 = new char[20];
                            string value3 = attribute.Value;
                            for (int i = 0; i < 40; i += 2) {
                                string str6 = value3.Substring(0, 2);
                                value3 = value3.Remove(0, 2);
                                char num5 = (char)byte.Parse(str6, NumberStyles.HexNumber);
                                numArray3[i / 2] = num5;
                            }
                            BaseSha1 = new string(numArray3);
                            break;
                        }
                }
            }
        }

        protected string Get20Sha1From40Sha1(string value) {
            if (string.IsNullOrEmpty(value)) {
                throw new Exception(string.Format("File {0} does not have sha1", Name));
            }
            char[] bytes = new char[20];
            for (int i = 0; i < 40; i += 2) {
                string s = value.Substring(0, 2);
                value = value.Remove(0, 2);
                char num4 = (char)byte.Parse(s, NumberStyles.HexNumber);
                bytes[i / 2] = num4;
            }
            return new string(bytes);
        }

        public void CopyPatchSha1(DAIEntry Entry) {
            int num = (Entry.HasField("casPatchType") ? Entry.GetDWordValue("casPatchType") : 0);
            PatchType = (byte)num;
            OriginalSha1 = Entry.GetSha1Value("sha1");
            if (num == 2) {
                DeltaSha1 = Entry.GetSha1Value("deltaSha1");
                BaseSha1 = Entry.GetSha1Value("baseSha1");
            }
        }

        public void CopyChunkFields(DAIEntry Entry, DAIEntry ChunkMetaEntry) {
            LogicalOffset = Entry.GetDWordValue("logicalOffset");
            LogicalSize = Entry.GetDWordValue("logicalSize");
            if (Entry.HasField("rangeStart")) {
                RangeStart = Entry.GetDWordValue("rangeStart");
                RangeEnd = Entry.GetDWordValue("rangeEnd");
            }
            ChunkH32 = ChunkMetaEntry.GetDWordValue("h32");
            Meta = Utils.MetaToString(ChunkMetaEntry.GetByteArrayValue("meta"));
            CopyPatchSha1(Entry);
        }

        public static void ModifyResourceEntry(ModResourceEntry BundleEntry, DAIEntry daiEntry3) {
            daiEntry3.RemoveField("casPatchType");
            daiEntry3.RemoveField("baseSha1");
            daiEntry3.RemoveField("deltaSha1");
            daiEntry3.SetSha1Value("sha1", BundleEntry.NewSha1);
            daiEntry3.SetQWordValue("size", BundleEntry.Size);
            daiEntry3.SetQWordValue("originalSize", BundleEntry.OriginalSize);
            if (BundleEntry.Type == "res") {
                daiEntry3.SetDWordValue("resType", (uint)BundleEntry.ResType);
                daiEntry3.SetByteArrayValue("resMeta", Utils.StringToMeta(BundleEntry.Meta));
                daiEntry3.SetQWordValue("resRid", BundleEntry.ResRid);
            }
            daiEntry3.AddDWordValue("casPatchType", BundleEntry.PatchType);
            if (BundleEntry.PatchType == 2) {
                daiEntry3.AddSha1Value("baseSha1", BundleEntry.BaseSha1);
                daiEntry3.AddSha1Value("deltaSha1", BundleEntry.DeltaSha1);
            }
        }

        public static void BuildDAIEntry(DAIEntry daiEntry1, ModResourceEntry modResourceEntry) {
            string text = ((modResourceEntry.Type == "chunk") ? "chunks" : modResourceEntry.Type);
            DAIEntry dAIEntry = new DAIEntry();
            if (text == "chunks") {
                dAIEntry.AddDQWordValue("id", Utils.StringToDQWord(modResourceEntry.Name));
            } else {
                dAIEntry.AddStringValue("name", modResourceEntry.Name);
            }
            dAIEntry.AddSha1Value("sha1", modResourceEntry.OriginalSha1);
            if (text != "chunks") {
                if (!daiEntry1.HasField(text)) {
                    daiEntry1.AddListValue(text, new List<DAIEntry>());
                }
                dAIEntry.AddQWordValue("size", modResourceEntry.Size);
                dAIEntry.AddQWordValue("originalSize", modResourceEntry.OriginalSize);
                if (text == "res") {
                    dAIEntry.AddDWordValue("resType", (uint)modResourceEntry.ResType);
                    DAIField dAIField = dAIEntry.AddByteArrayValue("resMeta", Utils.StringToMeta(modResourceEntry.Meta));
                    dAIField.DataType = 19;
                    dAIEntry.AddQWordValue("resRid", modResourceEntry.ResRid);
                }
            } else {
                if (!daiEntry1.HasField("chunks")) {
                    daiEntry1.AddListValue("chunks", new List<DAIEntry>());
                    daiEntry1.AddListValue("chunkMeta", new List<DAIEntry>());
                }
                dAIEntry.AddDWordValue("size", (uint)modResourceEntry.Size);
                if (modResourceEntry.RangeStart != modResourceEntry.RangeEnd) {
                    dAIEntry.AddDWordValue("rangeStart", (uint)modResourceEntry.RangeStart);
                    dAIEntry.AddDWordValue("rangeEnd", (uint)modResourceEntry.RangeEnd);
                }
                dAIEntry.AddDWordValue("logicalOffset", (uint)modResourceEntry.LogicalOffset);
                dAIEntry.AddDWordValue("logicalSize", (uint)modResourceEntry.LogicalSize);
                DAIEntry dAIEntry2 = new DAIEntry();
                dAIEntry2.AddDWordValue("h32", (uint)modResourceEntry.ChunkH32);
                dAIEntry2.AddByteArrayValue("meta", Utils.StringToMeta(modResourceEntry.Meta));
                daiEntry1.AddListChild("chunkMeta", dAIEntry2);
            }
            dAIEntry.AddDWordValue("casPatchType", modResourceEntry.PatchType);
            if (modResourceEntry.PatchType == 2) {
                dAIEntry.AddSha1Value("baseSha1", modResourceEntry.BaseSha1);
                dAIEntry.AddSha1Value("deltaSha1", modResourceEntry.DeltaSha1);
            } else if (modResourceEntry.PatchType == 0) {
                dAIEntry.RemoveField("casPatchType");
            }
            daiEntry1.AddListChild(text, dAIEntry);
        }
    }
}
