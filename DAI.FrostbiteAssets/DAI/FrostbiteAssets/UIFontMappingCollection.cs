using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIFontMappingCollection : Asset
	{
		[FieldOffset(12, 72)]
		public List<UIFontMapping> Fonts { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<Dummy>> TextDatabase { get; set; }

		public UIFontMappingCollection()
		{
			Fonts = new List<UIFontMapping>();
			TextDatabase = new List<ExternalObject<Dummy>>();
		}
	}
}
