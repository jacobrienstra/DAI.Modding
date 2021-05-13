using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class FogComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec4 Curve { get; set; }

		[FieldOffset(128, 208)]
		public Vec3 FogColor { get; set; }

		[FieldOffset(144, 224)]
		public Vec4 FogColorCurve { get; set; }

		[FieldOffset(160, 240)]
		public Vec4 TransparencyFadeCurve { get; set; }

		[FieldOffset(176, 256)]
		public Vec3 ForwardLightScatteringColor { get; set; }

		[FieldOffset(192, 272)]
		public Realm Realm { get; set; }

		[FieldOffset(196, 276)]
		public float FogDistanceMultiplier { get; set; }

		[FieldOffset(200, 280)]
		public float Start { get; set; }

		[FieldOffset(204, 284)]
		public float End { get; set; }

		[FieldOffset(208, 288)]
		public float FogColorStart { get; set; }

		[FieldOffset(212, 292)]
		public float FogColorEnd { get; set; }

		[FieldOffset(216, 296)]
		public float TransparencyFadeStart { get; set; }

		[FieldOffset(220, 300)]
		public float TransparencyFadeEnd { get; set; }

		[FieldOffset(224, 304)]
		public float TransparencyFadeClamp { get; set; }

		[FieldOffset(228, 308)]
		public float ForwardLightScatteringPhaseG { get; set; }

		[FieldOffset(232, 312)]
		public float ForwardLightScatteringStrength { get; set; }

		[FieldOffset(236, 316)]
		public float ForwardLightScatteringPresence { get; set; }

		[FieldOffset(240, 320)]
		public float ForwardLightScatteringMaxBlurLength { get; set; }

		[FieldOffset(244, 324)]
		public float ForwardLightScatteringExtinction { get; set; }

		[FieldOffset(248, 328)]
		public float ForwardLightScatteringSmoothness { get; set; }

		[FieldOffset(252, 332)]
		public float HeightFogFollowCamera { get; set; }

		[FieldOffset(256, 336)]
		public float HeightFogAltitude { get; set; }

		[FieldOffset(260, 340)]
		public float HeightFogDepth { get; set; }

		[FieldOffset(264, 344)]
		public float HeightFogVisibilityRange { get; set; }

		[FieldOffset(268, 348)]
		public bool Enable { get; set; }

		[FieldOffset(269, 349)]
		public bool FogGradientEnable { get; set; }

		[FieldOffset(270, 350)]
		public bool FogColorEnable { get; set; }

		[FieldOffset(271, 351)]
		public bool ForwardLightScatteringEnabled { get; set; }

		[FieldOffset(272, 352)]
		public bool HeightFogEnable { get; set; }
	}
}
