using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyReactionTimeline : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<BWTimeline> Timeline { get; set; }

		[FieldOffset(32, 80)]
		public List<BWTimelineTagRef> AddTags { get; set; }

		[FieldOffset(36, 88)]
		public BWCSM_ReactionType ReactionType { get; set; }

		public BWCSMAction_ApplyReactionTimeline()
		{
			AddTags = new List<BWTimelineTagRef>();
		}
	}
}
