using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIOnlineCatalogCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public List<MPCardBackMapping> CardBackTextures { get; set; }

		public UIOnlineCatalogCompData()
		{
			CardBackTextures = new List<MPCardBackMapping>();
		}
	}
}
