using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3XbonePresenceBackendData : XbonePresenceBackendData
	{
		[FieldOffset(28, 112)]
		public List<PlotFlagReference> GameProgressPlotFlags { get; set; }

		public DA3XbonePresenceBackendData()
		{
			GameProgressPlotFlags = new List<PlotFlagReference>();
		}
	}
}
