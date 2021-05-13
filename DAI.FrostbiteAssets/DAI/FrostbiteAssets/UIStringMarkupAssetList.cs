using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIStringMarkupAssetList : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<UIStringMarkupInputAsset>> Markups { get; set; }

		public UIStringMarkupAssetList()
		{
			Markups = new List<ExternalObject<UIStringMarkupInputAsset>>();
		}
	}
}
