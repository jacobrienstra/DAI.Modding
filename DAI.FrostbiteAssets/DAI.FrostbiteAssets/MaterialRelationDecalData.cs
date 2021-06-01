namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialRelationDecalData : PhysicsMaterialRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public ExternalObject<Dummy> Decal { get; set; }

		[FieldOffset(12, 48)]
		public ExternalObject<Dummy> ExitDecal { get; set; }
	}
}
