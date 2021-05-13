using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlayerVoiceManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int Gender { get; set; }

		[FieldOffset(20, 100)]
		public int Race { get; set; }

		[FieldOffset(24, 104)]
		public int Variation { get; set; }

		[FieldOffset(28, 112)]
		public List<ExternalObject<LogicPrefabReferenceObjectData>> RaceGenderVoiceCombinations { get; set; }

		public PlayerVoiceManagerEntityData()
		{
			RaceGenderVoiceCombinations = new List<ExternalObject<LogicPrefabReferenceObjectData>>();
		}
	}
}
