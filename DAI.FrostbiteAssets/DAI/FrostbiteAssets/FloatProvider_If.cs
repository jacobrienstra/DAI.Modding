namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_If : FloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<FloatProvider> IfTrue { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<FloatProvider> IfFalse { get; set; }

		[FieldOffset(16, 48)]
		public ExternalObject<BoolProvider> Condition { get; set; }
	}
}
