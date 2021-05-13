using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class StageEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public List<ExternalObject<GameObjectData>> Marks { get; set; }

		[FieldOffset(84, 184)]
		public List<ExternalObject<GameObjectData>> Cameras { get; set; }

		[FieldOffset(88, 192)]
		public bool IsGlobal { get; set; }

		public StageEntityData()
		{
			Marks = new List<ExternalObject<GameObjectData>>();
			Cameras = new List<ExternalObject<GameObjectData>>();
		}
	}
}
