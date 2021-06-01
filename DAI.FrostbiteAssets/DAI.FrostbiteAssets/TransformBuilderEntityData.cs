using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TransformBuilderEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 Left { get; set; }

		[FieldOffset(32, 112)]
		public Vec3 Up { get; set; }

		[FieldOffset(48, 128)]
		public Vec3 Forward { get; set; }

		[FieldOffset(64, 144)]
		public Vec3 Trans { get; set; }

		[FieldOffset(80, 160)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 164)]
		public bool IsWorldSpace { get; set; }
	}
}
