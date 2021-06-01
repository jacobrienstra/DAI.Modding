namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTacticalMenuBaseItem : DataContainer
	{
		[FieldOffset(8, 24)]
		public PlotFlagReference UnlockedPlotFlag { get; set; }
	}
}
