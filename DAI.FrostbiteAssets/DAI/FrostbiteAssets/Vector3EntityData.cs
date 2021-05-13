using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class Vector3EntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 DefaultVec3 { get; set; }

		[FieldOffset(32, 112)]
		public Realm Realm { get; set; }
	}
}
