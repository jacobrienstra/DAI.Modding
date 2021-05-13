using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EnlightenComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 TerrainColor { get; set; }

		[FieldOffset(128, 208)]
		public Vec3 SkyBoxSkyColor { get; set; }

		[FieldOffset(144, 224)]
		public Vec3 SkyBoxGroundColor { get; set; }

		[FieldOffset(160, 240)]
		public Vec3 SkyBoxSunLightColor { get; set; }

		[FieldOffset(176, 256)]
		public Vec3 SkyBoxBackLightColor { get; set; }

		[FieldOffset(192, 272)]
		public Vec3 OpaqueAlphaTestSimpleScale { get; set; }

		[FieldOffset(208, 288)]
		public Realm Realm { get; set; }

		[FieldOffset(212, 292)]
		public float BounceScale { get; set; }

		[FieldOffset(216, 296)]
		public float SunScale { get; set; }

		[FieldOffset(220, 300)]
		public float CullDistance { get; set; }

		[FieldOffset(224, 304)]
		public float CullRadius { get; set; }

		[FieldOffset(228, 308)]
		public float SkyBoxSunLightColorSize { get; set; }

		[FieldOffset(232, 312)]
		public float SkyBoxBackLightColorSize { get; set; }

		[FieldOffset(236, 316)]
		public float SkyBoxBackLightRotationX { get; set; }

		[FieldOffset(240, 320)]
		public float SkyBoxBackLightRotationY { get; set; }

		[FieldOffset(244, 324)]
		public bool SkyBoxEnable { get; set; }
	}
}
