namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EnvironmentalHandlerComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public float SafeFallDistance { get; set; }

		[FieldOffset(100, 180)]
		public float BaseFallDamageTakenFraction { get; set; }

		[FieldOffset(104, 184)]
		public float MaxHealthLostPerMeterFallen { get; set; }

		[FieldOffset(108, 188)]
		public float FatalFallDistance { get; set; }

		[FieldOffset(112, 192)]
		public float MinimumFractionHealthRemaining { get; set; }

		[FieldOffset(116, 196)]
		public bool BlockFallDamage { get; set; }

		[FieldOffset(117, 197)]
		public bool Enabled { get; set; }
	}
}
