namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotInterruptibleTransitionData : CinebotTransitionData
	{
		[FieldOffset(36, 56)]
		public ExternalObject<CinebotTransitionInterruptData> Interupt { get; set; }
	}
}
