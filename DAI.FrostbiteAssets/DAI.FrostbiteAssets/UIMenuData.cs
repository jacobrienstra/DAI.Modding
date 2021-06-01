using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMenuData : DataContainer
	{
		[FieldOffset(8, 24)]
		public string MenuUniqueID { get; set; }

		[FieldOffset(12, 32)]
		public List<ExternalObject<WidgetNode>> MenuItems { get; set; }

		public UIMenuData()
		{
			MenuItems = new List<ExternalObject<WidgetNode>>();
		}
	}
}
