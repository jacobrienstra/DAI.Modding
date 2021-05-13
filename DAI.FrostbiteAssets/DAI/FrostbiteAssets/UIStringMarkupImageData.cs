using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIStringMarkupImageData : LinkObject
	{
		[FieldOffset(0, 8)]
		public StringMarkupImageType ImageType { get; set; }

		[FieldOffset(4, 16)]
		public ExternalObject<Dummy> Texture { get; set; }

		[FieldOffset(8, 24)]
		public UITextureAtlasTextureReference AtlasTexture { get; set; }

		[FieldOffset(28, 64)]
		public StringMarkupImageVAlign VAlign { get; set; }

		[FieldOffset(32, 68)]
		public int RelativeSize { get; set; }

		[FieldOffset(36, 72)]
		public int Width { get; set; }

		[FieldOffset(40, 76)]
		public int Height { get; set; }

		[FieldOffset(44, 80)]
		public int VSpace { get; set; }

		[FieldOffset(48, 84)]
		public int HSpace { get; set; }

		[FieldOffset(52, 88)]
		public string OnDemandTexturePath { get; set; }

		[FieldOffset(56, 96)]
		public bool UseFontRelativeSize { get; set; }
	}
}
