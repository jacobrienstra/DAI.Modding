namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICharGenCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public LocalizedStringReference CharacterImportTitle { get; set; }

		[FieldOffset(36, 160)]
		public LocalizedStringReference CharacterImportDownloading { get; set; }

		[FieldOffset(40, 184)]
		public LocalizedStringReference CharacterImportLogin { get; set; }

		[FieldOffset(44, 208)]
		public LocalizedStringReference CharacterImportCardTitle { get; set; }

		[FieldOffset(48, 232)]
		public LocalizedStringReference CharacterImportCardDescription { get; set; }

		[FieldOffset(52, 256)]
		public LocalizedStringReference CharacterImportCardFailed { get; set; }
	}
}
