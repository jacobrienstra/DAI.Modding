namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PerformanceTrackerSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public float Interval { get; set; }

		[FieldOffset(20, 44)]
		public bool Enabled { get; set; }

		[FieldOffset(21, 45)]
		public bool SupressPerformanceStatsOnIdle { get; set; }

		[FieldOffset(22, 46)]
		public bool SupressPerformanceStatsUntilSpawned { get; set; }

		[FieldOffset(23, 47)]
		public bool JuiceLogPerformance { get; set; }
	}
}
