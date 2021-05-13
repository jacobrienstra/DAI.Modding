using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class FilmicEffectsComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 DepthFlashAtmosColor { get; set; }

		[FieldOffset(128, 208)]
		public Realm Realm { get; set; }

		[FieldOffset(132, 212)]
		public float ChromaticAbberationScale { get; set; }

		[FieldOffset(136, 216)]
		public float ChromaticAbberationAspectRatio { get; set; }

		[FieldOffset(140, 220)]
		public float VignettingFalloff { get; set; }

		[FieldOffset(144, 224)]
		public float VignettingLuminancePercent { get; set; }

		[FieldOffset(148, 228)]
		public float LensDistortionGain { get; set; }

		[FieldOffset(152, 232)]
		public float LensDistortionCubicGain { get; set; }

		[FieldOffset(156, 236)]
		public float FrameFlashGain { get; set; }

		[FieldOffset(160, 240)]
		public float FrameFlashThresholdMin { get; set; }

		[FieldOffset(164, 244)]
		public float DepthFlashAtmosMix { get; set; }

		[FieldOffset(168, 248)]
		public float DepthFlashHalfDistance { get; set; }

		[FieldOffset(172, 252)]
		public float DepthFlashExponent { get; set; }

		[FieldOffset(176, 256)]
		public float DistanceBlurGain { get; set; }

		[FieldOffset(180, 260)]
		public float DistanceBlurHalfDistance { get; set; }

		[FieldOffset(184, 264)]
		public float DistanceBlurExponent { get; set; }

		[FieldOffset(188, 268)]
		public float EdgeBlurGain { get; set; }

		[FieldOffset(192, 272)]
		public float EdgeBlurDepthTargetScale { get; set; }

		[FieldOffset(196, 276)]
		public float EdgeBlurFadeNearDepth { get; set; }

		[FieldOffset(200, 280)]
		public float EdgeBlurFadeFarDepth { get; set; }

		[FieldOffset(204, 284)]
		public float EdgeBlurMatteDilateSize { get; set; }

		[FieldOffset(208, 288)]
		public float EdgeBlurMatteBlurKernelSize { get; set; }

		[FieldOffset(212, 292)]
		public bool Enable { get; set; }

		[FieldOffset(213, 293)]
		public bool EnableChromaticAbberation { get; set; }

		[FieldOffset(214, 294)]
		public bool EnableVignetting { get; set; }

		[FieldOffset(215, 295)]
		public bool EnableLensDistortion { get; set; }

		[FieldOffset(216, 296)]
		public bool EnableFrameFlash { get; set; }

		[FieldOffset(217, 297)]
		public bool EnableDepthFlash { get; set; }

		[FieldOffset(218, 298)]
		public bool EnableDistanceBlur { get; set; }

		[FieldOffset(219, 299)]
		public bool EnableEdgeBlur { get; set; }
	}
}
