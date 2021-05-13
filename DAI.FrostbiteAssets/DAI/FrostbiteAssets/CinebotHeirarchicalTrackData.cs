using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotHeirarchicalTrackData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public List<ExternalObject<BWAreaTriggerEntityData>> Children { get; set; }

		public CinebotHeirarchicalTrackData()
		{
			Children = new List<ExternalObject<BWAreaTriggerEntityData>>();
		}
	}
}
