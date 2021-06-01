using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_OverrideEquipmentSocket : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public EquipSlot Slot { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<BlendedSocketInfo> Transform { get; set; }
	}
}
