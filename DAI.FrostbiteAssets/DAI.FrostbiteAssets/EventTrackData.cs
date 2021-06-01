using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EventTrackData : SchematicPinTrackData
	{
		[FieldOffset(32, 144)]
		public List<EventKeyframe> Keyframes { get; set; }

		[FieldOffset(36, 152)]
		public int AntiEventId { get; set; }

		[FieldOffset(40, 156)]
		public bool FireEventsUponSkip { get; set; }

		[FieldOffset(41, 157)]
		public bool UpdatePropertiesAtEvents { get; set; }

		public EventTrackData()
		{
			Keyframes = new List<EventKeyframe>();
		}
	}
}
