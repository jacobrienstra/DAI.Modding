using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIElementText : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Sid { get; set; }

		[FieldOffset(4, 8)]
		public List<UIElementTextEntry> Entries { get; set; }

		[FieldOffset(8, 16)]
		public UIElementAlignment VerticalAlignment { get; set; }

		[FieldOffset(12, 20)]
		public UIElementAlignment HorizonalAlignment { get; set; }

		[FieldOffset(16, 24)]
		public bool Multiline { get; set; }

		[FieldOffset(17, 25)]
		public bool Wordwrap { get; set; }

		public UIElementText()
		{
			Entries = new List<UIElementTextEntry>();
		}
	}
}
