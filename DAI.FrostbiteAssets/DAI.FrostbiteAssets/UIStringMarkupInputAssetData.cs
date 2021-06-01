using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIStringMarkupInputAssetData : LinkObject
	{
		[FieldOffset(0, 0)]
		public GamePlatform Platform { get; set; }

		[FieldOffset(4, 8)]
		public UIStringMarkupImageData Image { get; set; }

		[FieldOffset(64, 112)]
		public LocalizedStringReference Text { get; set; }

		[FieldOffset(68, 136)]
		public bool IsAlternateData { get; set; }
	}
}
