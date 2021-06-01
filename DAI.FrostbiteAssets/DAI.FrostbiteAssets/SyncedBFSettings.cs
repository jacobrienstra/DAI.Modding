namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SyncedBFSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public float GameModeCounterModifier { get; set; }

		[FieldOffset(20, 44)]
		public bool AllUnlocksUnlocked { get; set; }

		[FieldOffset(21, 45)]
		public bool NoMinimap { get; set; }

		[FieldOffset(22, 46)]
		public bool NoHud { get; set; }

		[FieldOffset(23, 47)]
		public bool NoMinimapSpotting { get; set; }

		[FieldOffset(24, 48)]
		public bool No3dSpotting { get; set; }

		[FieldOffset(25, 49)]
		public bool NoNameTag { get; set; }

		[FieldOffset(26, 50)]
		public bool OnlySquadLeaderSpawn { get; set; }
	}
}
