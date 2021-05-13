namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialRelationVehicleData : PhysicsMaterialRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public ExternalObject<Dummy> ChassiEffect { get; set; }

		[FieldOffset(12, 48)]
		public ExternalObject<Dummy> TrackEffect { get; set; }

		[FieldOffset(16, 56)]
		public ExternalObject<Dummy> WheelEffect { get; set; }

		[FieldOffset(20, 64)]
		public ExternalObject<Dummy> GroundEffect { get; set; }
	}
}
