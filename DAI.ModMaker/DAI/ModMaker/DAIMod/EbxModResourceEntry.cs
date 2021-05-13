using System.Xml;

using DAI.AssetLibrary.Assets.References;

namespace DAI.ModMaker.DAIMod
{
    public class EbxModResourceEntry : ModResourceEntry
    {
        public EbxModResourceEntry()
            : base("ebx")
        {
        }

        public EbxModResourceEntry(XmlAttributeCollection attributes)
            : base(attributes, "ebx")
        {
            foreach (XmlAttribute attribute in attributes)
            {
                attribute.Name?.ToLower();
            }
        }

        public EbxModResourceEntry(EbxRef ebx, string action)
            : base(ebx.Name, "ebx", action)
        {
        }
    }
}
