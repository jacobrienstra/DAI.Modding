namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingChallengeRewardPortrait : MPServerMappingChallengeBase
	{
		[FieldOffset(16, 40)]
		public UITextureAtlasTextureReference RewardImage { get; set; }
	}
}
