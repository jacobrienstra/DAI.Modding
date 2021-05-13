namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITextureMappingOutputEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Id { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<TextureAsset> Texture { get; set; }

		[FieldOffset(8, 16)]
		public Vec2 Min { get; set; }

		[FieldOffset(16, 24)]
		public Vec2 Max { get; set; }

		[FieldOffset(24, 32)]
		public bool Streaming { get; set; }
	}
}
