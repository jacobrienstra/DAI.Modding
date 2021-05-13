namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AmbientRouteWaypointData : WaypointData
	{
		[FieldOffset(20, 48)]
		public int WaypointSpatialFeature { get; set; }
	}
}
