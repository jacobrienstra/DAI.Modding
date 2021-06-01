namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentTuningOverride : DataContainer
	{
		[FieldOffset(8, 24)]
		public QualityScalableFloat SpawnOuterRange { get; set; }

		[FieldOffset(24, 40)]
		public QualityScalableFloat SpawnInnerRange { get; set; }

		[FieldOffset(40, 56)]
		public QualityScalableFloat DeSpawnOuterRange { get; set; }

		[FieldOffset(56, 72)]
		public float RearRangeScale { get; set; }
	}
}
