using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LocalizedStringTranslationsConfiguration : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<LocalizedStringTranslationsConfigurationSettings> GlobalSettings { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<LocalizedLanguage>> Languages { get; set; }

		[FieldOffset(20, 88)]
		public string SuperbundleName { get; set; }

		[FieldOffset(24, 96)]
		public string BundleName { get; set; }

		[FieldOffset(28, 104)]
		public string TextTableRootDir { get; set; }

		[FieldOffset(32, 112)]
		public List<string> TextTableSubPaths { get; set; }

		[FieldOffset(36, 120)]
		public List<LanguageBundlesListEntry> LanguagesToBundlesList { get; set; }

		[FieldOffset(40, 128)]
		public bool SuperbundleIsOptional { get; set; }

		public LocalizedStringTranslationsConfiguration()
		{
			Languages = new List<ExternalObject<LocalizedLanguage>>();
			TextTableSubPaths = new List<string>();
			LanguagesToBundlesList = new List<LanguageBundlesListEntry>();
		}
	}
}
