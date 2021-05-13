using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterBlueprintBundleIndexMapItemAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<CharacterBlueprintBundleIndexMapItem> BundleIndexItems { get; set; }

		public CharacterBlueprintBundleIndexMapItemAsset()
		{
			BundleIndexItems = new List<CharacterBlueprintBundleIndexMapItem>();
		}
	}
}
