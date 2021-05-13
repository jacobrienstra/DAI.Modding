namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_PlotBool : BoolProvider
	{
		[FieldOffset(8, 32)]
		public PlotFlagReference PlotFlagReference { get; set; }
	}
}
