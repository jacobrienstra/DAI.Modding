using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AnimationGeneratorConfiguration : DataContainer
	{
		[FieldOffset(8, 24)]
		public float LineOverlapTime { get; set; }

		[FieldOffset(12, 28)]
		public float MinTimeBetweenAnimations { get; set; }

		[FieldOffset(16, 32)]
		public float MaxTimeBetweenAnimations { get; set; }

		[FieldOffset(20, 36)]
		public float AnimationBlendInTime { get; set; }

		[FieldOffset(24, 40)]
		public float AnimationBlendOutTime { get; set; }

		[FieldOffset(28, 44)]
		public ANTLayerBlendType BlendType { get; set; }
	}
}
