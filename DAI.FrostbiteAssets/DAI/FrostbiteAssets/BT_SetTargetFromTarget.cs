using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_SetTargetFromTarget : BTTaskFunc
	{
		[FieldOffset(12, 32)]
		public TacticsTarget SourceTargetEntity { get; set; }

		[FieldOffset(16, 36)]
		public TacticsTarget SourceTargetType { get; set; }

		[FieldOffset(20, 40)]
		public TargetSlot Slot { get; set; }
	}
}
