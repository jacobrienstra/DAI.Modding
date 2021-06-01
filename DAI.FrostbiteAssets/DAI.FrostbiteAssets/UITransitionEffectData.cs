using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITransitionEffectData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<UIAnimatedTextureAsset> AnimatedTexture { get; set; }

		[FieldOffset(4, 8)]
		public int HorizontalOffset { get; set; }

		[FieldOffset(8, 12)]
		public int VerticalOffset { get; set; }

		[FieldOffset(12, 16)]
		public TransitionEffectHorizontalAlignment HorizontalAlign { get; set; }

		[FieldOffset(16, 20)]
		public TransitionEffectVerticalAlignment VerticalAlign { get; set; }

		[FieldOffset(20, 24)]
		public float FadeSpeedSec { get; set; }

		[FieldOffset(24, 28)]
		public float MinimumDisplayTimeSec { get; set; }

		[FieldOffset(28, 32)]
		public float BlackScreenDelay { get; set; }
	}
}
