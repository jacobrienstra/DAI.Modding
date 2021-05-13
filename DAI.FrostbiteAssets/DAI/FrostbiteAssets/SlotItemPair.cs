using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SlotItemPair : LinkObject
	{
		[FieldOffset(0, 0)]
		public EquipSlot Slot { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<EquipItemAsset> Item { get; set; }
	}
}
