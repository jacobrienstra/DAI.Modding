using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MoverWaypointFlightEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public RouteType TypeOfRoute { get; set; }

		[FieldOffset(20, 100)]
		public float InitialFlightSpeed { get; set; }

		[FieldOffset(24, 104)]
		public float InitialTurnSpeed { get; set; }

		[FieldOffset(28, 108)]
		public bool StartAtGeometricallyClosestWaypoint { get; set; }
	}
}
