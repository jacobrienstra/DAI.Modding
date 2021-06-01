using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_IsInRange : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public int PositionBoneId { get; set; }

		[FieldOffset(20, 44)]
		public int FacingBoneId { get; set; }

		[FieldOffset(24, 48)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(28, 52)]
		public TacticsTarget TargetTwo { get; set; }

		[FieldOffset(32, 56)]
		public ExternalObject<BWRange> Range { get; set; }

		[FieldOffset(36, 64)]
		public ExternalObject<BWRange> MinRange { get; set; }

		[FieldOffset(40, 72)]
		public float OverrideRange { get; set; }

		[FieldOffset(44, 76)]
		public float ArcSize { get; set; }

		[FieldOffset(48, 80)]
		public float ArcOffset { get; set; }

		[FieldOffset(52, 84)]
		public bool UseAttackRangeForTargetOne { get; set; }

		[FieldOffset(53, 85)]
		public bool UseAttackRangeForTargetTwo { get; set; }

		[FieldOffset(54, 86)]
		public bool Test2D { get; set; }
	}
}
