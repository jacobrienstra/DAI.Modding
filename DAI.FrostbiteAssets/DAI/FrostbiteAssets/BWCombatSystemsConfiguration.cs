namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCombatSystemsConfiguration : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public Delegate_bool DefaultCriticalActivationScript { get; set; }

		[FieldOffset(24, 96)]
		public int ThreatMultiplierProperty { get; set; }

		[FieldOffset(28, 100)]
		public float CombatTimeoutTime { get; set; }

		[FieldOffset(32, 104)]
		public Delegate_float DefaultDamageCalculationScript { get; set; }

		[FieldOffset(44, 128)]
		public ExternalObject<BWModifiableStat> ThreatStat { get; set; }

		[FieldOffset(48, 136)]
		public ExternalObject<BWModifiableStat> MaxHealthStat { get; set; }
	}
}
