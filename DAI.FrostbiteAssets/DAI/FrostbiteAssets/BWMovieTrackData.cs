using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMovieTrackData : GuideTrackData
	{
		[FieldOffset(28, 136)]
		public List<ExternalObject<ConversationMasterLinkEntityData>> Keyframes { get; set; }

		[FieldOffset(32, 144)]
		public bool DelayMovieEventToTimelineUpdate { get; set; }

		public BWMovieTrackData()
		{
			Keyframes = new List<ExternalObject<ConversationMasterLinkEntityData>>();
		}
	}
}
