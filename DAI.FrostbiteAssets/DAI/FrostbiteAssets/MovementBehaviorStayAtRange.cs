using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovementBehaviorStayAtRange : MovementBehavior
	{
		[FieldOffset(24, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(28, 44)]
		public float Range { get; set; }

		[FieldOffset(32, 48)]
		public float StrafeLeftRightDistance { get; set; }

		[FieldOffset(36, 52)]
		public float UpdatePeriod { get; set; }

		[FieldOffset(40, 56)]
		public float StrafeUpdatePeriod { get; set; }

		[FieldOffset(44, 60)]
		public float DesiredTargetArc { get; set; }

		[FieldOffset(48, 64)]
		public float ArcAngleThreshold { get; set; }

		[FieldOffset(52, 68)]
		public float PositionTolerance { get; set; }

		[FieldOffset(56, 72)]
		public bool StrafeChooseNewArc { get; set; }

		[FieldOffset(57, 73)]
		public bool PickArcBasedOnFacing { get; set; }

		[FieldOffset(58, 74)]
		public bool UseMirroredArcs { get; set; }

		[FieldOffset(59, 75)]
		public bool UseWorldSpaceArcs { get; set; }

		[FieldOffset(60, 76)]
		public bool RequireClearGroundAttackPath { get; set; }

		[FieldOffset(61, 77)]
		public bool UseDynamicClusterSearch { get; set; }

		[FieldOffset(62, 78)]
		public bool StrafeMovement { get; set; }

		[FieldOffset(63, 79)]
		public bool RespectTether { get; set; }
	}
}
