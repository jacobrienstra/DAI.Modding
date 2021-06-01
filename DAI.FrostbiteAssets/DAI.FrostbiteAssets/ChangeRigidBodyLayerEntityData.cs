using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ChangeRigidBodyLayerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public RigidBodyCollisionLayer CollisionLayer { get; set; }
	}
}
