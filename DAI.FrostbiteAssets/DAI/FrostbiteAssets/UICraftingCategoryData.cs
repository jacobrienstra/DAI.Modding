using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICraftingCategoryData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ItemGuiCategory GuiCategory { get; set; }

		[FieldOffset(4, 4)]
		public EquipItemCraftingCategory EquipCategory { get; set; }

		[FieldOffset(8, 8)]
		public UpgradeItemCraftingCategory UpgradeCategory { get; set; }

		[FieldOffset(12, 16)]
		public LocalizedStringReference CategoryLabel { get; set; }

		[FieldOffset(16, 40)]
		public string IconLabel { get; set; }
	}
}
