namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TransformProvider_Translate : TransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> Transform { get; set; }

		[FieldOffset(16, 48)]
		public Vec3 Offset { get; set; }
	}
}
