using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWApplyTimelineEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 108)]
		public int PartyMemberID { get; set; }

		[FieldOffset(28, 112)]
		public List<BWTimelineReference> Timelines { get; set; }

		[FieldOffset(32, 128)]
		public LinearTransform TargetTransform { get; set; }

		[FieldOffset(96, 192)]
		public List<ExternalObject<DataContainer>> TimelinesToApply { get; set; }

		[FieldOffset(100, 200)]
		public List<BWTimelineTagRef> AdditionalTags { get; set; }

		[FieldOffset(104, 208)]
		public ExternalObject<Dummy> CasterInputList { get; set; }

		[FieldOffset(108, 216)]
		public ExternalObject<Dummy> PartnerInputList { get; set; }

		[FieldOffset(112, 224)]
		public bool ApplyTimelinesToTriggeringCharacter { get; set; }

		public BWApplyTimelineEntityData()
		{
			Timelines = new List<BWTimelineReference>();
			TimelinesToApply = new List<ExternalObject<DataContainer>>();
			AdditionalTags = new List<BWTimelineTagRef>();
		}
	}
}
