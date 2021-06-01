namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TextureContainer : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Description { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<TextureAsset> Texture { get; set; }

		[FieldOffset(8, 16)]
		public bool ExcludeFromCharacterCustomization { get; set; }
	}
}
