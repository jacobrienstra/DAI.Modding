namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIPartyCommandData : LinkObject
	{
		[FieldOffset(0, 0)]
		public LocalizedStringReference DisplayName { get; set; }

		[FieldOffset(4, 24)]
		public LocalizedStringReference Description { get; set; }

		[FieldOffset(8, 48)]
		public LocalizedStringReference Tooltip { get; set; }

		[FieldOffset(12, 72)]
		public UITextureAtlasTextureReference Icon { get; set; }
	}
}
