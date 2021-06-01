namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MultiTextureAtlasPartInfo
	{
		[FieldOffset(0, 0)]
		public Vec2 MinUv { get; set; }

		[FieldOffset(8, 8)]
		public Vec2 MaxUv { get; set; }

		[FieldOffset(16, 16)]
		public uint AssetNameHash { get; set; }
	}
}
