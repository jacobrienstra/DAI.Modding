namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTimelineBase : BWActionListContainer
	{
		[FieldOffset(16, 96)]
		public uint TimelineHash { get; set; }
	}
}
