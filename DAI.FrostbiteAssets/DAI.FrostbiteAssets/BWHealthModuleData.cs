namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWHealthModuleData : DataContainer
	{
		[FieldOffset(8, 24)]
		public float CriticalHealth { get; set; }

		[FieldOffset(12, 28)]
		public float DyingHealth { get; set; }

		[FieldOffset(16, 32)]
		public float DeadHealth { get; set; }

		[FieldOffset(20, 36)]
		public float DyingDamageIntervall { get; set; }

		[FieldOffset(24, 40)]
		public float DyingDamage { get; set; }

		[FieldOffset(28, 44)]
		public float HelpUpHealAmount { get; set; }

		[FieldOffset(32, 48)]
		public float ReviveTime { get; set; }

		[FieldOffset(36, 52)]
		public float TimeForCorpse { get; set; }
	}
}
