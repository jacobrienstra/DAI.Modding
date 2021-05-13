using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotTransitionMapData : CinebotInterruptibleTransitionData
	{
		[FieldOffset(40, 64)]
		public List<ExternalObject<GameObjectData>> From { get; set; }

		[FieldOffset(44, 72)]
		public List<ExternalObject<GameObjectData>> To { get; set; }

		public CinebotTransitionMapData()
		{
			From = new List<ExternalObject<GameObjectData>>();
			To = new List<ExternalObject<GameObjectData>>();
		}
	}
}
