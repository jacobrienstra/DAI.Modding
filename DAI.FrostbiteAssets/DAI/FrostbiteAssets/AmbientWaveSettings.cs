namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AmbientWaveSettings
	{
		[FieldOffset(0, 0)]
		public SplineCurve WindDistribution { get; set; }

		[FieldOffset(224, 320)]
		public float WaveAmplitude { get; set; }

		[FieldOffset(228, 324)]
		public float WindSpeed { get; set; }

		[FieldOffset(232, 328)]
		public float WindAngle { get; set; }

		[FieldOffset(236, 332)]
		public float MinWavelength { get; set; }

		[FieldOffset(240, 336)]
		public float LargeWaveReduction { get; set; }

		[FieldOffset(244, 340)]
		public float FoamHalfLife { get; set; }

		[FieldOffset(248, 344)]
		public float FoamThreshold { get; set; }

		[FieldOffset(252, 348)]
		public float FoamMaxValue { get; set; }
	}
}
