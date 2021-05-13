namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWMapBoundingVolume
	{
		[FieldOffset(0, 0)]
		public Vec3 TopLeft { get; set; }

		[FieldOffset(16, 16)]
		public Vec3 Dimensions { get; set; }
	}
}
