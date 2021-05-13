namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchmakingUserExtendedDataRule : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Rule { get; set; }

		[FieldOffset(4, 8)]
		public string MinFitThresHold { get; set; }
	}
}
