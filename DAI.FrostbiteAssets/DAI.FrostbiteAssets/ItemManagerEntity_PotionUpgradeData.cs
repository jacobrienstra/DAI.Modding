using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemManagerEntity_PotionUpgradeData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWAbilityUpgrade> PotionUpgrade { get; set; }

		[FieldOffset(4, 8)]
		public List<PotionHerbCost> HerbCosts { get; set; }

		public ItemManagerEntity_PotionUpgradeData()
		{
			HerbCosts = new List<PotionHerbCost>();
		}
	}
}
