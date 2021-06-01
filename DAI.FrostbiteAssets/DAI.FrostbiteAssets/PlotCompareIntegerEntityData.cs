namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotCompareIntegerEntityData : AbstractCustomPlotEntityData
	{
		[FieldOffset(16, 96)]
		public PlotFlagReference PlotFlagReferenceA { get; set; }

		[FieldOffset(32, 136)]
		public PlotFlagReference PlotFlagReferenceB { get; set; }

		[FieldOffset(48, 176)]
		public int B { get; set; }
	}
}
