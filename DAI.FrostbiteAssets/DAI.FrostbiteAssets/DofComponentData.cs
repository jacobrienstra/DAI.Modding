using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DofComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Realm Realm { get; set; }

		[FieldOffset(116, 196)]
		public float FocusDistance { get; set; }

		[FieldOffset(120, 200)]
		public float BlurFactor { get; set; }

		[FieldOffset(124, 204)]
		public float BlurAdd { get; set; }

		[FieldOffset(128, 208)]
		public BlurFilter SimpleDofBlurFilter { get; set; }

		[FieldOffset(132, 212)]
		public float SimpleDofMaxBlur { get; set; }

		[FieldOffset(136, 216)]
		public float SimpleDofNearStart { get; set; }

		[FieldOffset(140, 220)]
		public float SimpleDofNearEnd { get; set; }

		[FieldOffset(144, 224)]
		public float SimpleDofFarStart { get; set; }

		[FieldOffset(148, 228)]
		public float SimpleDofFarEnd { get; set; }

		[FieldOffset(152, 232)]
		public float HipToIronsightsFade { get; set; }

		[FieldOffset(156, 236)]
		public float IronsightsDofStartFade { get; set; }

		[FieldOffset(160, 240)]
		public float IronsightsFocalDistance { get; set; }

		[FieldOffset(164, 244)]
		public float IronsightsDofCircleDistance { get; set; }

		[FieldOffset(168, 248)]
		public float SpriteDofNearStart { get; set; }

		[FieldOffset(172, 252)]
		public float SpriteDofNearEnd { get; set; }

		[FieldOffset(176, 256)]
		public float SpriteDofFarStart { get; set; }

		[FieldOffset(180, 260)]
		public float SpriteDofFarEnd { get; set; }

		[FieldOffset(184, 264)]
		public float SpriteDofMaxBlur { get; set; }

		[FieldOffset(188, 272)]
		public ExternalObject<TextureAsset> SpriteDofBokehTexture { get; set; }

		[FieldOffset(192, 280)]
		public bool Enable { get; set; }

		[FieldOffset(193, 281)]
		public bool DebugDrawFocusPlane { get; set; }

		[FieldOffset(194, 282)]
		public bool IronsightsDofActive { get; set; }

		[FieldOffset(195, 283)]
		public bool IronsightsDofCircleBlur { get; set; }
	}
}
