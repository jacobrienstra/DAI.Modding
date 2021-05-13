using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICharacterRaceDataAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<CharacterRaceUIData> CharacterRaces { get; set; }

		[FieldOffset(16, 80)]
		public string CustomizedCharacterCardName { get; set; }

		public UICharacterRaceDataAsset()
		{
			CharacterRaces = new List<CharacterRaceUIData>();
		}
	}
}
