using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_BalancedTimeDilation : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public float RealTimeDuration { get; set; }

		[FieldOffset(32, 76)]
		public float DilationValue { get; set; }

		[FieldOffset(36, 80)]
		public float RecoveryTime { get; set; }

		[FieldOffset(40, 84)]
		public TimeShape DilationShape { get; set; }

		[FieldOffset(44, 88)]
		public TimeShape RecoveryShape { get; set; }
	}
}
