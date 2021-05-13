using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionHaveAbility : BWConditional
	{
		[FieldOffset(8, 32)]
		public Guid AbilityGuid { get; set; }
	}
}
