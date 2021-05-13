using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LootDropObject : Asset
	{
		[FieldOffset(12, 72)]
		public int Level { get; set; }

		[FieldOffset(16, 76)]
		public LootGoldProbability GoldProbability { get; set; }

		[FieldOffset(20, 80)]
		public int GoldQuantity { get; set; }

		[FieldOffset(24, 88)]
		public List<ExternalObject<LootDropItem>> DroppedItems { get; set; }

		public LootDropObject()
		{
			DroppedItems = new List<ExternalObject<LootDropItem>>();
		}
	}
}
