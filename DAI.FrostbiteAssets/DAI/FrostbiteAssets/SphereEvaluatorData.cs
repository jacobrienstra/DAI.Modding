namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SphereEvaluatorData : EvaluatorData
	{
		[FieldOffset(12, 32)]
		public float Radius { get; set; }

		[FieldOffset(16, 48)]
		public Vec3 Scale { get; set; }

		[FieldOffset(32, 64)]
		public Vec3 Pivot { get; set; }
	}
}
