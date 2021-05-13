using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISystemMenuScreenAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public List<UISystemMenuListData> Elements { get; set; }

		[FieldOffset(72, 200)]
		public PlotFlagReference Agents { get; set; }

		public UISystemMenuScreenAsset()
		{
			Elements = new List<UISystemMenuListData>();
		}
	}
}
