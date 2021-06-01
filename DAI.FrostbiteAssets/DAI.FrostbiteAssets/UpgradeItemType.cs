using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpgradeItemType : BaseItemType
	{
		[FieldOffset(48, 160)]
		public ExternalObject<ItemPartType> PartType { get; set; }

		[FieldOffset(52, 168)]
		public UpgradeItemCraftingCategory CraftingCategory { get; set; }

		[FieldOffset(56, 172)]
		public bool IsRune { get; set; }

		[FieldOffset(57, 173)]
		public bool IsSigil { get; set; }

		[FieldOffset(58, 174)]
		public bool IsForBianca { get; set; }
	}
}
