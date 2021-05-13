using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_SetTarget : BTTaskFunc
	{
		[FieldOffset(12, 32)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(16, 36)]
		public TargetSlot Slot { get; set; }
	}
}
