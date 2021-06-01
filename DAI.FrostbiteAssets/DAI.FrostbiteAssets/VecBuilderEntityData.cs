using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VecBuilderEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public float X { get; set; }

		[FieldOffset(24, 104)]
		public float Y { get; set; }

		[FieldOffset(28, 108)]
		public float Z { get; set; }

		[FieldOffset(32, 112)]
		public float W { get; set; }
	}
}
