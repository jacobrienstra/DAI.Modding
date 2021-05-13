namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIMinimapDistanceFieldParams : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec4 ColorTint { get; set; }

		[FieldOffset(16, 16)]
		public Vec4 OutlineColor { get; set; }

		[FieldOffset(32, 32)]
		public ExternalObject<Dummy> DistanceField { get; set; }

		[FieldOffset(36, 40)]
		public float AlphaThreshold { get; set; }

		[FieldOffset(40, 44)]
		public float DistanceScale { get; set; }

		[FieldOffset(44, 48)]
		public float OutlineInner { get; set; }

		[FieldOffset(48, 52)]
		public float OutlineOuter { get; set; }
	}
}
