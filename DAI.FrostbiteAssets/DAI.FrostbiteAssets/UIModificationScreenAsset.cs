using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIModificationScreenAsset : UIItemScreenAsset
	{
		[FieldOffset(76, 208)]
		public List<UIModificationCategoryData> Categories { get; set; }

		public UIModificationScreenAsset()
		{
			Categories = new List<UIModificationCategoryData>();
		}
	}
}
