using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FadeTrackKeyframe : DataContainer
	{
		[FieldOffset(8, 24)]
		public float Time { get; set; }

		[FieldOffset(12, 28)]
		public float Length { get; set; }

		[FieldOffset(16, 32)]
		public FadeTrackKeyframeType FadeType { get; set; }
	}
}
