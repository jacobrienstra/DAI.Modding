namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PolynomialData : EvaluatorData
	{
		[FieldOffset(12, 32)]
		public float ScaleValue { get; set; }

		[FieldOffset(16, 48)]
		public Vec4 Coefficients { get; set; }

		[FieldOffset(32, 64)]
		public float MinClamp { get; set; }

		[FieldOffset(36, 68)]
		public float MaxClamp { get; set; }
	}
}
