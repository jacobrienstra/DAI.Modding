namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTimelineAliasMapEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWTimelineAlias> TimelineAlias { get; set; }

		[FieldOffset(4, 8)]
		public BWTimelineReference TimelineRef { get; set; }
	}
}
