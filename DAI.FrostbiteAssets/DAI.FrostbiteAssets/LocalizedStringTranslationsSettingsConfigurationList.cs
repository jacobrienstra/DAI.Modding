using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LocalizedStringTranslationsSettingsConfigurationList : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<LocalizedStringTranslationsSettingsConfiguration>> Configurations { get; set; }

		public LocalizedStringTranslationsSettingsConfigurationList()
		{
			Configurations = new List<ExternalObject<LocalizedStringTranslationsSettingsConfiguration>>();
		}
	}
}
