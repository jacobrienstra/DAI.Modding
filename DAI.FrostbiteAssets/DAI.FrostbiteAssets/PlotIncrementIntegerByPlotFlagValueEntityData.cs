namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotIncrementIntegerByPlotFlagValueEntityData : PlotIncrementIntegerBaseEntityData
	{
		[FieldOffset(32, 136)]
		public PlotFlagReference PlotFlagValue { get; set; }
	}
}
