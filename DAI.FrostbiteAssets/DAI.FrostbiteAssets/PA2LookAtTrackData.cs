using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PA2LookAtTrackData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public List<ExternalObject<GameObjectData>> Keyframes { get; set; }

		public PA2LookAtTrackData()
		{
			Keyframes = new List<ExternalObject<GameObjectData>>();
		}
	}
}
