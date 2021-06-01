namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialPropertyImpulseData : PhysicsPropertyRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public float ImpulseAbsorptionMultiplier { get; set; }
	}
}
