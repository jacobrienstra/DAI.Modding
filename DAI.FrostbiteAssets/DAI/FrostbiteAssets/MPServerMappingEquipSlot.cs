using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingEquipSlot : MPServerMappingBase
	{
		[FieldOffset(12, 48)]
		public EquipSlot GameEquipSlotType { get; set; }
	}
}
