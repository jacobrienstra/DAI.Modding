using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityUpgradeTreeItem : BWAbilityTreeItemBase
	{
		[FieldOffset(24, 40)]
		public ExternalObject<BWAbilityUpgrade> Ability { get; set; }

		[FieldOffset(28, 48)]
		public AbilityUpgradePosition UpgradePosition { get; set; }

		[FieldOffset(32, 56)]
		public ExternalObject<CSMConditionHaveAbility> VisibilityCondition { get; set; }

		[FieldOffset(36, 64)]
		public List<BWAbilityUpgradeTreeItemAlternate> Alternates { get; set; }

		[FieldOffset(40, 72)]
		public ExternalObject<BWActivatedAbility> BaseAbility { get; set; }

		public BWAbilityUpgradeTreeItem()
		{
			Alternates = new List<BWAbilityUpgradeTreeItemAlternate>();
		}
	}
}
