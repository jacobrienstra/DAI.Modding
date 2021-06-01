using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class OriginalLocalLightEntityData : LocalLightEntityData
	{
		[FieldOffset(96, 192)]
		public Vec3 Color { get; set; }

		[FieldOffset(112, 208)]
		public Vec3 EnlightenColorScale { get; set; }

		[FieldOffset(128, 224)]
		public Vec3 ParticleColorScale { get; set; }

		[FieldOffset(144, 240)]
		public float Radius { get; set; }

		[FieldOffset(148, 244)]
		public float Intensity { get; set; }

		[FieldOffset(152, 248)]
		public float AttenuationOffset { get; set; }

		[FieldOffset(156, 252)]
		public EnlightenColorMode EnlightenColorMode { get; set; }

		[FieldOffset(160, 256)]
		public bool DirectLightEnable { get; set; }

		[FieldOffset(161, 257)]
		public bool SpecularEnable { get; set; }

		[FieldOffset(162, 258)]
		public bool EnlightenEnable { get; set; }
	}
}
