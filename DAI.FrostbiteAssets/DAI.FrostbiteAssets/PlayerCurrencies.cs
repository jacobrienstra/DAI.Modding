namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlayerCurrencies : DataContainer
	{
		[FieldOffset(8, 24)]
		public PlotFlagReference Gold { get; set; }
	}
}
