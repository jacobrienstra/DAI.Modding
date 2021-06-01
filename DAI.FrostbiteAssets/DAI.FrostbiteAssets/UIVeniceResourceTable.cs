using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIVeniceResourceTable : UIResourceTable
	{
		[FieldOffset(16, 80)]
		public UIStateTextureAtlas UIStateAtlas { get; set; }

		[FieldOffset(24, 96)]
		public List<NonAtlasedTextureResourceEntry> UIStateTextures { get; set; }

		[FieldOffset(28, 104)]
		public ExternalObject<Dummy> ActionscriptLibrary { get; set; }

		public UIVeniceResourceTable()
		{
			UIStateTextures = new List<NonAtlasedTextureResourceEntry>();
		}
	}
}
