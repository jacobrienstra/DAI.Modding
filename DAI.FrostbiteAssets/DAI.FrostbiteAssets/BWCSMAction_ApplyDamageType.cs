using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyDamageType : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public EquipSlot Slot { get; set; }

		[FieldOffset(32, 76)]
		public int DamageType { get; set; }

		[FieldOffset(36, 80)]
		public bool UseContextSlot { get; set; }

		[FieldOffset(37, 81)]
		public bool FireAndForget { get; set; }
	}
}
