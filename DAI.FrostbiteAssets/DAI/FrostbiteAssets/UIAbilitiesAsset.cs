namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIAbilitiesAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public PlotFlagReference AbilityTreeVisitedPlotFlag { get; set; }

		[FieldOffset(84, 232)]
		public PlotFlagReference PrologueDonePlotFlag { get; set; }

		[FieldOffset(100, 272)]
		public PlotFlagReference TutorialCompletePlotFlag { get; set; }
	}
}
