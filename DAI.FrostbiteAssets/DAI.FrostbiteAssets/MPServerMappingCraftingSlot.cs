using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingCraftingSlot : MPServerMappingBase
	{
		[FieldOffset(12, 48)]
		public CraftingSlotType GameCraftingSlotType { get; set; }
	}
}
