using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_SetShaderParameterOnEquipment : BWCSMAction_SetShaderParameter
	{
		[FieldOffset(80, 128)]
		public EquipSlot Slot { get; set; }

		[FieldOffset(84, 132)]
		public bool UseContextSlot { get; set; }
	}
}
