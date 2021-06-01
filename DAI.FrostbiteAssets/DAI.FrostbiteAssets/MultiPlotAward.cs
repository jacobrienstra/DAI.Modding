using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MultiPlotAward : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<StatsCategoryData> AwardStat { get; set; }

		[FieldOffset(4, 8)]
		public List<PlotFlagReference> PlotFlags { get; set; }

		public MultiPlotAward()
		{
			PlotFlags = new List<PlotFlagReference>();
		}
	}
}
