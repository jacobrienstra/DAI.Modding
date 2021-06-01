namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPerceptionSettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public float DefaultFieldOfView { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<BWRange> AlliedPerceptionRadius { get; set; }

		[FieldOffset(20, 88)]
		public float UnperceiveRadius { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<BWModifiableStat> NoisinessStat { get; set; }

		[FieldOffset(28, 104)]
		public float VisualSuspicionRadius { get; set; }

		[FieldOffset(32, 108)]
		public float SuspicionZoneRadius { get; set; }

		[FieldOffset(36, 112)]
		public float MinCombatDelay { get; set; }

		[FieldOffset(40, 116)]
		public float MaxCombatDelay { get; set; }
	}
}
