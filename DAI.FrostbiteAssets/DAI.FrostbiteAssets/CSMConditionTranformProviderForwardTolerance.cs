namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionTranformProviderForwardTolerance : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider_Self> Transform1 { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<TransformProvider> Transform2 { get; set; }

		[FieldOffset(16, 48)]
		public float AllowedAngleTolerance { get; set; }
	}
}
