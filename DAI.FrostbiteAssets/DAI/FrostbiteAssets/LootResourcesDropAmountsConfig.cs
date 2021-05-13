namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootResourcesDropAmountsConfig
	{
		[FieldOffset(0, 0)]
		public int PowerResourceQuantity_None { get; set; }

		[FieldOffset(4, 4)]
		public int PowerResourceQuantity_VeryLow { get; set; }

		[FieldOffset(8, 8)]
		public int PowerResourceQuantity_Low { get; set; }

		[FieldOffset(12, 12)]
		public int PowerResourceQuantity_Medium { get; set; }

		[FieldOffset(16, 16)]
		public int PowerResourceQuantity_High { get; set; }

		[FieldOffset(20, 20)]
		public int PowerResourceQuantity_VeryHigh { get; set; }
	}
}
