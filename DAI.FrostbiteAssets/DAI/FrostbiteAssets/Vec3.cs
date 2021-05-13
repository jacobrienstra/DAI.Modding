namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public struct Vec3
	{
		[FieldOffset(0, 0)]
		public float x { get; set; }

		[FieldOffset(4, 4)]
		public float y { get; set; }

		[FieldOffset(8, 8)]
		public float z { get; set; }
	}
}
