using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SpotLightEntityData : OriginalLocalLightEntityData
	{
		[FieldOffset(176, 272)]
		public SpotLightShape Shape { get; set; }

		[FieldOffset(180, 276)]
		public float ConeInnerAngle { get; set; }

		[FieldOffset(184, 280)]
		public float ConeOuterAngle { get; set; }

		[FieldOffset(188, 284)]
		public float FrustumFov { get; set; }

		[FieldOffset(192, 288)]
		public float FrustumAspect { get; set; }

		[FieldOffset(196, 292)]
		public float OrthoWidth { get; set; }

		[FieldOffset(200, 296)]
		public float OrthoHeight { get; set; }

		[FieldOffset(204, 300)]
		public float NearPlane { get; set; }

		[FieldOffset(208, 304)]
		public ExternalObject<TextureAsset> Texture { get; set; }

		[FieldOffset(212, 312)]
		public QualityScalableEnabled CastShadows { get; set; }

		[FieldOffset(216, 316)]
		public float ShadowRadius { get; set; }

		[FieldOffset(220, 320)]
		public float ShadowCullDistance { get; set; }

		[FieldOffset(224, 324)]
		public QualityScalableEnabled FrustumAsCone { get; set; }

		[FieldOffset(228, 328)]
		public float FrustumAsConeIntensityScale { get; set; }

		[FieldOffset(232, 332)]
		public QualityLevel CastShadowsMinLevel { get; set; }

		[FieldOffset(236, 336)]
		public bool FrustumAsConeAngle { get; set; }

		[FieldOffset(237, 337)]
		public bool CastShadowsEnable { get; set; }
	}
}
