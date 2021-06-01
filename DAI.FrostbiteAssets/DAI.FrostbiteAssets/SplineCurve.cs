using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SplineCurve
	{
		[FieldOffset(0, 0)]
		public Vec4 XValues0 { get; set; }

		[FieldOffset(16, 16)]
		public Vec4 XValues1 { get; set; }

		[FieldOffset(32, 32)]
		public Vec4 XValues2 { get; set; }

		[FieldOffset(48, 48)]
		public Vec4 YValues0 { get; set; }

		[FieldOffset(64, 64)]
		public Vec4 YValues1 { get; set; }

		[FieldOffset(80, 80)]
		public Vec4 YValues2 { get; set; }

		[FieldOffset(96, 96)]
		public Vec4 YValues3 { get; set; }

		[FieldOffset(112, 112)]
		public Vec4 GValues0 { get; set; }

		[FieldOffset(128, 128)]
		public Vec4 GValues1 { get; set; }

		[FieldOffset(144, 144)]
		public Vec4 GValues2 { get; set; }

		[FieldOffset(160, 160)]
		public Vec4 GValues3 { get; set; }

		[FieldOffset(176, 176)]
		public Vec4 GValues4 { get; set; }

		[FieldOffset(192, 192)]
		public Vec4 GValues5 { get; set; }

		[FieldOffset(208, 208)]
		public SplineType SplineType { get; set; }
	}
}
