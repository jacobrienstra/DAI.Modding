using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CraftingMaterialCategoryStats : LinkObject
	{
		[FieldOffset(0, 0)]
		public EquipItemCraftingCategory Category { get; set; }

		[FieldOffset(4, 4)]
		public UpgradeItemCraftingCategory UpgradeCategory { get; set; }

		[FieldOffset(8, 8)]
		public List<CraftingMaterialStats> Stats { get; set; }

		public CraftingMaterialCategoryStats()
		{
			Stats = new List<CraftingMaterialStats>();
		}
	}
}
