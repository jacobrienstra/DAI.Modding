using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Vec3PropertyTrackData : SimplePropertyTrackData
	{
		[FieldOffset(20, 56)]
		public List<Vec3> Values { get; set; }

		public Vec3PropertyTrackData()
		{
			Values = new List<Vec3>();
		}
	}
}
