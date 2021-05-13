namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MigrationSavegameImportEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LocalizedStringReference PromptTitleString { get; set; }

		[FieldOffset(20, 120)]
		public LocalizedStringReference RequiresDlcString { get; set; }

		[FieldOffset(24, 144)]
		public LocalizedStringReference MismatchedFirstPartyAccountString { get; set; }

		[FieldOffset(28, 168)]
		public LocalizedStringReference SavegamePropertiesConfirmationString { get; set; }

		[FieldOffset(32, 192)]
		public LocalizedStringReference SavegamePropertiesKeyValuePairString { get; set; }

		[FieldOffset(36, 216)]
		public LocalizedStringReference ImportFailedString { get; set; }

		[FieldOffset(40, 240)]
		public LocalizedStringReference NoMigrationSaveString { get; set; }

		[FieldOffset(44, 264)]
		public LocalizedStringReference DownloadingMetadataString { get; set; }

		[FieldOffset(48, 288)]
		public LocalizedStringReference DownloadingSavegameString { get; set; }

		[FieldOffset(52, 312)]
		public LocalizedStringReference DownloadSaveSucceededString { get; set; }

		[FieldOffset(56, 336)]
		public LocalizedStringReference NameString { get; set; }

		[FieldOffset(60, 360)]
		public LocalizedStringReference GenderString { get; set; }

		[FieldOffset(64, 384)]
		public LocalizedStringReference RaceString { get; set; }

		[FieldOffset(68, 408)]
		public LocalizedStringReference ClassString { get; set; }

		[FieldOffset(72, 432)]
		public LocalizedStringReference HeroLevelString { get; set; }

		[FieldOffset(76, 456)]
		public LocalizedStringReference DateString { get; set; }

		[FieldOffset(80, 480)]
		public LocalizedStringReference AgeString { get; set; }
	}
}
