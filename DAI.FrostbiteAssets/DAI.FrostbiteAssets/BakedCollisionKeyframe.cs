namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BakedCollisionKeyframe
	{
		[FieldOffset(0, 0)]
		public Vec4 Orientation { get; set; }

		[FieldOffset(16, 16)]
		public Vec3 Translation { get; set; }

		[FieldOffset(32, 32)]
		public float Time { get; set; }
	}
}
