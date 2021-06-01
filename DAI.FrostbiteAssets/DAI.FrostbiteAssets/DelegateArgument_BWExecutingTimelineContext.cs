namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_BWExecutingTimelineContext : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public BWTimelineContext Value { get; set; }
	}
}
