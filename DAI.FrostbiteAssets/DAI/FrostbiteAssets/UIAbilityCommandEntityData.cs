using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIAbilityCommandEntityData : UICommandEntityData
	{
		[FieldOffset(16, 96)]
		public BWAbilityAlias AbilityAlias { get; set; }

		[FieldOffset(20, 100)]
		public Guid AbilityGuid { get; set; }
	}
}
