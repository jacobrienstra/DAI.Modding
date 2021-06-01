using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Vec2PropertyTrackData : SimplePropertyTrackData
	{
		[FieldOffset(20, 56)]
		public List<Vec2> Values { get; set; }

		public Vec2PropertyTrackData()
		{
			Values = new List<Vec2>();
		}
	}
}
