namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundEntityTrackKeyframeData : TimelineKeyframeData
	{
		[FieldOffset(8, 24)]
		public float Time { get; set; }

		[FieldOffset(12, 28)]
		public float Length { get; set; }
	}
}
