using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceFXTimelineTrackData : LinkTrackData
	{
		[FieldOffset(32, 144)]
		public List<ExternalObject<GameObjectData>> Keyframes { get; set; }

		public FaceFXTimelineTrackData()
		{
			Keyframes = new List<ExternalObject<GameObjectData>>();
		}
	}
}
