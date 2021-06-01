namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SplineWaypoint : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint Index { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<FlightWaypointData> Waypoint { get; set; }
	}
}
