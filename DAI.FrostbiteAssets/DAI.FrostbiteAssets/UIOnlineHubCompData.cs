namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIOnlineHubCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public LocalizedStringReference ImportDialogTitle { get; set; }

		[FieldOffset(36, 160)]
		public LocalizedStringReference ImportAskText { get; set; }

		[FieldOffset(40, 184)]
		public LocalizedStringReference ImportInProgressText { get; set; }

		[FieldOffset(44, 208)]
		public LocalizedStringReference FamilySharingErrorText { get; set; }

		[FieldOffset(48, 232)]
		public LocalizedStringReference DefaultCanonTitle { get; set; }

		[FieldOffset(52, 256)]
		public LocalizedStringReference DefaultCanonDescription { get; set; }

		[FieldOffset(56, 280)]
		public LocalizedStringReference ImportErrorText { get; set; }

		[FieldOffset(60, 304)]
		public LocalizedStringReference CustomWorldStateTitle { get; set; }

		[FieldOffset(64, 328)]
		public LocalizedStringReference NotLoggedInText { get; set; }

		[FieldOffset(68, 352)]
		public LocalizedStringReference ImportWorldStateSuccess { get; set; }
	}
}
