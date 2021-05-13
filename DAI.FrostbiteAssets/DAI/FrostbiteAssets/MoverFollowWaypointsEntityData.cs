using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MoverFollowWaypointsEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public RouteType TypeOfRoute { get; set; }

		[FieldOffset(20, 104)]
		public ExternalObject<MoverTuneOverride> MovementOverride { get; set; }

		[FieldOffset(24, 112)]
		public float IntermediateAllowedStopDistOverride { get; set; }

		[FieldOffset(28, 116)]
		public float DestinationAllowedStopDistOverride { get; set; }

		[FieldOffset(32, 120)]
		public bool StopAtWaypoints { get; set; }

		[FieldOffset(33, 121)]
		public bool StartAtGeometricallyClosestWaypoint { get; set; }

		[FieldOffset(34, 122)]
		public bool DestinationSetOrientation { get; set; }
	}
}
