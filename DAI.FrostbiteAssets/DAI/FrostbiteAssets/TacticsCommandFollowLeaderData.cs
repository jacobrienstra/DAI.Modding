using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticsCommandFollowLeaderData : TacticsCommandData
	{
		[FieldOffset(16, 96)]
		public TacticsTarget TargetToFollow { get; set; }

		[FieldOffset(20, 100)]
		public float FollowDistance { get; set; }

		[FieldOffset(24, 104)]
		public float ArcSpread { get; set; }

		[FieldOffset(28, 108)]
		public bool StopWithinRange { get; set; }
	}
}
