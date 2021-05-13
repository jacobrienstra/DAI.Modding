using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITextureAtlasAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<UITextureAtlasSubAtlas> SubAtlases { get; set; }

		public UITextureAtlasAsset()
		{
			SubAtlases = new List<UITextureAtlasSubAtlas>();
		}
	}
}
