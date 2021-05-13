using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemManagerEntity_EquipSlotInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public EquipSlot Slot { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference DisplayName { get; set; }
	}
}
