using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ColorCorrectionComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 Brightness { get; set; }

		[FieldOffset(128, 208)]
		public Vec3 Contrast { get; set; }

		[FieldOffset(144, 224)]
		public Vec3 Saturation { get; set; }

		[FieldOffset(160, 240)]
		public Realm Realm { get; set; }

		[FieldOffset(164, 244)]
		public float Hue { get; set; }

		[FieldOffset(168, 248)]
		public ExternalObject<TextureAsset> ColorGradingTexture { get; set; }

		[FieldOffset(172, 256)]
		public bool Enable { get; set; }

		[FieldOffset(173, 257)]
		public bool ColorGradingEnable { get; set; }
	}
}
