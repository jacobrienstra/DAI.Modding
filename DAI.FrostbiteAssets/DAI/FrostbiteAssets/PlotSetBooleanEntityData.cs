namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotSetBooleanEntityData : AbstractCustomPlotEntityData
	{
		[FieldOffset(16, 96)]
		public PlotFlagReference PlotFlagReference { get; set; }
	}
}
