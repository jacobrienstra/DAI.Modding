using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovementBehaviorHoldPosition : MovementBehavior
	{
		[FieldOffset(24, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(28, 44)]
		public float UpdatePeriod { get; set; }

		[FieldOffset(32, 48)]
		public float FaceOnceTolerance { get; set; }

		[FieldOffset(36, 52)]
		public bool FaceTarget { get; set; }

		[FieldOffset(37, 53)]
		public bool FaceOnceContinue { get; set; }
	}
}
