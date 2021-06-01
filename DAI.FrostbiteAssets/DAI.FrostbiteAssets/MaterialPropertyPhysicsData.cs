namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialPropertyPhysicsData : PhysicsMaterialRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public float DynamicFrictionModifier { get; set; }

		[FieldOffset(12, 44)]
		public float StaticFrictionModifier { get; set; }

		[FieldOffset(16, 48)]
		public float RestitutionModifier { get; set; }

		[FieldOffset(20, 52)]
		public float Resistance { get; set; }
	}
}
