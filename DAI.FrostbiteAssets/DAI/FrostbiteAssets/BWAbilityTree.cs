using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityTree : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public LocalizedStringReference TreeNameReference { get; set; }

		[FieldOffset(16, 96)]
		public LocalizedStringReference TreeDescriptionReference { get; set; }

		[FieldOffset(20, 120)]
		public UITextureAtlasTextureReference AbilityTreeIcon { get; set; }

		[FieldOffset(40, 160)]
		public float AbilityTreeIconX { get; set; }

		[FieldOffset(44, 164)]
		public float AbilityTreeIconY { get; set; }

		[FieldOffset(48, 168)]
		public UITextureAtlasTextureReference AbilityTreeBackground { get; set; }

		[FieldOffset(68, 208)]
		public List<ExternalObject<BWAbilityTreeItem>> Abilities { get; set; }

		[FieldOffset(72, 216)]
		public int MPSlotId { get; set; }

		public BWAbilityTree()
		{
			Abilities = new List<ExternalObject<BWAbilityTreeItem>>();
		}
	}
}
