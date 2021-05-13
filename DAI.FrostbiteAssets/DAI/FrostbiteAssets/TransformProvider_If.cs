namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransformProvider_If : TransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> IfTrue { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<CSMTransformProvider> IfFalse { get; set; }

		[FieldOffset(16, 48)]
		public ExternalObject<BoolProvider> Condition { get; set; }
	}
}
