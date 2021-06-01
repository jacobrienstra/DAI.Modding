using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityTrackBaseData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public List<ExternalObject<GameObjectData>> Children { get; set; }

		[FieldOffset(28, 136)]
		public EntityTrackSharingPolicy EntitySharingPolicy { get; set; }

		[FieldOffset(32, 140)]
		public bool InheritedToChildConversationLines { get; set; }

		[FieldOffset(33, 141)]
		public bool Required { get; set; }

		public EntityTrackBaseData()
		{
			Children = new List<ExternalObject<GameObjectData>>();
		}
	}
}
