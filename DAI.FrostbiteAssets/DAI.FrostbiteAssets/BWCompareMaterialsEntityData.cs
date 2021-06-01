using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCompareMaterialsEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int PhysicsMaterial { get; set; }

		[FieldOffset(24, 104)]
		public int PhysicsProperty { get; set; }

		[FieldOffset(28, 112)]
		public MaterialDecl Material { get; set; }
	}
}
