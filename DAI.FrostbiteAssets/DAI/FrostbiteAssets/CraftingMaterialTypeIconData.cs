using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CraftingMaterialTypeIconData : LinkObject
	{
		[FieldOffset(0, 0)]
		public RecipeMaterialTypes MaterialType { get; set; }

		[FieldOffset(4, 8)]
		public UITextureAtlasTextureReference Icon { get; set; }
	}
}
