using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EquipmentIsSlotEmptyData : EntityData
	{
		[FieldOffset(16, 96)]
		public EquipSlot Slot { get; set; }
	}
}
