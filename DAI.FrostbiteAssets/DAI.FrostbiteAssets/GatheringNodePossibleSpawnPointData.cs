using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class GatheringNodePossibleSpawnPointData : AlternateSpawnEntityData
	{
		[FieldOffset(96, 192)]
		public ExternalObject<SpatialPrefabBlueprint> GatheringNodePrefab { get; set; }

		[FieldOffset(100, 200)]
		public Guid GatheringNodeId { get; set; }
	}
}
