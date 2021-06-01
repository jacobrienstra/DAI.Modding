using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICharacterSummaryDataAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<CharacterSummaryUIData> CharacterSummaries { get; set; }

		[FieldOffset(16, 80)]
		public string DefaultCanonCardName { get; set; }

		[FieldOffset(20, 88)]
		public string CustomCanonCardName { get; set; }

		public UICharacterSummaryDataAsset()
		{
			CharacterSummaries = new List<CharacterSummaryUIData>();
		}
	}
}
