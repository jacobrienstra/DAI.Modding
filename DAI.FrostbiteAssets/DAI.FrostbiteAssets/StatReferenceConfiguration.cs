namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatReferenceConfiguration : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<BWDepletableStat> HealthStat { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<BWDepletableStat> AbilityResourceStat { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<BWDepletableStat> AmmoStat { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<Dummy> ComboPointStat { get; set; }

		[FieldOffset(28, 104)]
		public ExternalObject<BWDepletableStat> ArmorStat { get; set; }

		[FieldOffset(32, 112)]
		public ExternalObject<BWDepletableStat> BarrierStat { get; set; }

		[FieldOffset(36, 120)]
		public ExternalObject<BWDepletableStat> ExperienceStat { get; set; }

		[FieldOffset(40, 128)]
		public ExternalObject<BWDepletableStat> AbilityPointsStat { get; set; }

		[FieldOffset(44, 136)]
		public ExternalObject<Dummy> DifficultyStat { get; set; }

		[FieldOffset(48, 144)]
		public ExternalObject<BWIntegralStat> LevelStat { get; set; }

		[FieldOffset(52, 152)]
		public ExternalObject<BWStat> MaxLevelStat { get; set; }

		[FieldOffset(56, 160)]
		public ExternalObject<BWStat> MinLevelStat { get; set; }

		[FieldOffset(60, 168)]
		public ExternalObject<BWModifiableStat> RankStat { get; set; }

		[FieldOffset(64, 176)]
		public ExternalObject<BWModifiableStat> MovementSpeedMultiplierStat { get; set; }

		[FieldOffset(68, 184)]
		public ExternalObject<BWModifiableStat> StealthPerceptionDistance { get; set; }

		[FieldOffset(72, 192)]
		public ExternalObject<BWModifiableStat> ArmorRatingStat { get; set; }

		[FieldOffset(76, 200)]
		public ExternalObject<BWModifiableStat> ItemArmorStat { get; set; }
	}
}
