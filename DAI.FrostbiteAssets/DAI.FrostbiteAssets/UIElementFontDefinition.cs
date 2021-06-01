using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementFontDefinition : DataContainer
	{
		[FieldOffset(8, 24)]
		public UIElementFont Font { get; set; }

		[FieldOffset(16, 48)]
		public UIElementColor Color { get; set; }

		[FieldOffset(48, 80)]
		public float LetterSpacing { get; set; }

		[FieldOffset(52, 84)]
		public int RowSpacing { get; set; }

		[FieldOffset(56, 88)]
		public List<ExternalObject<UIElementTextFilter>> Filters { get; set; }

		public UIElementFontDefinition()
		{
			Filters = new List<ExternalObject<UIElementTextFilter>>();
		}
	}
}
