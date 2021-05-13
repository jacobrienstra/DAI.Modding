using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PlanarReflectionComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 KeyColorReflection { get; set; }

		[FieldOffset(128, 208)]
		public Vec3 SkyColorReflection { get; set; }

		[FieldOffset(144, 224)]
		public Vec3 GroundColorReflection { get; set; }

		[FieldOffset(160, 240)]
		public Realm Realm { get; set; }

		[FieldOffset(164, 244)]
		public float GroundHeight { get; set; }

		[FieldOffset(168, 248)]
		public float ViewDistance { get; set; }

		[FieldOffset(172, 252)]
		public BlurFilter VerticalBlurFilter { get; set; }

		[FieldOffset(176, 256)]
		public float VerticalDeviation { get; set; }

		[FieldOffset(180, 260)]
		public BlurFilter HorizontalBlurFilter { get; set; }

		[FieldOffset(184, 264)]
		public float HorizontalDeviation { get; set; }

		[FieldOffset(188, 268)]
		public bool Enable { get; set; }

		[FieldOffset(189, 269)]
		public bool TerrainReflectionsEnable { get; set; }

		[FieldOffset(190, 270)]
		public bool SkyRenderEnable { get; set; }

		[FieldOffset(191, 271)]
		public bool OverideOutdoorLightColors { get; set; }

		[FieldOffset(192, 272)]
		public bool FogEnable { get; set; }

		[FieldOffset(193, 273)]
		public bool AlphaAsDepthEnable { get; set; }
	}
}
