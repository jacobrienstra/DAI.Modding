using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityTreeItem : BWAbilityTreeItemBase
	{
		[FieldOffset(24, 40)]
		public ExternalObject<BWAbility> Ability { get; set; }

		[FieldOffset(28, 48)]
		public List<ExternalObject<BWAbilityTreeItem>> Upgrades { get; set; }

		[FieldOffset(32, 56)]
		public float AbilityTreeX { get; set; }

		[FieldOffset(36, 60)]
		public float AbilityTreeY { get; set; }

		[FieldOffset(40, 64)]
		public List<ExternalObject<BWAbilityTreeItem>> PrerequisiteAbilities { get; set; }

		[FieldOffset(44, 72)]
		public AbilityPrereqConditionType PrereqCondition { get; set; }

		[FieldOffset(48, 80)]
		public List<ExternalObject<BWAbilityTreeItem>> VisibilityPrereqAbilities { get; set; }

		[FieldOffset(52, 88)]
		public AbilityPrereqConditionType VisibilityPrereqCondition { get; set; }

		public BWAbilityTreeItem()
		{
			Upgrades = new List<ExternalObject<BWAbilityTreeItem>>();
			PrerequisiteAbilities = new List<ExternalObject<BWAbilityTreeItem>>();
			VisibilityPrereqAbilities = new List<ExternalObject<BWAbilityTreeItem>>();
		}
	}
}
