namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TransformedTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> TransformProvider { get; set; }

		[FieldOffset(12, 40)]
		public bool RightMultiply { get; set; }

		[FieldOffset(13, 41)]
		public bool AddTranslations { get; set; }

		[FieldOffset(16, 48)]
		public LinearTransform Transform { get; set; }
	}
}
