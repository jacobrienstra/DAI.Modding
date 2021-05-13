using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TimelineTrackData : GameObjectData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<EntityData>> Conditions { get; set; }

		[FieldOffset(20, 104)]
		public bool ExposePins { get; set; }

		[FieldOffset(21, 105)]
		public bool IsDisabled { get; set; }

		[FieldOffset(22, 106)]
		public bool DependsOnAnimation { get; set; }

		public TimelineTrackData()
		{
			Conditions = new List<ExternalObject<EntityData>>();
		}
	}
}
