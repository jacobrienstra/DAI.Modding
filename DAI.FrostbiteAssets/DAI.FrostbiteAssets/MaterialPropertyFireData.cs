namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialPropertyFireData : PhysicsMaterialRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public bool IsBurnable { get; set; }
	}
}
