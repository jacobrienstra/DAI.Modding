namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootConfiguration : DataContainer
	{
		[FieldOffset(8, 24)]
		public LootItemDropRatingsConfig LootDropRatings { get; set; }

		[FieldOffset(36, 52)]
		public LootGoldProbabilityConfig LootGoldDropRatings { get; set; }

		[FieldOffset(64, 80)]
		public Delegate_int LootGoldDropAmount { get; set; }

		[FieldOffset(76, 104)]
		public LootResourcesDropAmountsConfig LootResourcesDropAmounts { get; set; }

		[FieldOffset(100, 128)]
		public uint MaxDynamicLootContainers { get; set; }

		[FieldOffset(104, 136)]
		public LocalizedStringReference LootGoldNotificationString { get; set; }

		[FieldOffset(108, 160)]
		public LocalizedStringReference LootItemNotificationString { get; set; }

		[FieldOffset(112, 184)]
		public LocalizedStringReference LootSchematicNotificationString { get; set; }

		[FieldOffset(116, 208)]
		public LocalizedStringReference LootRecipeNotificationString { get; set; }

		[FieldOffset(120, 232)]
		public PlotFlagReference DisableLootInteraction { get; set; }

		[FieldOffset(136, 272)]
		public int SigilDLCPackage { get; set; }
	}
}
