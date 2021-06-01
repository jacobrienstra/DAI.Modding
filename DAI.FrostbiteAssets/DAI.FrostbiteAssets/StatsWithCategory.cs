using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatsWithCategory : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<ExternalObject<WidgetNode>> Stats { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference CategoryDisplayName { get; set; }

		[FieldOffset(8, 32)]
		public LocalizedStringReference CategoryDescription { get; set; }

		public StatsWithCategory()
		{
			Stats = new List<ExternalObject<WidgetNode>>();
		}
	}
}
