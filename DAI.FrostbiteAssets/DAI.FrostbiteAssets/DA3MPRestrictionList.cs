using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3MPRestrictionList : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<DA3MPItemProperty> Restrictions { get; set; }

		public DA3MPRestrictionList()
		{
			Restrictions = new List<DA3MPItemProperty>();
		}
	}
}
