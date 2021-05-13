using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMBranchToAbility : BWCSMBranch
	{
		[FieldOffset(80, 168)]
		public List<BWAbilityTagRef> ExcludeTags { get; set; }

		[FieldOffset(84, 176)]
		public List<BWAbilityTagRef> IncludeTags { get; set; }

		[FieldOffset(88, 184)]
		public bool AllowSameAbility { get; set; }

		public BWCSMBranchToAbility()
		{
			ExcludeTags = new List<BWAbilityTagRef>();
			IncludeTags = new List<BWAbilityTagRef>();
		}
	}
}
