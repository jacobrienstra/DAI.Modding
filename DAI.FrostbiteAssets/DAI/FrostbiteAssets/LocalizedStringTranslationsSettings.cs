namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LocalizedStringTranslationsSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public ExternalObject<LocalizedStringTranslationsSettingsConfigurationList> ConfigurationList { get; set; }
	}
}
