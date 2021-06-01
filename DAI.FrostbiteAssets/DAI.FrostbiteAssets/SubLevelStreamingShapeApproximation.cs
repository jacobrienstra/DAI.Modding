namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SubLevelStreamingShapeApproximation
	{
		[FieldOffset(0, 0)]
		public Vec3 Center { get; set; }

		[FieldOffset(16, 16)]
		public float Radius { get; set; }
	}
}
