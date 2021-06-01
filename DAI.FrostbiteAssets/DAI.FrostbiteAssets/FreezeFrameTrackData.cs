using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FreezeFrameTrackData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public List<FreezeFrameKeyframe> Keyframes { get; set; }

		public FreezeFrameTrackData()
		{
			Keyframes = new List<FreezeFrameKeyframe>();
		}
	}
}
