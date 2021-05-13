using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LayeredTransformTrackData : PropertyTrackBaseData
	{
		[FieldOffset(32, 144)]
		public List<ExternalObject<GameObjectData>> LayerTracks { get; set; }

		[FieldOffset(36, 152)]
		public int TimelineOriginPinId { get; set; }

		public LayeredTransformTrackData()
		{
			LayerTracks = new List<ExternalObject<GameObjectData>>();
		}
	}
}
