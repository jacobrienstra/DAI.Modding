using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CraftingSlotTypeIconData : LinkObject
	{
		[FieldOffset(0, 0)]
		public CraftingSlotIconType IconType { get; set; }

		[FieldOffset(4, 8)]
		public UITextureAtlasTextureReference Icon { get; set; }
	}
}
