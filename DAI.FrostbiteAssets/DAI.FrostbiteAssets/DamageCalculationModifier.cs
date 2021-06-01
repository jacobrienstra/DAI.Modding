namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DamageCalculationModifier : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWStat> Stat { get; set; }

		[FieldOffset(4, 8)]
		public Delegate_float Amount { get; set; }

		[FieldOffset(16, 32)]
		public Delegate_bool Condition { get; set; }
	}
}
