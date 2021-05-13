namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StoreConfiguration : SystemSettings
	{
		[FieldOffset(16, 40)]
		public PlotFlagReference GlobalSellPriceMultiplier { get; set; }

		[FieldOffset(32, 80)]
		public PlotFlagReference GlobalBuyPriceMultiplier { get; set; }
	}
}
