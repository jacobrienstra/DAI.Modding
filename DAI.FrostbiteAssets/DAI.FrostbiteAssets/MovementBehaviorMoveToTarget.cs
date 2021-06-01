using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class MovementBehaviorMoveToTarget : MovementBehavior
	{
		[FieldOffset(24, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(28, 44)]
		public float StopThreshold { get; set; }

		[FieldOffset(32, 48)]
		public Vec3 Offset { get; set; }

		[FieldOffset(48, 64)]
		public float UpdatePeriod { get; set; }

		[FieldOffset(52, 72)]
		public ExternalObject<FloatProvider> LOSTestHeight { get; set; }

		[FieldOffset(56, 80)]
		public bool UseSelfAttackRadius { get; set; }

		[FieldOffset(57, 81)]
		public bool UseTargetAttackRadius { get; set; }

		[FieldOffset(58, 82)]
		public bool RequiresLineOfSight { get; set; }

		[FieldOffset(59, 83)]
		public bool OffsetIsCameraRelative { get; set; }
	}
}
