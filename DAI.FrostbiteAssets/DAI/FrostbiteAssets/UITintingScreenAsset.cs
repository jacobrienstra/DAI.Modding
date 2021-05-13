using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITintingScreenAsset : UIItemScreenAsset
	{
		[FieldOffset(76, 208)]
		public List<UITintingCategoryData> Categories { get; set; }

		public UITintingScreenAsset()
		{
			Categories = new List<UITintingCategoryData>();
		}
	}
}
