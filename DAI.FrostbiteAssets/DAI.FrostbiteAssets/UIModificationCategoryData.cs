using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIModificationCategoryData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ItemGuiCategory GuiCategory { get; set; }

		[FieldOffset(4, 4)]
		public EquipItemModCategory ModCategory { get; set; }

		[FieldOffset(8, 8)]
		public LocalizedStringReference CategoryLabel { get; set; }

		[FieldOffset(12, 32)]
		public string IconLabel { get; set; }
	}
}
