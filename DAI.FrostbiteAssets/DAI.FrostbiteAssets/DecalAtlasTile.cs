namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DecalAtlasTile
	{
		[FieldOffset(0, 0)]
		public float TileIndexX { get; set; }

		[FieldOffset(4, 4)]
		public float TileIndexY { get; set; }

		[FieldOffset(8, 8)]
		public float TileCountX { get; set; }

		[FieldOffset(12, 12)]
		public float TileCountY { get; set; }

		[FieldOffset(16, 16)]
		public bool FlipX { get; set; }

		[FieldOffset(17, 17)]
		public bool FlipY { get; set; }
	}
}
