namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMultiplayerEndOfMatchTabsBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference LocalizedLevelString { get; set; }

		[FieldOffset(12, 48)]
		public LocalizedStringReference LocalizedPersonalBestTimeString { get; set; }

		[FieldOffset(16, 72)]
		public LocalizedStringReference LocalizedGoToAbilitiesString { get; set; }

		[FieldOffset(20, 96)]
		public LocalizedStringReference LocalizedGoToStoreString { get; set; }

		[FieldOffset(24, 120)]
		public LocalizedStringReference LocalizedGoToChallengeString { get; set; }

		[FieldOffset(28, 144)]
		public UIDataSourceInfo MatchStats { get; set; }

		[FieldOffset(44, 176)]
		public UIDataSourceInfo CharacterXpProgressionTable { get; set; }

		[FieldOffset(60, 208)]
		public UIDataSourceInfo XpAnimateTrigger { get; set; }

		[FieldOffset(76, 240)]
		public UIDataSourceInfo CharacterXp { get; set; }

		[FieldOffset(92, 272)]
		public UIDataSourceInfo CharacterClass { get; set; }

		[FieldOffset(108, 304)]
		public UIDataSourceInfo ChallengeNotificationList { get; set; }

		[FieldOffset(124, 336)]
		public UIDataSourceInfo MatchPlayersList { get; set; }

		[FieldOffset(140, 368)]
		public UIDataSourceInfo SelectionEnabled { get; set; }
	}
}
