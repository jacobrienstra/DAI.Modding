using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ObjectVariationMultiSwitchEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<GameObjectData>> Variations { get; set; }

		[FieldOffset(20, 104)]
		public int CurrentIndex { get; set; }

		[FieldOffset(24, 108)]
		public bool SetOnInit { get; set; }

		public ObjectVariationMultiSwitchEntityData()
		{
			Variations = new List<ExternalObject<GameObjectData>>();
		}
	}
}
