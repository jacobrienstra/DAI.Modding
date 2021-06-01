namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PotionCategoryData : LinkObject
	{
		[FieldOffset(0, 0)]
		public LocalizedStringReference PotionType { get; set; }

		[FieldOffset(4, 24)]
		public LocalizedStringReference PotionDescription { get; set; }

		[FieldOffset(8, 48)]
		public LocalizedStringReference UnknownPotionType { get; set; }

		[FieldOffset(12, 72)]
		public string CategoryBackgroundName { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<UIPotionCraftingItemAsset> TreeFlowRoot { get; set; }
	}
}
