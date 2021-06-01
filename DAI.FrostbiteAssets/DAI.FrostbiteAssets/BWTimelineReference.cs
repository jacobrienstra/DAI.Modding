namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTimelineReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWTimelineBase> Timeline { get; set; }
	}
}
