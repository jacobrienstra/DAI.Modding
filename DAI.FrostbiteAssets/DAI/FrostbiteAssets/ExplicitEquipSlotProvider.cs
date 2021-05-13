using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ExplicitEquipSlotProvider : EquipSlotProvider
	{
		[FieldOffset(8, 32)]
		public EquipSlot Slot { get; set; }
	}
}
