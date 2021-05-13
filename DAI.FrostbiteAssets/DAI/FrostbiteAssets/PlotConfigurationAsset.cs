namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotConfigurationAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<PlotFlagsDefaultValues> PlotFlagsDefaultValues { get; set; }
	}
}
