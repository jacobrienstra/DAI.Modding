namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public struct AxisAlignedBox
	{
		[FieldOffset(0, 0)]
		public Vec3 min { get; set; }

		[FieldOffset(16, 16)]
		public Vec3 max { get; set; }
	}
}
