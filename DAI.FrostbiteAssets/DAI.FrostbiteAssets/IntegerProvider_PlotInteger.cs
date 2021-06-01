namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IntegerProvider_PlotInteger : IntegerProvider
	{
		[FieldOffset(8, 32)]
		public PlotFlagReference PlotFlagReference { get; set; }

		[FieldOffset(24, 72)]
		public int DefaultValue { get; set; }
	}
}
