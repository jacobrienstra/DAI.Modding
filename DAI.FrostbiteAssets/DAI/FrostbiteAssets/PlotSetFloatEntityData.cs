namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotSetFloatEntityData : AbstractCustomPlotEntityData
	{
		[FieldOffset(16, 96)]
		public PlotFlagReference PlotFlagReference { get; set; }

		[FieldOffset(32, 136)]
		public float Value { get; set; }
	}
}
