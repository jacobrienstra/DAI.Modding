namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchmakingPingSiteRule : LinkObject
	{
		[FieldOffset(0, 0)]
		public string MinFitThreshold { get; set; }
	}
}
