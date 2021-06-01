using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIStateTextureAtlas : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<MultiTextureAtlasResult> Atlas { get; set; }

		[FieldOffset(4, 8)]
		public List<UIStateTextureResourceEntry> TextureLookups { get; set; }

		public UIStateTextureAtlas()
		{
			TextureLookups = new List<UIStateTextureResourceEntry>();
		}
	}
}
