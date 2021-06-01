using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootContainerData : DataContainer
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference LootContainerName { get; set; }

		[FieldOffset(12, 48)]
		public UITextureAtlasTextureReference GUIIcon { get; set; }

		[FieldOffset(32, 88)]
		public LootTierLevel DefaultLootTierLevel { get; set; }
	}
}
