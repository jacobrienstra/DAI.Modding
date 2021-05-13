namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMultiplayerCampaignInfoBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference LocalizedCampaignString { get; set; }

		[FieldOffset(12, 48)]
		public LocalizedStringReference LocalizedDifficultyString { get; set; }

		[FieldOffset(16, 72)]
		public LocalizedStringReference LocalizedLobbyVisibilityString { get; set; }

		[FieldOffset(20, 96)]
		public UIDataSourceInfo CurrentCampaignName { get; set; }

		[FieldOffset(36, 128)]
		public UIDataSourceInfo CurrentDifficulty { get; set; }

		[FieldOffset(52, 160)]
		public UIDataSourceInfo CurrentLobbyVisibility { get; set; }

		[FieldOffset(68, 192)]
		public UIDataSourceInfo DisplayCampaignInfo { get; set; }
	}
}
