using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovementBehaviorGuard : MovementBehavior
	{
		[FieldOffset(24, 40)]
		public TacticsTarget Enemy { get; set; }

		[FieldOffset(28, 44)]
		public TacticsTarget Ally { get; set; }

		[FieldOffset(32, 48)]
		public float MaxRangeFromAlly { get; set; }

		[FieldOffset(36, 52)]
		public float MinRangeFromEnemy { get; set; }

		[FieldOffset(40, 56)]
		public float UpdatePeriod { get; set; }
	}
}
