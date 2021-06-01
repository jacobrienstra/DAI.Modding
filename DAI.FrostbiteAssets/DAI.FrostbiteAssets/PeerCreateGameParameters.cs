namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PeerCreateGameParameters : LinkObject
	{
		[FieldOffset(0, 0)]
		public MatchmakingCreateGameParameters Base { get; set; }

		[FieldOffset(24, 40)]
		public uint PlayerCapacity { get; set; }
	}
}
