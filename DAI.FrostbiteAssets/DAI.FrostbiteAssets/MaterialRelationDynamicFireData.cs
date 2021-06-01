namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialRelationDynamicFireData : PhysicsMaterialRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public float FireDamage { get; set; }

		[FieldOffset(12, 44)]
		public uint CellDamageRadius { get; set; }

		[FieldOffset(16, 48)]
		public bool CanSetFire { get; set; }
	}
}
