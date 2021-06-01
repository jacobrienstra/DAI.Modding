using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class HdrParameters
	{
		[FieldOffset(0, 0)]
		public Vec3 BloomScale { get; set; }

		[FieldOffset(16, 16)]
		public TonemapMethod TonemapMethod { get; set; }

		[FieldOffset(20, 20)]
		public float MiddleGray { get; set; }

		[FieldOffset(24, 24)]
		public float MinExposure { get; set; }

		[FieldOffset(28, 28)]
		public float MaxExposure { get; set; }

		[FieldOffset(32, 32)]
		public float ExposureAdjustTime { get; set; }
	}
}
