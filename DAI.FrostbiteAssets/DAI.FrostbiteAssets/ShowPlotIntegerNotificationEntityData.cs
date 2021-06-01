namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ShowPlotIntegerNotificationEntityData : AbstractCustomPlotEntityData
	{
		[FieldOffset(16, 96)]
		public PlotFlagReference PlotFlagReference { get; set; }

		[FieldOffset(32, 136)]
		public int OverrideNotificationFormatTextStringID { get; set; }

		[FieldOffset(36, 144)]
		public LocalizedStringReference NotificationFormatTextReference { get; set; }

		[FieldOffset(40, 168)]
		public string IconType { get; set; }
	}
}
