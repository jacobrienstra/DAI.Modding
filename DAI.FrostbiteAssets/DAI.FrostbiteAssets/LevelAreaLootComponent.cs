namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LevelAreaLootComponent : SubWorldDataComponent
	{
		[FieldOffset(8, 24)]
		public ExternalObject<LootTableData> Tier1LootTable { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<LootTableData> Tier2LootTable { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<LootTableData> Tier3LootTable { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<LootTableData> Tier4LootTable { get; set; }
	}
}
