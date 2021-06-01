namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PhysicsShapeEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform Transform { get; set; }

		[FieldOffset(80, 160)]
		public ExternalObject<PhysicsCapsuleShapeData> ShapeData { get; set; }

		[FieldOffset(84, 168)]
		public ExternalObject<RadiusData> RepulsorRadiusData { get; set; }

		[FieldOffset(88, 176)]
		public uint repulsorIdentityFlags { get; set; }

		[FieldOffset(92, 180)]
		public bool StartEnabled { get; set; }
	}
}
