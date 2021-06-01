using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LocalizedCharacterVoice : Asset
	{
		[FieldOffset(12, 72)]
		public string VoiceName { get; set; }

		[FieldOffset(16, 80)]
		public string Accent { get; set; }

		[FieldOffset(20, 88)]
		public string VOProductionFilenameCategory { get; set; }

		[FieldOffset(24, 96)]
		public string VOPipelineFilenameVariant { get; set; }

		[FieldOffset(28, 104)]
		public string TTSVoice { get; set; }

		[FieldOffset(32, 112)]
		public CharacterGender Gender { get; set; }

		[FieldOffset(36, 116)]
		public bool IsPlayer { get; set; }
	}
}
