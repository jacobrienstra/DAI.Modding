namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransformProvider_Blend : TransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> TransformA { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<TransformProvider> TransformB { get; set; }

		[FieldOffset(16, 48)]
		public float BlendFactor { get; set; }
	}
}
