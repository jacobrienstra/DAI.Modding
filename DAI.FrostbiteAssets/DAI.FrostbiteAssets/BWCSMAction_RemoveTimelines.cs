namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_RemoveTimelines : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public BWTimelineTagRef Tag { get; set; }

		[FieldOffset(32, 88)]
		public uint TimelineHash { get; set; }

		[FieldOffset(36, 92)]
		public bool OwnerTimeline { get; set; }

		[FieldOffset(37, 93)]
		public bool RemoveAtEnd { get; set; }
	}
}
