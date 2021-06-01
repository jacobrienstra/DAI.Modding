using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationVoiceOverBinding : DataContainer
	{
		[FieldOffset(8, 24)]
		public LanguageFormat Language { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<SoundWaveAsset> VoiceOverAsset { get; set; }
	}
}
