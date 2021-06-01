namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementTextFilterDropShadow : UIElementTextFilter
	{
		[FieldOffset(8, 24)]
		public float X { get; set; }

		[FieldOffset(12, 28)]
		public float Y { get; set; }

		[FieldOffset(16, 32)]
		public UIElementColor Color { get; set; }

		[FieldOffset(48, 64)]
		public float Strength { get; set; }

		[FieldOffset(52, 68)]
		public float Angle { get; set; }

		[FieldOffset(56, 72)]
		public float Distance { get; set; }

		[FieldOffset(60, 76)]
		public bool KnockOut { get; set; }

		[FieldOffset(61, 77)]
		public bool HideObject { get; set; }

		[FieldOffset(62, 78)]
		public bool FineBlur { get; set; }
	}
}
