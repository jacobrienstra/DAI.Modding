using System;
using System.Xml;

using DAI.AssetLibrary.Assets.References;
using DAI.AssetLibrary.Utilities.Extensions;

namespace DAI.Mod {
    public partial class ChunkModResourceEntry : ModResourceEntry {
        public int RangeStart;

        public int RangeEnd;

        public int LogicalOffset;

        public int LogicalSize;

        public int ChunkH32;

        public string Meta;

        public ChunkModResourceEntry()
            : base("chunk") {
        }

        public ChunkModResourceEntry(XmlAttributeCollection attributes)
            : base(attributes, "chunk") {
            foreach (XmlAttribute attribute in attributes) {
                string attributeName = attribute.Name;
                if (attributeName != null) {
                    switch (attributeName.ToLower()) {
                        case "rangestart":
                            RangeStart = Convert.ToInt32(attribute.Value);
                            break;
                        case "rangeend":
                            RangeEnd = Convert.ToInt32(attribute.Value);
                            break;
                        case "logicaloffset":
                            LogicalOffset = Convert.ToInt32(attribute.Value);
                            break;
                        case "logicalsize":
                            LogicalSize = Convert.ToInt32(attribute.Value);
                            break;
                        case "chunkh32":
                            ChunkH32 = Convert.ToInt32(attribute.Value);
                            break;
                        case "meta":
                            Meta = attribute.Value;
                            break;
                    }
                }
            }
        }

        public ChunkModResourceEntry(ChunkRef chunk, string action)
            : base(chunk.ChunkId.ToSha1(), "chunk", action) {
        }

        public ChunkModResourceEntry(string chunkIDSha1HexString, string action)
            : base(chunkIDSha1HexString, "chunk", action) {
        }
    }
}
