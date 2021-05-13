using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VoiceOverLanguageBundlesList : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<VoiceOverLanguageSetting>> LanguageSettings { get; set; }

		public VoiceOverLanguageBundlesList()
		{
			LanguageSettings = new List<ExternalObject<VoiceOverLanguageSetting>>();
		}
	}
}
