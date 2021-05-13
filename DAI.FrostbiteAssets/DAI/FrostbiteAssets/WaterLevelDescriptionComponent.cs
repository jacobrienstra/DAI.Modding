namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WaterLevelDescriptionComponent : LevelDescriptionComponent
	{
		[FieldOffset(8, 24)]
		public QualityScalableInt MaxSimulationCount { get; set; }

		[FieldOffset(24, 40)]
		public QualityScalableInt MaxVisibleWaterSurfaceCount { get; set; }

		[FieldOffset(40, 56)]
		public QualityScalableInt RenderGridWidth { get; set; }

		[FieldOffset(56, 72)]
		public QualityScalableInt RenderGridHeight { get; set; }

		[FieldOffset(72, 88)]
		public QualityScalableInt MinAmbientSimulationResolution { get; set; }

		[FieldOffset(88, 104)]
		public QualityScalableInt MaxAmbientSimulationResolution { get; set; }

		[FieldOffset(104, 120)]
		public bool Enabled { get; set; }
	}
}
