using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LocalizedCharacter : Asset
	{
		[FieldOffset(12, 72)]
		public string LevelObjectID { get; set; }

		[FieldOffset(16, 80)]
		public string CharacterName { get; set; }

		[FieldOffset(20, 88)]
		public CharacterGender Gender { get; set; }

		[FieldOffset(24, 96)]
		public string CharacterDescription { get; set; }

		[FieldOffset(28, 104)]
		public string SpeechPattern { get; set; }

		[FieldOffset(32, 112)]
		public string Accent { get; set; }

		[FieldOffset(36, 120)]
		public string Race { get; set; }

		[FieldOffset(40, 128)]
		public string Appearance { get; set; }

		[FieldOffset(44, 136)]
		public string CharacterArchetype { get; set; }

		[FieldOffset(48, 144)]
		public CharacterType CharacterType { get; set; }

		[FieldOffset(52, 152)]
		public string TTSVoice { get; set; }

		[FieldOffset(56, 160)]
		public List<ExternalObject<LocalizedCharacter>> SubCharacters { get; set; }

		[FieldOffset(60, 168)]
		public List<ExternalObject<Asset>> Voices { get; set; }

		[FieldOffset(64, 176)]
		public byte AgeRange { get; set; }

		[FieldOffset(65, 177)]
		public bool IsPlayer { get; set; }

		[FieldOffset(66, 178)]
		public bool VOEligible { get; set; }

		public LocalizedCharacter()
		{
			SubCharacters = new List<ExternalObject<LocalizedCharacter>>();
			Voices = new List<ExternalObject<Asset>>();
		}
	}
}
