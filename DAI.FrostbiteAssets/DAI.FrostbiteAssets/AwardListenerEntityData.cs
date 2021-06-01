using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AwardListenerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<DemonEnemyChooser> DemonEnemyTypes { get; set; }

		[FieldOffset(20, 104)]
		public List<MultiPlotAward> PlotAwards { get; set; }

		public AwardListenerEntityData()
		{
			DemonEnemyTypes = new List<DemonEnemyChooser>();
			PlotAwards = new List<MultiPlotAward>();
		}
	}
}
