using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class OutdoorLightComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 SunColor { get; set; }

		[FieldOffset(128, 208)]
		public Vec3 SkyColor { get; set; }

		[FieldOffset(144, 224)]
		public Vec3 GroundColor { get; set; }

		[FieldOffset(160, 240)]
		public Realm Realm { get; set; }

		[FieldOffset(164, 244)]
		public float SunRotationX { get; set; }

		[FieldOffset(168, 248)]
		public float SunRotationY { get; set; }

		[FieldOffset(172, 252)]
		public float ShadowSunRotationX { get; set; }

		[FieldOffset(176, 256)]
		public float ShadowSunRotationY { get; set; }

		[FieldOffset(180, 260)]
		public float SunAngularRadius { get; set; }

		[FieldOffset(184, 264)]
		public float SkyLightAngleFactor { get; set; }

		[FieldOffset(188, 268)]
		public float SunSpecularScale { get; set; }

		[FieldOffset(192, 272)]
		public float SkyEnvmapShadowScale { get; set; }

		[FieldOffset(196, 276)]
		public float SunShadowHeightScale { get; set; }

		[FieldOffset(200, 280)]
		public ShadowFilteringType SunShadowFilterType { get; set; }

		[FieldOffset(204, 284)]
		public int SunPcssInitialSampleCount { get; set; }

		[FieldOffset(208, 288)]
		public int SunPcssMaximumSampleCount { get; set; }

		[FieldOffset(212, 292)]
		public float SunPcssFilterErrorThresholdPct { get; set; }

		[FieldOffset(216, 296)]
		public float SunPenumbraSize { get; set; }

		[FieldOffset(220, 300)]
		public float SunPcssShadowFilterScale { get; set; }

		[FieldOffset(224, 304)]
		public ExternalObject<TextureAsset> CloudShadowTexture { get; set; }

		[FieldOffset(228, 312)]
		public Vec2 CloudShadowSpeed { get; set; }

		[FieldOffset(236, 320)]
		public float CloudShadowSize { get; set; }

		[FieldOffset(240, 324)]
		public float CloudShadowCoverage { get; set; }

		[FieldOffset(244, 328)]
		public float CloudShadowExponent { get; set; }

		[FieldOffset(248, 332)]
		public float CloudShadowStartFade { get; set; }

		[FieldOffset(252, 336)]
		public float CloudShadowsFadeDistance { get; set; }

		[FieldOffset(256, 340)]
		public Vec2 CloudXZTranslation { get; set; }

		[FieldOffset(264, 348)]
		public TextureAddress CloudShadowAddressingMode { get; set; }

		[FieldOffset(268, 352)]
		public float TranslucencyAmbient { get; set; }

		[FieldOffset(272, 356)]
		public float TranslucencyScale { get; set; }

		[FieldOffset(276, 360)]
		public float TranslucencyPower { get; set; }

		[FieldOffset(280, 364)]
		public float TranslucencyDistortion { get; set; }

		[FieldOffset(284, 368)]
		public bool Enable { get; set; }

		[FieldOffset(285, 369)]
		public bool ShadowSunRotationEnable { get; set; }

		[FieldOffset(286, 370)]
		public bool SunPcssFilterAdaptive { get; set; }

		[FieldOffset(287, 371)]
		public bool CloudShadowEnable { get; set; }

		[FieldOffset(288, 372)]
		public bool CloudShadowIsTopDown { get; set; }
	}
}
