using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SinWave
	{
		[FieldOffset(0, 0)]
		public Vec4 TaperCoefficients { get; set; }

		[FieldOffset(16, 16)]
		public TiledVisualEffectAxis Axis { get; set; }

		[FieldOffset(20, 20)]
		public float MinMagnitude { get; set; }

		[FieldOffset(24, 24)]
		public float MaxMagnitude { get; set; }

		[FieldOffset(28, 28)]
		public float MinTemporalFrequency { get; set; }

		[FieldOffset(32, 32)]
		public float MaxTemporalFrequency { get; set; }

		[FieldOffset(36, 36)]
		public float MinPhaseOffset { get; set; }

		[FieldOffset(40, 40)]
		public float MaxPhaseOffset { get; set; }

		[FieldOffset(44, 44)]
		public TiledVisualEffectRandomizationOverTimeMode RandomizationOverTime { get; set; }

		[FieldOffset(48, 48)]
		public float MinRandomizationPeriod { get; set; }

		[FieldOffset(52, 52)]
		public float MaxRandomizationPeriod { get; set; }

		[FieldOffset(56, 56)]
		public float MinSpatialFrequency { get; set; }

		[FieldOffset(60, 60)]
		public float MaxSpatialFrequency { get; set; }

		[FieldOffset(64, 64)]
		public int Seed { get; set; }
	}
}
