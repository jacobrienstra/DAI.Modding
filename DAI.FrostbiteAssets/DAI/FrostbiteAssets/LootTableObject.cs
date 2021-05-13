using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootTableObject : Asset
	{
		[FieldOffset(12, 72)]
		public float ChanceOfNoItems { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<Dummy> DifficultyModePrerequisite { get; set; }

		[FieldOffset(20, 88)]
		public LootItemProbability ItemProbability { get; set; }

		[FieldOffset(24, 92)]
		public LootGoldProbability GoldProbability { get; set; }

		[FieldOffset(28, 96)]
		public int GoldQuantity { get; set; }

		[FieldOffset(32, 100)]
		public float TotalWeightFromItems { get; set; }

		[FieldOffset(36, 104)]
		public float TotalWeightFromReferencedTables { get; set; }

		[FieldOffset(40, 112)]
		public List<ExternalObject<LootTableReference>> ReferencedTables { get; set; }

		[FieldOffset(44, 120)]
		public List<ExternalObject<LootTableItem>> LootTableItems { get; set; }

		public LootTableObject()
		{
			ReferencedTables = new List<ExternalObject<LootTableReference>>();
			LootTableItems = new List<ExternalObject<LootTableItem>>();
		}
	}
}
