using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RecipeSlot : DataContainer
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference SlotName { get; set; }

		[FieldOffset(12, 48)]
		public CraftingSlotType SlotType { get; set; }

		[FieldOffset(16, 56)]
		public ExternalObject<StackedItemAsset> CustomMaterial { get; set; }

		[FieldOffset(20, 64)]
		public RecipeMaterialTypes MaterialType { get; set; }

		[FieldOffset(24, 68)]
		public uint MaterialUsedCount { get; set; }

		[FieldOffset(28, 72)]
		public int SlotIdx { get; set; }
	}
}
