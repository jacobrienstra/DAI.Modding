using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWMapPinLocation : BWMapPin
	{
		[FieldOffset(64, 192)]
		public string LevelName { get; set; }

		[FieldOffset(68, 200)]
		public int StartPointID { get; set; }

		[FieldOffset(72, 208)]
		public List<PlotActionReference> QuickTravelActions { get; set; }

		public BWMapPinLocation()
		{
			QuickTravelActions = new List<PlotActionReference>();
		}
	}
}
