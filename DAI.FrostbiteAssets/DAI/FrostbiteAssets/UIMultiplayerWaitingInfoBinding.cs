namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMultiplayerWaitingInfoBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference LocalizedReadyUpString { get; set; }

		[FieldOffset(12, 48)]
		public UIDataSourceInfo TextVisibility { get; set; }

		[FieldOffset(28, 80)]
		public UIDataSourceInfo WaitingPlayersText { get; set; }

		[FieldOffset(44, 112)]
		public UIDataSourceInfo IsLocalPlayerReady { get; set; }
	}
}
