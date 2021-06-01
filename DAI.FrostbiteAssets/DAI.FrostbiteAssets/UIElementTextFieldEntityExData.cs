namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementTextFieldEntityExData : UIElementTextFieldEntityData
	{
		[FieldOffset(240, 368)]
		public Vec3 TextRGB { get; set; }

		[FieldOffset(256, 384)]
		public int StringID { get; set; }

		[FieldOffset(260, 392)]
		public LocalizedStringReference LocalizedTextString { get; set; }

		[FieldOffset(264, 416)]
		public string TextString { get; set; }

		[FieldOffset(268, 424)]
		public float TextAlpha { get; set; }
	}
}
