using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TintingSlot : LinkObject
	{
		[FieldOffset(0, 0)]
		public LocalizedStringReference SlotName { get; set; }

		[FieldOffset(4, 24)]
		public RecipeMaterialTypes MaterialType { get; set; }

		[FieldOffset(8, 32)]
		public UITextureAtlasTextureReference MaterialIcon { get; set; }

		[FieldOffset(28, 72)]
		public LocalizedStringReference MaterialName { get; set; }

		[FieldOffset(32, 96)]
		public bool IsPrimary { get; set; }

		[FieldOffset(33, 97)]
		public byte MaterialUsedCount { get; set; }
	}
}
