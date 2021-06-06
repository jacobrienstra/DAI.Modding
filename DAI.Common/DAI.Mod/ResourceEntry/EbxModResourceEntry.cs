using System.Xml;

using DAI.AssetLibrary.Assets.References;

namespace DAI.Mod {
    public class EbxModResourceEntry : ModResourceEntry {
        public EbxModResourceEntry()
            : base("ebx") {
        }

        public EbxModResourceEntry(XmlAttributeCollection attributes)
            : base(attributes, "ebx") {
            foreach (XmlAttribute attribute in attributes) {
                attribute.Name?.ToLower();
            }
        }

        public EbxModResourceEntry(EbxRef ebx, string action)
            : base(ebx.Name, "ebx", action) {
        }

        public EbxModResourceEntry(string ebxName, string action)
            : base(ebxName, "ebx", action) {
        }
    }
}
