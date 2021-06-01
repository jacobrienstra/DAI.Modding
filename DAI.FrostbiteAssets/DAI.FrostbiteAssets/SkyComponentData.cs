using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SkyComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 CloudLayerSunColor { get; set; }

		[FieldOffset(128, 208)]
		public Vec3 CloudLayer1Color { get; set; }

		[FieldOffset(144, 224)]
		public Vec3 CloudLayer2Color { get; set; }

		[FieldOffset(160, 240)]
		public Realm Realm { get; set; }

		[FieldOffset(164, 244)]
		public SkyType SkyType { get; set; }

		[FieldOffset(168, 248)]
		public float BrightnessScale { get; set; }

		[FieldOffset(172, 256)]
		public ExternalObject<TextureAsset> SkyGradientTexture { get; set; }

		[FieldOffset(176, 264)]
		public AlphaOutputMode AlphaOutput { get; set; }

		[FieldOffset(180, 268)]
		public float HdriRotation { get; set; }

		[FieldOffset(184, 272)]
		public ExternalObject<Dummy> HdriTexture { get; set; }

		[FieldOffset(188, 280)]
		public float SunSize { get; set; }

		[FieldOffset(192, 284)]
		public float SunScale { get; set; }

		[FieldOffset(196, 288)]
		public float PanoramicUVMinX { get; set; }

		[FieldOffset(200, 292)]
		public float PanoramicUVMaxX { get; set; }

		[FieldOffset(204, 296)]
		public float PanoramicUVMinY { get; set; }

		[FieldOffset(208, 300)]
		public float PanoramicUVMaxY { get; set; }

		[FieldOffset(212, 304)]
		public float PanoramicTileFactor { get; set; }

		[FieldOffset(216, 308)]
		public float PanoramicRotation { get; set; }

		[FieldOffset(220, 312)]
		public ExternalObject<TextureAsset> PanoramicTexture { get; set; }

		[FieldOffset(224, 320)]
		public ExternalObject<TextureAsset> PanoramicAlphaTexture { get; set; }

		[FieldOffset(228, 328)]
		public ExternalObject<TextureAsset> CloudLayerMaskTexture { get; set; }

		[FieldOffset(232, 336)]
		public float CloudLayer1Altitude { get; set; }

		[FieldOffset(236, 340)]
		public float CloudLayer1TileFactor { get; set; }

		[FieldOffset(240, 344)]
		public float CloudLayer1Rotation { get; set; }

		[FieldOffset(244, 348)]
		public float CloudLayer1Speed { get; set; }

		[FieldOffset(248, 352)]
		public float CloudLayer1SunLightIntensity { get; set; }

		[FieldOffset(252, 356)]
		public float CloudLayer1SunLightPower { get; set; }

		[FieldOffset(256, 360)]
		public float CloudLayer1AmbientLightIntensity { get; set; }

		[FieldOffset(260, 364)]
		public float CloudLayer1AlphaMul { get; set; }

		[FieldOffset(264, 368)]
		public ExternalObject<TextureAsset> CloudLayer1Texture { get; set; }

		[FieldOffset(268, 376)]
		public float CloudLayer2Altitude { get; set; }

		[FieldOffset(272, 380)]
		public float CloudLayer2TileFactor { get; set; }

		[FieldOffset(276, 384)]
		public float CloudLayer2Rotation { get; set; }

		[FieldOffset(280, 388)]
		public float CloudLayer2Speed { get; set; }

		[FieldOffset(284, 392)]
		public float CloudLayer2SunLightIntensity { get; set; }

		[FieldOffset(288, 396)]
		public float CloudLayer2SunLightPower { get; set; }

		[FieldOffset(292, 400)]
		public float CloudLayer2AmbientLightIntensity { get; set; }

		[FieldOffset(296, 404)]
		public float CloudLayer2AlphaMul { get; set; }

		[FieldOffset(300, 408)]
		public ExternalObject<TextureAsset> CloudLayer2Texture { get; set; }

		[FieldOffset(304, 416)]
		public ExternalObject<TextureAsset> StaticEnvmapTexture { get; set; }

		[FieldOffset(308, 424)]
		public float StaticEnvmapScale { get; set; }

		[FieldOffset(312, 428)]
		public float SkyEnvmap8BitTexScale { get; set; }

		[FieldOffset(316, 432)]
		public ExternalObject<TextureAsset> CustomEnvmapTexture { get; set; }

		[FieldOffset(320, 440)]
		public float CustomEnvmapScale { get; set; }

		[FieldOffset(324, 444)]
		public float CustomEnvmapAmbient { get; set; }

		[FieldOffset(328, 448)]
		public float SkyVisibilityExponent { get; set; }

		[FieldOffset(332, 452)]
		public bool Enable { get; set; }

		[FieldOffset(333, 453)]
		public bool IndirectCubeMapOverride { get; set; }
	}
}
