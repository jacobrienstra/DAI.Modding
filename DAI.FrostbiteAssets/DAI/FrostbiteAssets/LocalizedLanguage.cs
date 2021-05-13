using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LocalizedLanguage : Asset
	{
		[FieldOffset(12, 72)]
		public LanguageFormat Language { get; set; }

		[FieldOffset(16, 80)]
		public string LanguageLocaleCode { get; set; }

		[FieldOffset(20, 88)]
		public LocalizedStringReference DisplayName { get; set; }

		[FieldOffset(24, 112)]
		public LanguageGrammarRequirements GrammarRequirements { get; set; }
	}
}
