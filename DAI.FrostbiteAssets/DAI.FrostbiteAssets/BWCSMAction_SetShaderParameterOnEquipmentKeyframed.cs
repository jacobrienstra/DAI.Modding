using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_SetShaderParameterOnEquipmentKeyframed : BWCSMAction_SetShaderParameterKeyframed
	{
		[FieldOffset(112, 176)]
		public EquipSlot Slot { get; set; }

		[FieldOffset(116, 180)]
		public bool UseContextSlot { get; set; }
	}
}
