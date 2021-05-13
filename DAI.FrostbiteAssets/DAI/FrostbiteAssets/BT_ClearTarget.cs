using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_ClearTarget : BTTaskFunc
	{
		[FieldOffset(12, 32)]
		public TargetSlot Slot { get; set; }
	}
}
