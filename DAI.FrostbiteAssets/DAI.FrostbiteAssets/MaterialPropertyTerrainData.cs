namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class MaterialPropertyTerrainData : PhysicsMaterialRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public ExternalObject<Dummy> DestructionEffect { get; set; }

		[FieldOffset(12, 48)]
		public float DirtTriggerFactor { get; set; }

		[FieldOffset(16, 64)]
		public Vec3 DirtTriggerColor { get; set; }
	}
}
