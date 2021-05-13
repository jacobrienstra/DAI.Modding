namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingChallengeRewardText : MPServerMappingChallengeBase
	{
		[FieldOffset(16, 40)]
		public LocalizedStringReference RewardText { get; set; }
	}
}
