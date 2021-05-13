namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CollisionSphere
	{
		[FieldOffset(0, 0)]
		public Vec3 BoneOffset { get; set; }

		[FieldOffset(16, 16)]
		public float Radius { get; set; }
	}
}
