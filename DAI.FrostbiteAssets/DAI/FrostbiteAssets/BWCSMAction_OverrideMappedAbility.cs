using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_OverrideMappedAbility : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<BWActivatedAbility> OverrideAbility { get; set; }

		[FieldOffset(32, 80)]
		public Guid MappedAbilityGuid { get; set; }
	}
}
