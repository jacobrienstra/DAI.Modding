namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetPlotFlag : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public PlotFlagReference PlotFlagReference { get; set; }

		[FieldOffset(44, 112)]
		public bool Clear { get; set; }
	}
}
