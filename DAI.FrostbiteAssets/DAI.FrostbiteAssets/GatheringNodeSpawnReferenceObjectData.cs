using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class GatheringNodeSpawnReferenceObjectData : BWBlueprintSpawnReferenceObjectData
	{
		[FieldOffset(144, 288)]
		public Guid GatheringNodeId { get; set; }

		[FieldOffset(160, 304)]
		public int NumAlternateSpawnPoints { get; set; }

		[FieldOffset(164, 308)]
		public uint BundleHash { get; set; }

		[FieldOffset(168, 312)]
		public ScatterContentSettings ScatterContentSettings { get; set; }

		[FieldOffset(180, 336)]
		public float NodeSpawnChance { get; set; }
	}
}
