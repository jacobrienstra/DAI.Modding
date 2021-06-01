using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotTelemetryManagerData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<PlotFlagReference> KeyPlotFlags { get; set; }

		[FieldOffset(20, 104)]
		public PlotFlagReference InquisitionLevel { get; set; }

		[FieldOffset(36, 144)]
		public PlotFlagReference InquisitionPower { get; set; }

		[FieldOffset(52, 184)]
		public PlotFlagReference Agents { get; set; }

		[FieldOffset(68, 224)]
		public List<PlotFlagReference> MilestonePlotFlags { get; set; }

		public PlotTelemetryManagerData()
		{
			KeyPlotFlags = new List<PlotFlagReference>();
			MilestonePlotFlags = new List<PlotFlagReference>();
		}
	}
}
