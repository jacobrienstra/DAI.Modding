namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotFlagReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public PlotFlagId PlotFlagId { get; set; }
	}
}
