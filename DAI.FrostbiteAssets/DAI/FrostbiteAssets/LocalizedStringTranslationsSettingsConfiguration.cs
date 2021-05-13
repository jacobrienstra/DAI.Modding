using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LocalizedStringTranslationsSettingsConfiguration : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<string> BaseAssetPaths { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<LocalizedStringTranslationsConfiguration> Configuration { get; set; }

		public LocalizedStringTranslationsSettingsConfiguration()
		{
			BaseAssetPaths = new List<string>();
		}
	}
}
