using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_EquipSlot : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public EquipSlot Value { get; set; }
	}
}
