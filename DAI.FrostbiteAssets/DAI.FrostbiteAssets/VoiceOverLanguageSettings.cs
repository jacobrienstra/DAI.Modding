namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VoiceOverLanguageSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public ExternalObject<VoiceOverLanguageBundlesList> BundlesList { get; set; }
	}
}
