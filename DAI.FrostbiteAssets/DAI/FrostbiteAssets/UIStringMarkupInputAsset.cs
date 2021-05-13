using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIStringMarkupInputAsset : UIStringMarkupAsset
	{
		[FieldOffset(16, 40)]
		public UIInputAction Action { get; set; }

		[FieldOffset(20, 48)]
		public List<UIStringMarkupInputAssetData> ImageDatas { get; set; }

		public UIStringMarkupInputAsset()
		{
			ImageDatas = new List<UIStringMarkupInputAssetData>();
		}
	}
}
