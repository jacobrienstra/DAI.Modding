using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchmakingVirtualizedRule : LinkObject
	{
		[FieldOffset(0, 0)]
		public string MinFitThreshold { get; set; }

		[FieldOffset(4, 8)]
		public MatchmakingVirtualizationMode VirtualizationMode { get; set; }
	}
}
