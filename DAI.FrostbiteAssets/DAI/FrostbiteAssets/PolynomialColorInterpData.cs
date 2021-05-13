namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PolynomialColorInterpData : EvaluatorData
	{
		[FieldOffset(16, 32)]
		public Vec3 Color0 { get; set; }

		[FieldOffset(32, 48)]
		public Vec3 Color1 { get; set; }

		[FieldOffset(48, 64)]
		public Vec4 Coefficients { get; set; }
	}
}
