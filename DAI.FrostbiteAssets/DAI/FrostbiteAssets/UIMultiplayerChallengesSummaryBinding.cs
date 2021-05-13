namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMultiplayerChallengesSummaryBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference LocalizedChallengeProgressHeader { get; set; }

		[FieldOffset(12, 48)]
		public LocalizedStringReference LocalizedTitlesHeader { get; set; }

		[FieldOffset(16, 72)]
		public LocalizedStringReference LocalizedPortraitsHeader { get; set; }

		[FieldOffset(20, 96)]
		public LocalizedStringReference LocalizedBannersHeader { get; set; }

		[FieldOffset(24, 120)]
		public UIDataSourceInfo ChallengesSummary { get; set; }
	}
}
