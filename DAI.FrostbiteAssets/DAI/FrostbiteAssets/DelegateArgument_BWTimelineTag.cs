namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_BWTimelineTag : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public BWTimelineTagRef Value { get; set; }
	}
}
