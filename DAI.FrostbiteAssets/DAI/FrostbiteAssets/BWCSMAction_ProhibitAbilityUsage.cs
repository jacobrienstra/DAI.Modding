using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ProhibitAbilityUsage : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public List<Dummy> Exceptions { get; set; }

		public BWCSMAction_ProhibitAbilityUsage()
		{
			Exceptions = new List<Dummy>();
		}
	}
}
