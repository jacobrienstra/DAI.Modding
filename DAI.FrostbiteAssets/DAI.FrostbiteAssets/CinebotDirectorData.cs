namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotDirectorData : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<CinebotModeData> DefaultMode { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<Dummy> DebugMode { get; set; }
	}
}
