using System;
using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProhibitAbilityUsageEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public List<Guid> Exceptions { get; set; }

		public ProhibitAbilityUsageEntityData()
		{
			Exceptions = new List<Guid>();
		}
	}
}
