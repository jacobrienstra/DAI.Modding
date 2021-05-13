using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class RotationTransformBuilderEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 Rotation { get; set; }

		[FieldOffset(32, 112)]
		public Realm Realm { get; set; }
	}
}
