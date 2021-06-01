using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TurbulanceData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public Vec3 Multiplier { get; set; }

		[FieldOffset(32, 80)]
		public float Intensity { get; set; }

		[FieldOffset(36, 84)]
		public TurbulenceNoiseType NoiseType { get; set; }

		[FieldOffset(40, 88)]
		public float PeriodSpace { get; set; }

		[FieldOffset(44, 92)]
		public float TurbulenceForceAsInstantVelocity { get; set; }

		[FieldOffset(48, 96)]
		public int Octaves { get; set; }

		[FieldOffset(52, 100)]
		public float OctavePersistence { get; set; }

		[FieldOffset(56, 104)]
		public float PerParticleRandomness { get; set; }
	}
}
