using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TimelineData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public List<ExternalObject<GameObjectData>> Children { get; set; }

		public TimelineData()
		{
			Children = new List<ExternalObject<GameObjectData>>();
		}
	}
}
