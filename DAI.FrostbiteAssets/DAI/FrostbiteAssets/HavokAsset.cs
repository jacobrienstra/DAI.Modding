using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class HavokAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<int> NumShapeKeysInContactPointProperties { get; set; }

		[FieldOffset(16, 80)]
		public long Resource { get; set; }

		[FieldOffset(24, 88)]
		public List<ExternalObject<EntityData>> ExternalAssets { get; set; }

		public HavokAsset()
		{
			NumShapeKeysInContactPointProperties = new List<int>();
			ExternalAssets = new List<ExternalObject<EntityData>>();
		}
	}
}
