using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BlueprintBundleCollectionEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public StreamRealm StreamRealm { get; set; }

		[FieldOffset(20, 104)]
		public List<uint> BlueprintBundleHashes { get; set; }

		[FieldOffset(24, 112)]
		public int ActiveIndex { get; set; }

		public BlueprintBundleCollectionEntityData()
		{
			BlueprintBundleHashes = new List<uint>();
		}
	}
}
