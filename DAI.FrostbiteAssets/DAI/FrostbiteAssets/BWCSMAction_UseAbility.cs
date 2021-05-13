using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_UseAbility : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public Guid AbilityGuid { get; set; }
	}
}
