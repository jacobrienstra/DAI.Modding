using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeroMenuScreenAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public PlotFlagReference Agents { get; set; }

		[FieldOffset(84, 232)]
		public List<UIHeroMenuListData> Elements { get; set; }

		public UIHeroMenuScreenAsset()
		{
			Elements = new List<UIHeroMenuListData>();
		}
	}
}
