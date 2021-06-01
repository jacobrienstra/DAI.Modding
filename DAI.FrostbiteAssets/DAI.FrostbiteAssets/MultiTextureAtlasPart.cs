using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MultiTextureAtlasPart : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<MultiTextureAtlasPartInfo> AtlasInfos { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<TextureAsset> AtlasTexture { get; set; }

		public MultiTextureAtlasPart()
		{
			AtlasInfos = new List<MultiTextureAtlasPartInfo>();
		}
	}
}
