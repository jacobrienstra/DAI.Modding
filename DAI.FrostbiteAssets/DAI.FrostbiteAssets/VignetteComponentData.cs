using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class VignetteComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 Color { get; set; }

		[FieldOffset(128, 208)]
		public Realm Realm { get; set; }

		[FieldOffset(132, 212)]
		public Vec2 Scale { get; set; }

		[FieldOffset(140, 220)]
		public float Exponent { get; set; }

		[FieldOffset(144, 224)]
		public float Opacity { get; set; }

		[FieldOffset(148, 228)]
		public bool Enable { get; set; }
	}
}
