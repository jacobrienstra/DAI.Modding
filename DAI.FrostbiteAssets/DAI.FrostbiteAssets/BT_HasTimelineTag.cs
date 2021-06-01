using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_HasTimelineTag : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(20, 48)]
		public List<BWTimelineTagRef> Tags { get; set; }

		public BT_HasTimelineTag()
		{
			Tags = new List<BWTimelineTagRef>();
		}
	}
}
