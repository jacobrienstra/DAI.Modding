namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementTextFilterGlow : UIElementTextFilter
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
		public bool KnockOut { get; set; }

		[FieldOffset(53, 69)]
		public bool HideObject { get; set; }

		[FieldOffset(54, 70)]
		public bool FineBlur { get; set; }
	}
}
