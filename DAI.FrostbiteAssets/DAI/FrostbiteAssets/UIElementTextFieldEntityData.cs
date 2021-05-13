namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementTextFieldEntityData : UIElementEntityData
	{
		[FieldOffset(192, 304)]
		public ExternalObject<Dummy> Style { get; set; }

		[FieldOffset(196, 312)]
		public UIElementText Text { get; set; }

		[FieldOffset(216, 344)]
		public ExternalObject<UIElementFontStyle> FontStyle { get; set; }

		[FieldOffset(220, 352)]
		public float TextOffset { get; set; }

		[FieldOffset(224, 356)]
		public float AutoAdjustLeftPadding { get; set; }

		[FieldOffset(228, 360)]
		public float AutoAdjustRightPadding { get; set; }

		[FieldOffset(232, 364)]
		public bool AutoAdjustWidth { get; set; }

		[FieldOffset(233, 365)]
		public bool UseAutoScroll { get; set; }
	}
}
