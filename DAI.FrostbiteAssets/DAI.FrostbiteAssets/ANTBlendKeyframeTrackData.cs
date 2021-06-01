using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ANTBlendKeyframeTrackData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public List<ExternalObject<GameObjectData>> Keyframes { get; set; }

		public ANTBlendKeyframeTrackData()
		{
			Keyframes = new List<ExternalObject<GameObjectData>>();
		}
	}
}
