using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CoopGameSettings
	{
		[FieldOffset(0, 0)]
		public CoopGameVisibilityLevel CoopGameVisibility { get; set; }

		[FieldOffset(4, 4)]
		public MatchmakingGameSettings Settings { get; set; }
	}
}
