using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIButtonLegendCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public int SpacingBetweenIconAndText { get; set; }

		[FieldOffset(36, 140)]
		public int SpacingBetweenButtons { get; set; }

		[FieldOffset(40, 144)]
		public int SpacingBetweenTextButtons { get; set; }

		[FieldOffset(44, 152)]
		public List<UIButtonLegendDisplayTypeMapping> DisplayTypeMappings { get; set; }

		[FieldOffset(48, 160)]
		public List<UIButtonLegendButtonID> ButtonIDOrder { get; set; }

		public UIButtonLegendCompData()
		{
			DisplayTypeMappings = new List<UIButtonLegendDisplayTypeMapping>();
			ButtonIDOrder = new List<UIButtonLegendButtonID>();
		}
	}
}
