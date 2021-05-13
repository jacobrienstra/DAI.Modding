namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBaseChoiceOption : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<TextureAsset> OptionTexture { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference OptionTitle { get; set; }

		[FieldOffset(8, 32)]
		public LocalizedStringReference OptionShortDesc { get; set; }

		[FieldOffset(12, 56)]
		public LocalizedStringReference OptionDesc { get; set; }

		[FieldOffset(16, 80)]
		public string OptionId { get; set; }
	}
}
