using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBWInventoryComponentCategoryData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ItemGuiCategory Category { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference CategoryLabel { get; set; }

		[FieldOffset(8, 32)]
		public string IconLabel { get; set; }

		[FieldOffset(12, 40)]
		public List<UIBWInventoryComponentSubcategoryData> SubcategoryList { get; set; }

		[FieldOffset(16, 48)]
		public string CategoriesToItemsFrameLabel { get; set; }

		[FieldOffset(20, 56)]
		public string ItemsToCategoriesFrameLabel { get; set; }

		[FieldOffset(24, 64)]
		public bool HideInMultiplayer { get; set; }

		public UIBWInventoryComponentCategoryData()
		{
			SubcategoryList = new List<UIBWInventoryComponentSubcategoryData>();
		}
	}
}
