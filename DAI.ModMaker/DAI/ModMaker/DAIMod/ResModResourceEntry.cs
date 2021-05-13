using System;
using System.Xml;

using DAI.AssetLibrary.Assets.References;

namespace DAI.ModMaker.DAIMod
{
    public class ResModResourceEntry : ModResourceEntry
    {
        public int ResType;

        public long ResRid;

        public string Meta;

        public ResModResourceEntry()
            : base("res")
        {
        }

        public ResModResourceEntry(XmlAttributeCollection attributes)
            : base(attributes, "res")
        {
            foreach (XmlAttribute attribute in attributes)
            {
                string attributeName = attribute.Name;
                if (attributeName != null)
                {
                    switch (attributeName.ToLower())
                    {
                        case "restype":
                            ResType = Convert.ToInt32(attribute.Value);
                            break;
                        case "resrid":
                            ResRid = Convert.ToInt64(attribute.Value);
                            break;
                        case "meta":
                            Meta = attribute.Value;
                            break;
                    }
                }
            }
        }

        public ResModResourceEntry(ResRef res, string action)
            : base(res.Name, "res", action)
        {
        }
    }
}
