using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MultiTextureAtlasResult : Asset
	{
		[FieldOffset(12, 72)]
		public List<OnDemandTextureInfo> OnDemandTextures { get; set; }

		[FieldOffset(16, 80)]
		public List<MultiTextureAtlasPart> SubAtlases { get; set; }

		public MultiTextureAtlasResult()
		{
			OnDemandTextures = new List<OnDemandTextureInfo>();
			SubAtlases = new List<MultiTextureAtlasPart>();
		}
	}
}
