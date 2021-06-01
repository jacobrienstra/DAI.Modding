using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class UIAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<Asset>> AssetReferences { get; set; }

		[FieldOffset(16, 80)]
		public long SwfMovieResource { get; set; }

		public UIAsset()
		{
			AssetReferences = new List<ExternalObject<Asset>>();
		}
	}
}
