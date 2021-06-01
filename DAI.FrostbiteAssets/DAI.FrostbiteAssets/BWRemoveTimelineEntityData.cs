using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWRemoveTimelineEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 108)]
		public int PartyMemberID { get; set; }

		[FieldOffset(28, 112)]
		public List<BWTimelineReference> Timelines { get; set; }

		[FieldOffset(32, 120)]
		public List<BWTimelineTagRef> Tags { get; set; }

		[FieldOffset(36, 128)]
		public bool RemoveTimelinesFromTriggeringCharacter { get; set; }

		public BWRemoveTimelineEntityData()
		{
			Timelines = new List<BWTimelineReference>();
			Tags = new List<BWTimelineTagRef>();
		}
	}
}
