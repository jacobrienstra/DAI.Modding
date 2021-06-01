namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public struct Vec4
	{
		[FieldOffset(0, 0)]
		public float x { get; set; }

		[FieldOffset(4, 4)]
		public float y { get; set; }

		[FieldOffset(8, 8)]
		public float z { get; set; }

		[FieldOffset(12, 12)]
		public float w { get; set; }
	}
}
