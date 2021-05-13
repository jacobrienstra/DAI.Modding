using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_HasTimeline : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(20, 48)]
		public List<BWTimelineReference> Timelines { get; set; }

		public BT_HasTimeline()
		{
			Timelines = new List<BWTimelineReference>();
		}
	}
}
