using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPartyManagerData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public float TetheringDistance { get; set; }

		[FieldOffset(24, 104)]
		public float TetheringCombatDistance { get; set; }

		[FieldOffset(28, 108)]
		public float PartyCatchupDistanceBehindPlayer { get; set; }

		[FieldOffset(32, 112)]
		public float PartyCatchupPathDistanceFromPlayer { get; set; }

		[FieldOffset(36, 120)]
		public PlotConditionReference MountSummonedCondition { get; set; }

		[FieldOffset(64, 200)]
		public float RepulsorBufferForTeleport { get; set; }
	}
}
