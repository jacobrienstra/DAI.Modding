namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceCustomizationTextureData
	{
		[FieldOffset(0, 0)]
		public uint UsageHash { get; set; }

		[FieldOffset(4, 4)]
		public uint TextureParameterHandle { get; set; }

		[FieldOffset(8, 8)]
		public uint TextureHashName { get; set; }
	}
}
