using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LocalizedStringTranslationsConfigurationSettings : Asset
	{
		[FieldOffset(12, 72)]
		public LanguageFormat MasterLanguage { get; set; }
	}
}
