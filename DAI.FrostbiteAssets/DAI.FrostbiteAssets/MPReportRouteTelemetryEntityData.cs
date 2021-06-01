namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPReportRouteTelemetryEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int Zone1 { get; set; }

		[FieldOffset(20, 100)]
		public int Zone2 { get; set; }

		[FieldOffset(24, 104)]
		public int Zone3 { get; set; }

		[FieldOffset(28, 108)]
		public int Zone4 { get; set; }
	}
}
