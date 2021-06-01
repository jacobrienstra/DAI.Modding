using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovementBehaviorOrbit : MovementBehavior
	{
		[FieldOffset(24, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(28, 44)]
		public float MoveDistance { get; set; }

		[FieldOffset(32, 48)]
		public float InnerRadius { get; set; }

		[FieldOffset(36, 52)]
		public float OuterRadius { get; set; }

		[FieldOffset(40, 56)]
		public float InnerSpeedModifier { get; set; }

		[FieldOffset(44, 60)]
		public float OuterSpeedModifier { get; set; }

		[FieldOffset(48, 64)]
		public float RadiusConvergenceRate { get; set; }

		[FieldOffset(52, 68)]
		public float UpdateTime { get; set; }

		[FieldOffset(56, 72)]
		public float UpdateTimeVariance { get; set; }

		[FieldOffset(60, 76)]
		public float TurnAroundChance { get; set; }

		[FieldOffset(64, 80)]
		public float TurnAroundTimeout { get; set; }
	}
}
