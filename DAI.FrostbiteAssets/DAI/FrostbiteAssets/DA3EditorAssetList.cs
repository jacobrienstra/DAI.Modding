using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3EditorAssetList : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<TextureAsset>> Assets { get; set; }

		public DA3EditorAssetList()
		{
			Assets = new List<ExternalObject<TextureAsset>>();
		}
	}
}
