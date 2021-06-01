namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LootComponentData : BaseLootComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<SpatialPrefabBlueprint> LootPrefab { get; set; }

		[FieldOffset(100, 184)]
		public ExternalObject<LootData> Loot { get; set; }
	}
}
