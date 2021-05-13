namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BoxEvaluatorData : EvaluatorData
	{
		[FieldOffset(16, 32)]
		public Vec3 Dimensions { get; set; }

		[FieldOffset(32, 48)]
		public Vec3 Pivot { get; set; }
	}
}
