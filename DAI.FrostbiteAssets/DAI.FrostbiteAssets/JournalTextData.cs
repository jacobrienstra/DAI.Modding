using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JournalTextData : LinkObject
	{
		[FieldOffset(0, 0)]
		public JournalContentType ContentType { get; set; }

		[FieldOffset(4, 4)]
		public uint Hash { get; set; }

		[FieldOffset(8, 8)]
		public List<PlotConditionReference> DisplayConditions { get; set; }

		[FieldOffset(12, 16)]
		public List<PlotConditionReference> HideConditions { get; set; }

		[FieldOffset(16, 24)]
		public LocalizedStringReference TextReference { get; set; }

		public JournalTextData()
		{
			DisplayConditions = new List<PlotConditionReference>();
			HideConditions = new List<PlotConditionReference>();
		}
	}
}
