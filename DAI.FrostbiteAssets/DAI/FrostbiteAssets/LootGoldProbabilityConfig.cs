namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootGoldProbabilityConfig
	{
		[FieldOffset(0, 0)]
		public float LootGoldProbability_None { get; set; }

		[FieldOffset(4, 4)]
		public float LootGoldProbability_VeryLow { get; set; }

		[FieldOffset(8, 8)]
		public float LootGoldProbability_Low { get; set; }

		[FieldOffset(12, 12)]
		public float LootGoldProbability_Medium { get; set; }

		[FieldOffset(16, 16)]
		public float LootGoldProbability_High { get; set; }

		[FieldOffset(20, 20)]
		public float LootGoldProbability_VeryHigh { get; set; }

		[FieldOffset(24, 24)]
		public float LootGoldProbability_Always { get; set; }
	}
}
