namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWExecutingTimelineData : EntityData
	{
		[FieldOffset(16, 96)]
		public BWTimelineReference TimelineRef { get; set; }
	}
}
