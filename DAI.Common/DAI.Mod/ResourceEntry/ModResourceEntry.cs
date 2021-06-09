using System;
using System.Xml;

using DAI.AssetLibrary.Utilities;

//TODO: reconcile w OG manager
namespace DAI.Mod {
    public abstract class ModResourceEntry {
        public string Name;

        public string NameHash;

        public string Type;
        // chunk, res, or ebx

        public string Action;

        public Sha1 OriginalSha1;

        public Sha1 NewSha1;

        public int ResourceID;

        public long OriginalSize;

        public long Size;

        public byte PatchType;

        public Sha1 DeltaSha1;

        public Sha1 BaseSha1;

        public bool IsEnabled;

        public ModResourceEntry(string InName, string InType, string InAction) {
            Name = InName;
            NameHash = Name.EncodeAsSha1().HexStringValue;
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
                        NameHash = attribute.Value.EncodeAsSha1().HexStringValue;
                        break;
                    case "type":
                        Type = attribute.Value;
                        break;
                    case "action":
                        Action = attribute.Value;
                        break;
                    case "originalsha1":
                        OriginalSha1 = new Sha1(attribute.Value);
                        break;
                    case "sha1":
                        if (Action == "delete") {
                            NewSha1 = new Sha1(attribute.Value);
                        } else {
                            OriginalSha1 = new Sha1(attribute.Value);
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
                        DeltaSha1 = new Sha1(attribute.Value);
                        break;
                    case "basesha1": {
                            BaseSha1 = new Sha1(attribute.Value);
                            //// TODO check
                            //byte[] numArray3 = new byte[20];
                            //string value3 = attribute.Value;
                            //for (int i = 0; i < 40; i += 2) {
                            //    string str6 = value3.Substring(0, 2);
                            //    value3 = value3.Remove(0, 2);
                            //    byte num5 = byte.Parse(str6, NumberStyles.HexNumber);
                            //    numArray3[i / 2] = num5;
                            //}
                            //BaseSha1 = new Sha1(numArray3);
                            break;
                        }
                }
            }
        }
    }
}
