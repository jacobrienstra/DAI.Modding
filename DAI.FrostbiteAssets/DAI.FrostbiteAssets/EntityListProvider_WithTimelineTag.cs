namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityListProvider_WithTimelineTag : CSMEntityListProvider
	{
		[FieldOffset(8, 32)]
		public BWTimelineTagRef Tag { get; set; }
	}
}
