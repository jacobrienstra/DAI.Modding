using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotEvent : DataContainer
	{
		[FieldOffset(8, 24)]
		public ItemEvent Event { get; set; }

		[FieldOffset(12, 32)]
		public PlotActionReference PlotFlag { get; set; }
	}
}
