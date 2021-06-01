using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ConversationTimelineEntityData : TimelineEntityData
	{
		[FieldOffset(76, 176)]
		public AdvanceCondition AdvanceCondition { get; set; }

		[FieldOffset(80, 192)]
		public Vec3 StreamingPositionOverride { get; set; }

		[FieldOffset(96, 208)]
		public ExternalObject<ConversationCharacterProxyObjectTrackData> SpeakerTrack { get; set; }

		[FieldOffset(100, 216)]
		public ExternalObject<ConversationCharacterProxyObjectTrackData> ListenerTrack { get; set; }

		[FieldOffset(104, 224)]
		public List<ExternalObject<ConversationMasterLinkEntityData>> TracksNeedingAdjustedStop { get; set; }

		public ConversationTimelineEntityData()
		{
			TracksNeedingAdjustedStop = new List<ExternalObject<ConversationMasterLinkEntityData>>();
		}
	}
}
