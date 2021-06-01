namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SplineData : EvaluatorData
	{
		[FieldOffset(16, 32)]
		public SplineCurve SplineCurve { get; set; }
	}
}
