using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolTrackData : PropertyTrackBaseData
	{
		[FieldOffset(32, 144)]
		public List<BoolKeyframe> Keyframes { get; set; }

		public BoolTrackData()
		{
			Keyframes = new List<BoolKeyframe>();
		}
	}
}
