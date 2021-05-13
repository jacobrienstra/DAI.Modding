namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionGreaterThan : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<FloatProvider> A { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<FloatProvider> B { get; set; }
	}
}
