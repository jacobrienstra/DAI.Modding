namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotTransitionInterruptData : CinebotInterruptibleTransitionData
	{
		[FieldOffset(40, 64)]
		public ExternalObject<CinebotModeData> Mode { get; set; }
	}
}
