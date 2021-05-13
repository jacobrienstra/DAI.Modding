using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DistanceCheckEntityData : SimpleEntityData
	{
		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 108)]
		public float InnerDistanceToCheck { get; set; }

		[FieldOffset(28, 112)]
		public float DistanceToCheck { get; set; }

		[FieldOffset(32, 128)]
		public LinearTransform TransformA { get; set; }

		[FieldOffset(96, 192)]
		public LinearTransform TransformB { get; set; }
	}
}
