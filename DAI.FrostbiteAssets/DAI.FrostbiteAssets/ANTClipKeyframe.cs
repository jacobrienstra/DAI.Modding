using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ANTClipKeyframe : TimelineKeyframeData
	{
		[FieldOffset(8, 24)]
		public float Time { get; set; }

		[FieldOffset(12, 28)]
		public float Length { get; set; }

		[FieldOffset(16, 32)]
		public AntRef Controller { get; set; }

		[FieldOffset(36, 80)]
		public float ClipStartTrim { get; set; }

		[FieldOffset(40, 84)]
		public float ClipEndTrim { get; set; }

		[FieldOffset(44, 88)]
		public float ClipCycleStartOffset { get; set; }

		[FieldOffset(48, 92)]
		public float ClipTimeScale { get; set; }

		[FieldOffset(52, 96)]
		public ANTClipEndRule ClipEndRule { get; set; }
	}
}
