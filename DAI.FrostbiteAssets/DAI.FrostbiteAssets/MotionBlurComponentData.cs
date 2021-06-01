using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class MotionBlurComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Realm Realm { get; set; }

		[FieldOffset(116, 196)]
		public float MotionBlurScale { get; set; }

		[FieldOffset(120, 200)]
		public float MotionBlurCutoffRadius { get; set; }

		[FieldOffset(124, 204)]
		public float CutoffGradientScale { get; set; }

		[FieldOffset(128, 208)]
		public Vec2 RadialBlurCenter { get; set; }

		[FieldOffset(136, 216)]
		public float RadialBlurOffset { get; set; }

		[FieldOffset(140, 220)]
		public float RadialBlurScale { get; set; }

		[FieldOffset(144, 224)]
		public bool MotionBlurEnable { get; set; }

		[FieldOffset(145, 225)]
		public bool MotionBlurCentered { get; set; }

		[FieldOffset(146, 226)]
		public bool RadialBlurEnable { get; set; }
	}
}
