using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Vec4PropertyTrackData : SimplePropertyTrackData
	{
		[FieldOffset(20, 56)]
		public List<Vec4> Values { get; set; }

		public Vec4PropertyTrackData()
		{
			Values = new List<Vec4>();
		}
	}
}
