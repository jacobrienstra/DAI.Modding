using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICharacterClassDataAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<CharacterClassUIData> CharacterClasses { get; set; }

		public UICharacterClassDataAsset()
		{
			CharacterClasses = new List<CharacterClassUIData>();
		}
	}
}
