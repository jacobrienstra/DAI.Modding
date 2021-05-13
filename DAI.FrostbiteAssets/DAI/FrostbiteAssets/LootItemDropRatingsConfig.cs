namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootItemDropRatingsConfig
	{
		[FieldOffset(0, 0)]
		public float LootItemProbability_None { get; set; }

		[FieldOffset(4, 4)]
		public float LootItemProbability_VeryLow { get; set; }

		[FieldOffset(8, 8)]
		public float LootItemProbability_Low { get; set; }

		[FieldOffset(12, 12)]
		public float LootItemProbability_Default { get; set; }

		[FieldOffset(16, 16)]
		public float LootItemProbability_High { get; set; }

		[FieldOffset(20, 20)]
		public float LootItemProbability_VeryHigh { get; set; }

		[FieldOffset(24, 24)]
		public float LootItemProbability_Always { get; set; }
	}
}
