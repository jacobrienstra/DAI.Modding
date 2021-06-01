using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class VecSplitterEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 Vec3 { get; set; }

		[FieldOffset(32, 112)]
		public Vec4 Vec4 { get; set; }

		[FieldOffset(48, 128)]
		public Realm Realm { get; set; }

		[FieldOffset(52, 132)]
		public Vec2 Vec2 { get; set; }
	}
}
