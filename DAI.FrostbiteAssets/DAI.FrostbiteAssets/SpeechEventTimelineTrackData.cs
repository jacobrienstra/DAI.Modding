using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpeechEventTimelineTrackData : LinkTrackData
	{
		[FieldOffset(32, 144)]
		public List<SpeechEventKeyframe> Keyframes { get; set; }

		public SpeechEventTimelineTrackData()
		{
			Keyframes = new List<SpeechEventKeyframe>();
		}
	}
}
