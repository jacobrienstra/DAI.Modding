using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatPropertyTrackData : SimplePropertyTrackData
	{
		[FieldOffset(20, 56)]
		public List<float> Values { get; set; }

		public FloatPropertyTrackData()
		{
			Values = new List<float>();
		}
	}
}
