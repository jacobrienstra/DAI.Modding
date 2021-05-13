namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WaypointData : DataContainer
	{
		[FieldOffset(8, 24)]
		public int SchematicsNameHash { get; set; }

		[FieldOffset(12, 28)]
		public uint WaypointId { get; set; }

		[FieldOffset(16, 32)]
		public bool UseClientsPosition { get; set; }
	}
}
