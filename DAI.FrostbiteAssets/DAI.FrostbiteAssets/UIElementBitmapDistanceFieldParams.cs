namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementBitmapDistanceFieldParams : LinkObject
	{
		[FieldOffset(0, 0)]
		public UIElementColor OutlineColor { get; set; }

		[FieldOffset(32, 32)]
		public float AlphaThreshold { get; set; }

		[FieldOffset(36, 36)]
		public float DistanceScale { get; set; }

		[FieldOffset(40, 40)]
		public float OutlineInner { get; set; }

		[FieldOffset(44, 44)]
		public float OutlineOuter { get; set; }
	}
}
