using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIPotionCraftingScreenAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public List<PotionCategoryData> PotionCategories { get; set; }

		public UIPotionCraftingScreenAsset()
		{
			PotionCategories = new List<PotionCategoryData>();
		}
	}
}
