namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GlobalCinebotSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public ExternalObject<CinebotModeData> DefaultTimelineCameraMode { get; set; }
	}
}
