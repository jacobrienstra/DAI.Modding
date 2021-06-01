using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterBlueprintBundleCollection : Asset
	{
		[FieldOffset(12, 72)]
		public List<CharacterBlueprintBundle> Items { get; set; }

		public CharacterBlueprintBundleCollection()
		{
			Items = new List<CharacterBlueprintBundle>();
		}
	}
}
