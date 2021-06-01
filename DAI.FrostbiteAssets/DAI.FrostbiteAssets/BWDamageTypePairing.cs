namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWDamageTypePairing : LinkObject
	{
		[FieldOffset(0, 0)]
		public int DamageType { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<BWModifiableStat> AttackerBonusStat { get; set; }

		[FieldOffset(8, 16)]
		public ExternalObject<BWModifiableStat> VictimResistanceStat { get; set; }
	}
}
