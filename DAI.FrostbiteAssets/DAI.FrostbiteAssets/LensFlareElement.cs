using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LensFlareElement : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec4 SizeOccluderCurve { get; set; }

		[FieldOffset(16, 16)]
		public Vec4 SizeScreenPosCurve { get; set; }

		[FieldOffset(32, 32)]
		public Vec4 SizeAngleCurve { get; set; }

		[FieldOffset(48, 48)]
		public Vec4 SizeCamDistCurve { get; set; }

		[FieldOffset(64, 64)]
		public Vec4 AlphaOccluderCurve { get; set; }

		[FieldOffset(80, 80)]
		public Vec4 AlphaScreenPosCurve { get; set; }

		[FieldOffset(96, 96)]
		public Vec4 AlphaAngleCurve { get; set; }

		[FieldOffset(112, 112)]
		public Vec4 AlphaCamDistCurve { get; set; }

		[FieldOffset(128, 128)]
		public Vec4 RotationDistCurve { get; set; }

		[FieldOffset(144, 144)]
		public QualityScalableEnabled Enable { get; set; }

		[FieldOffset(148, 152)]
		public SurfaceShaderInstanceDataStruct Shader { get; set; }

		[FieldOffset(168, 192)]
		public float RayDistance { get; set; }

		[FieldOffset(172, 196)]
		public Vec2 Size { get; set; }

		[FieldOffset(180, 204)]
		public float SizeCamDistMax { get; set; }

		[FieldOffset(184, 208)]
		public float AlphaCamDistMax { get; set; }

		[FieldOffset(188, 212)]
		public float RotationLocal { get; set; }

		[FieldOffset(192, 216)]
		public float RotationDistMultiplier { get; set; }

		[FieldOffset(196, 220)]
		public bool RotationAlignedToRay { get; set; }
	}
}
