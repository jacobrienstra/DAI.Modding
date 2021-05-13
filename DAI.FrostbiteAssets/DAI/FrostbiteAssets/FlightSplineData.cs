using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FlightSplineData : CustomSplineData
	{
		[FieldOffset(28, 112)]
		public List<SplineWaypoint> Waypoints { get; set; }

		public FlightSplineData()
		{
			Waypoints = new List<SplineWaypoint>();
		}
	}
}
