namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentTuning
	{
		[FieldOffset(0, 0)]
		public QualityScalableFloat SpawnOuterRange { get; set; }

		[FieldOffset(16, 16)]
		public QualityScalableFloat SpawnInnerRange { get; set; }

		[FieldOffset(32, 32)]
		public QualityScalableFloat DeSpawnOuterRange { get; set; }

		[FieldOffset(48, 48)]
		public float RearRangeScale { get; set; }
	}
}
