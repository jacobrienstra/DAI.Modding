namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISaveLoadCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public string SaveFilePrefix { get; set; }

		[FieldOffset(36, 144)]
		public string SaveFileExtension { get; set; }

		[FieldOffset(40, 152)]
		public ExternalObject<UICharacterRaceDataAsset> RaceData { get; set; }

		[FieldOffset(44, 160)]
		public ExternalObject<UICharacterClassDataAsset> ClassData { get; set; }

		[FieldOffset(48, 168)]
		public ExternalObject<UICharacterSummaryDataAsset> SummaryData { get; set; }

		[FieldOffset(52, 176)]
		public ExternalObject<CreatureClassEnumTranslator> ClassTypeTranslator { get; set; }

		[FieldOffset(56, 184)]
		public LocalizedStringReference CorruptedLocString { get; set; }

		[FieldOffset(60, 208)]
		public LocalizedStringReference CorruptedSaveLabelLocString { get; set; }

		[FieldOffset(64, 232)]
		public LocalizedStringReference MaxSaveLocString { get; set; }

		[FieldOffset(68, 256)]
		public LocalizedStringReference NewGameMaxSaveLocString { get; set; }

		[FieldOffset(72, 280)]
		public LocalizedStringReference AutoSaveMaxSaveLocString { get; set; }

		[FieldOffset(76, 304)]
		public LocalizedStringReference LoadErrorMissingDLCContent { get; set; }

		[FieldOffset(80, 328)]
		public LocalizedStringReference LoadErrorMissingInstallContent { get; set; }

		[FieldOffset(84, 352)]
		public LocalizedStringReference LoadErrorTrialMode { get; set; }

		[FieldOffset(88, 376)]
		public LocalizedStringReference LoadErrorBuildNumber { get; set; }

		[FieldOffset(92, 400)]
		public LocalizedStringReference EnumeratingSaves { get; set; }
	}
}
