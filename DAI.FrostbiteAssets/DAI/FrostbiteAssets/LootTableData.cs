using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootTableData : DataContainer
	{
		[FieldOffset(8, 24)]
		public LootItemProbability ItemProbability { get; set; }

		[FieldOffset(12, 28)]
		public LootGoldProbability GoldProbability { get; set; }

		[FieldOffset(16, 32)]
		public int GoldQuantity { get; set; }

		[FieldOffset(20, 36)]
		public int RequiredItemDrop { get; set; }

		[FieldOffset(24, 40)]
		public int ExtraRolls { get; set; }

		[FieldOffset(28, 48)]
		public ExternalObject<LootTableObject> LootTable { get; set; }

		[FieldOffset(32, 56)]
		public bool OverrideGoldQuantities { get; set; }
	}
}
