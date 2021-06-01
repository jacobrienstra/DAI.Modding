namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWAoeCollisionSphere : BWAoeCollisionShape
	{
		[FieldOffset(16, 48)]
		public Vec4 RadiusCurve { get; set; }

		[FieldOffset(32, 64)]
		public Vec4 InnerRadiusCurve { get; set; }

		[FieldOffset(48, 80)]
		public ExternalObject<FloatProvider> Radius { get; set; }

		[FieldOffset(52, 88)]
		public float InnerExcludeRadius { get; set; }

		[FieldOffset(56, 92)]
		public float AngleSpan { get; set; }

		[FieldOffset(60, 96)]
		public float AngleOffset { get; set; }
	}
}
