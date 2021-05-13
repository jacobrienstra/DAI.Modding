using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ANTSignalTrackData : LinkTrackData
	{
		[FieldOffset(32, 144)]
		public List<ExternalObject<GameObjectData>> SignalTracks { get; set; }

		public ANTSignalTrackData()
		{
			SignalTracks = new List<ExternalObject<GameObjectData>>();
		}
	}
}
