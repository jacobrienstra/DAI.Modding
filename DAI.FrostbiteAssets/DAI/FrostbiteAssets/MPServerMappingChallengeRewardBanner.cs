namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingChallengeRewardBanner : MPServerMappingChallengeBase
	{
		[FieldOffset(16, 40)]
		public ExternalObject<TextureAsset> RewardImage { get; set; }
	}
}
