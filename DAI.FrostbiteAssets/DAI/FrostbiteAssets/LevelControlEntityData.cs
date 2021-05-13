namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LevelControlEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public string LevelToLoad { get; set; }

		[FieldOffset(20, 104)]
		public string InclusionOptions { get; set; }

		[FieldOffset(24, 112)]
		public string StartPoint { get; set; }

		[FieldOffset(28, 120)]
		public float FadeOutTime { get; set; }

		[FieldOffset(32, 124)]
		public bool RollCredits { get; set; }

		[FieldOffset(33, 125)]
		public bool DoPersistentSave { get; set; }

		[FieldOffset(34, 126)]
		public bool CheckSinglePlayerLevelInstalled { get; set; }

		[FieldOffset(35, 127)]
		public PlatformScalableBool ForceResourceReload { get; set; }
	}
}
