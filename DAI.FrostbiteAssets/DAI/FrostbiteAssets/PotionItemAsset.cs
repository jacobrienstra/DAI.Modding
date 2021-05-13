using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PotionItemAsset : StackedItemAsset
	{
		[FieldOffset(104, 304)]
		public ExternalObject<TextureAsset> CardImage { get; set; }

		[FieldOffset(108, 312)]
		public ExternalObject<BWActivatedAbility> PotionAbility { get; set; }

		[FieldOffset(112, 320)]
		public ExternalObject<BWModifiableStat> PotionMaxStackSizeStat { get; set; }

		[FieldOffset(116, 328)]
		public PlotFlagReference PotionMaxStackSizeFlag { get; set; }

		[FieldOffset(132, 368)]
		public List<PotionHerbCost> BaseHerbCosts { get; set; }

		[FieldOffset(136, 376)]
		public List<PotionUpgradeHerbCosts> UpgradeHerbCosts { get; set; }

		[FieldOffset(140, 384)]
		public int MPID { get; set; }

		[FieldOffset(144, 392)]
		public List<PartyMemberClassType> RequirementClasses { get; set; }

		[FieldOffset(148, 400)]
		public bool IsShared { get; set; }

		[FieldOffset(149, 401)]
		public bool IsMappable { get; set; }

		public PotionItemAsset()
		{
			BaseHerbCosts = new List<PotionHerbCost>();
			UpgradeHerbCosts = new List<PotionUpgradeHerbCosts>();
			RequirementClasses = new List<PartyMemberClassType>();
		}
	}
}
