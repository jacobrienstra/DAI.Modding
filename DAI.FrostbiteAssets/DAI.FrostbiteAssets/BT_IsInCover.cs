using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_IsInCover : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(20, 44)]
		public TacticsTarget CoverFromTarget { get; set; }

		[FieldOffset(24, 48)]
		public float SearchRadius { get; set; }

		[FieldOffset(28, 52)]
		public float MaxTargetDistance { get; set; }

		[FieldOffset(32, 56)]
		public float StopThreshold { get; set; }

		[FieldOffset(36, 64)]
		public ExternalObject<Dummy> LOSTestHeight { get; set; }

		[FieldOffset(40, 72)]
		public MoveToCoverType CoverTactic { get; set; }

		[FieldOffset(44, 76)]
		public bool CheckIfCurrentCoverIsSuitable { get; set; }

		[FieldOffset(45, 77)]
		public bool AvoidCoverOwnedByHostiles { get; set; }

		[FieldOffset(46, 78)]
		public bool AvoidCoverThatTheTargetIsCloserTo { get; set; }

		[FieldOffset(47, 79)]
		public bool AttemptToFlank { get; set; }

		[FieldOffset(48, 80)]
		public bool ChooseCoverWithLineOfSight { get; set; }
	}
}
