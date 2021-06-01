using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UILocalizedScreenAsset : UIScreenAsset
	{
		[FieldOffset(60, 176)]
		public string Namespace { get; set; }

		[FieldOffset(64, 184)]
		public List<UIScreenAssetLocalizedLabel> LocalizedLabels { get; set; }

		public UILocalizedScreenAsset()
		{
			LocalizedLabels = new List<UIScreenAssetLocalizedLabel>();
		}
	}
}
