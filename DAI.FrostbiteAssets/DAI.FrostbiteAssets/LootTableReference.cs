namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootTableReference : DataContainer
	{
		[FieldOffset(8, 24)]
		public float Weight { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<LootTableObject> LootTable { get; set; }

		[FieldOffset(16, 40)]
		public float WeightMultiplier { get; set; }
	}
}
