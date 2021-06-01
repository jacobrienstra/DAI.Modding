using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DistanceEventEntityData : SimpleEntityData
	{
		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 108)]
		public float DistanceToCheck { get; set; }

		[FieldOffset(32, 112)]
		public LinearTransform TransformA { get; set; }

		[FieldOffset(96, 176)]
		public LinearTransform TransformB { get; set; }
	}
}
