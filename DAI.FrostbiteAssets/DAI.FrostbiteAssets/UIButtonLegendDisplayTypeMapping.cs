using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIButtonLegendDisplayTypeMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public UIButtonLegendIconDisplayType DisplayType { get; set; }

		[FieldOffset(4, 8)]
		public List<UIButtonLegendIDMapping> ButtonIDMappings { get; set; }

		public UIButtonLegendDisplayTypeMapping()
		{
			ButtonIDMappings = new List<UIButtonLegendIDMapping>();
		}
	}
}
