namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotIntegerFlagNotificationEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public PlotFlagReference PlotFlag { get; set; }

		[FieldOffset(32, 136)]
		public bool TriggerOnValueChange { get; set; }
	}
}
