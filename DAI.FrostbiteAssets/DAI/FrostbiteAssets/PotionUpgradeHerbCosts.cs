using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PotionUpgradeHerbCosts : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWAbilityUpgrade> PotionUpgrade { get; set; }

		[FieldOffset(4, 8)]
		public List<PotionHerbCost> HerbCosts { get; set; }

		public PotionUpgradeHerbCosts()
		{
			HerbCosts = new List<PotionHerbCost>();
		}
	}
}
