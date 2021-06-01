using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMenuScreenAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public List<ExternalObject<WidgetNode>> Menus { get; set; }

		public UIMenuScreenAsset()
		{
			Menus = new List<ExternalObject<WidgetNode>>();
		}
	}
}
