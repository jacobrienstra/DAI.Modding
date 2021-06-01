namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotSetIntegerEntityData : AbstractCustomPlotEntityData
	{
		[FieldOffset(16, 96)]
		public PlotFlagReference PlotFlagReference { get; set; }

		[FieldOffset(32, 136)]
		public int Value { get; set; }
	}
}
