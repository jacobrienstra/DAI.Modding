using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovementBehaviorMoveToCover : MovementBehavior
	{
		[FieldOffset(24, 40)]
		public float SearchRadius { get; set; }

		[FieldOffset(28, 44)]
		public float MaxTargetDistance { get; set; }

		[FieldOffset(32, 48)]
		public float StopThreshold { get; set; }

		[FieldOffset(36, 56)]
		public ExternalObject<FloatProvider> LOSTestHeight { get; set; }

		[FieldOffset(40, 64)]
		public TacticsTarget CoverFromTarget { get; set; }

		[FieldOffset(44, 68)]
		public MoveToCoverType CoverTactic { get; set; }

		[FieldOffset(48, 72)]
		public bool AvoidCoverOwnedByHostiles { get; set; }

		[FieldOffset(49, 73)]
		public bool AvoidCoverThatTheTargetIsCloserTo { get; set; }

		[FieldOffset(50, 74)]
		public bool AttemptToFlank { get; set; }

		[FieldOffset(51, 75)]
		public bool FaceTarget { get; set; }

		[FieldOffset(52, 76)]
		public bool ChooseCoverWithLineOfSight { get; set; }

		[FieldOffset(53, 77)]
		public bool RespectTether { get; set; }
	}
}
