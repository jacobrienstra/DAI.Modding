namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialRelationPenetrationData : PhysicsPropertyRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public bool NeverPenetrate { get; set; }
	}
}
