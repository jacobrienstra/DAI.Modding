namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchmakingRankedRule : LinkObject
	{
		[FieldOffset(0, 0)]
		public string MinFitThreshold { get; set; }
	}
}
