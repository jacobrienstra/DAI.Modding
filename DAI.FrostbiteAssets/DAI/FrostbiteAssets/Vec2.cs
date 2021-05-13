namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public struct Vec2
	{
		[FieldOffset(0, 0)]
		public float x { get; set; }

		[FieldOffset(4, 4)]
		public float y { get; set; }
	}
}
