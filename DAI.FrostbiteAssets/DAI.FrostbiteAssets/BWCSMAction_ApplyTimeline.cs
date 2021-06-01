using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyTimeline : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<BWTimelineBase> Timeline { get; set; }

		[FieldOffset(32, 80)]
		public List<BWTimelineTagRef> AddTags { get; set; }

		[FieldOffset(36, 88)]
		public ExternalObject<EntityListProvider> Entity { get; set; }

		[FieldOffset(40, 96)]
		public bool ApplyAtEnd { get; set; }

		[FieldOffset(41, 97)]
		public bool FireAndForget { get; set; }

		public BWCSMAction_ApplyTimeline()
		{
			AddTags = new List<BWTimelineTagRef>();
		}
	}
}
