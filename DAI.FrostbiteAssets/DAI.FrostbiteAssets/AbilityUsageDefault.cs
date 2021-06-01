using System;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AbilityUsageDefault : LinkObject
	{
		[FieldOffset(0, 0)]
		public Guid AbilityGuid { get; set; }

		[FieldOffset(16, 16)]
		public AbilityUsageSetting DefaultSetting { get; set; }
	}
}
