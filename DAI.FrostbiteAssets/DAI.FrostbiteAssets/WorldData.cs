using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WorldData : SubWorldData
	{
		[FieldOffset(64, 344)]
		public List<ExternalObject<GameObjectData>> Components { get; set; }

		public WorldData()
		{
			Components = new List<ExternalObject<GameObjectData>>();
		}
	}
}
