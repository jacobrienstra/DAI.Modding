using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class GlareComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 Intensity { get; set; }

		[FieldOffset(128, 208)]
		public Realm Realm { get; set; }

		[FieldOffset(132, 212)]
		public float Attenuation { get; set; }

		[FieldOffset(136, 216)]
		public Vec2 Threshold { get; set; }

		[FieldOffset(144, 224)]
		public uint PassCount { get; set; }

		[FieldOffset(148, 228)]
		public bool Enable { get; set; }

		[FieldOffset(149, 229)]
		public bool PreBlur { get; set; }

		[FieldOffset(150, 230)]
		public bool PostBlur { get; set; }
	}
}
