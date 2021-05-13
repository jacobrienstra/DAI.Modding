namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialPropertyHealthData : PhysicsPropertyRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public float Health { get; set; }
	}
}
