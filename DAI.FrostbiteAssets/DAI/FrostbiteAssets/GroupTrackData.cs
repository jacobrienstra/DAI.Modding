namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GroupTrackData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public ExternalObject<GroupTrackRootData> RootData { get; set; }
	}
}
