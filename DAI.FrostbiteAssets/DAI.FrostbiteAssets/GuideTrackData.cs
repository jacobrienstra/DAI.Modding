namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GuideTrackData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public int GuideTrackPriority { get; set; }
	}
}
