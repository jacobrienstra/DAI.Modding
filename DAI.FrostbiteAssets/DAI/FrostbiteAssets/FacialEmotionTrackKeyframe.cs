using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FacialEmotionTrackKeyframe : TimelineKeyframeData
	{
		[FieldOffset(8, 24)]
		public float Time { get; set; }

		[FieldOffset(12, 28)]
		public float TransitionTime { get; set; }

		[FieldOffset(16, 32)]
		public FacialEmotionTransitionType TransitionFunction { get; set; }

		[FieldOffset(20, 40)]
		public ExternalObject<FacialEmotionSetting> EmotionPreset { get; set; }

		[FieldOffset(24, 48)]
		public float WeightAdjustment { get; set; }

		[FieldOffset(28, 56)]
		public ExternalObject<FacialEmotionSetting> EmotionOverride { get; set; }
	}
}
