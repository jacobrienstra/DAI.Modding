namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICharacterRecordSheetCompData : UIItemDisplayCompData
	{
		[FieldOffset(40, 168)]
		public ExternalObject<BWDepletableStat> XpStat { get; set; }

		[FieldOffset(44, 176)]
		public PlotFlagReference InquisitionXpPlotFlag { get; set; }

		[FieldOffset(60, 216)]
		public LocalizedStringReference XPBarLabel { get; set; }

		[FieldOffset(64, 240)]
		public LocalizedStringReference IXPBarLabel { get; set; }
	}
}
