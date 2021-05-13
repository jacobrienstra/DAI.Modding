using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WaypointsShapeData : VectorShapeData
	{
		[FieldOffset(28, 112)]
		public List<ExternalObject<GameObjectData>> Waypoints { get; set; }

		public WaypointsShapeData()
		{
			Waypoints = new List<ExternalObject<GameObjectData>>();
		}
	}
}
