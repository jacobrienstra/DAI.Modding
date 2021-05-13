namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VoiceOverLanguageSetting : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<LocalizedLanguage> LocLanguage { get; set; }

		[FieldOffset(12, 32)]
		public string BaseBundlePath { get; set; }

		[FieldOffset(16, 40)]
		public byte NumberOfBundles { get; set; }
	}
}
