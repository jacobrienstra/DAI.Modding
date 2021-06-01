namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIElementFontStyle : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<UIElementFontDefinition> Hd { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<Dummy> HdColorBlind { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<Dummy> Sd { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<Dummy> SdColorBlind { get; set; }
	}
}
