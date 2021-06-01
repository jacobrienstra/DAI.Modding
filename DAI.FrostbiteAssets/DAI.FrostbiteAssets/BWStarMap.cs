using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWStarMap : Asset
	{
		[FieldOffset(12, 72)]
		public string TextureName { get; set; }

		[FieldOffset(16, 80)]
		public int TextureWidth { get; set; }

		[FieldOffset(20, 84)]
		public int TextureHeight { get; set; }

		[FieldOffset(24, 88)]
		public string RevealTextureName { get; set; }

		[FieldOffset(28, 96)]
		public int RevealTextureWidth { get; set; }

		[FieldOffset(32, 100)]
		public int RevealTextureHeight { get; set; }

		[FieldOffset(36, 104)]
		public List<ExternalObject<BWStar>> Stars { get; set; }

		[FieldOffset(40, 112)]
		public List<BWStarConnection> ConstellationEdges { get; set; }

		public BWStarMap()
		{
			Stars = new List<ExternalObject<BWStar>>();
			ConstellationEdges = new List<BWStarConnection>();
		}
	}
}
