using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ModifyAbilityCooldownTimer : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public BWAbilityTagRef AbilityTag { get; set; }

		[FieldOffset(32, 88)]
		public BWAbilityCooldownModifierType ModifierType { get; set; }

		[FieldOffset(36, 96)]
		public Delegate_float AbilityCooldownModifierValue { get; set; }

		[FieldOffset(48, 120)]
		public bool ModifyCurrentAbility { get; set; }

		[FieldOffset(49, 121)]
		public bool ModifyInstance { get; set; }

		[FieldOffset(50, 122)]
		public bool AllowZeroStart { get; set; }

		[FieldOffset(51, 123)]
		public bool RemoveOnEnd { get; set; }

		[FieldOffset(52, 124)]
		public bool ApplyAtEnd { get; set; }

		[FieldOffset(32, 88)]
		public List<BWAbilityTagRef> ExcludeTags { get; set; }

		public BWCSMAction_ModifyAbilityCooldownTimer()
		{
			ExcludeTags = new List<BWAbilityTagRef>();
		}
	}
}
