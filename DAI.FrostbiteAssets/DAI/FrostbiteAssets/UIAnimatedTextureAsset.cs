using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIAnimatedTextureAsset : Asset
	{
		[FieldOffset(12, 72)]
		public float FrameRate { get; set; }

		[FieldOffset(16, 76)]
		public int Width { get; set; }

		[FieldOffset(20, 80)]
		public int Height { get; set; }

		[FieldOffset(24, 88)]
		public ExternalObject<TextureAsset> TextureAtlas { get; set; }

		[FieldOffset(28, 96)]
		public List<UITextureAtlasInfo> TextureInfos { get; set; }

		public UIAnimatedTextureAsset()
		{
			TextureInfos = new List<UITextureAtlasInfo>();
		}
	}
}
