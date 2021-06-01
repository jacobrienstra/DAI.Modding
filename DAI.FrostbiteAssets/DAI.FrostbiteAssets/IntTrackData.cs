using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IntTrackData : PropertyTrackBaseData
	{
		[FieldOffset(32, 144)]
		public List<IntKeyframe> Keyframes { get; set; }

		public IntTrackData()
		{
			Keyframes = new List<IntKeyframe>();
		}
	}
}
