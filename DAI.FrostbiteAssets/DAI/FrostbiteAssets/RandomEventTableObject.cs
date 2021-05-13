using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomEventTableObject : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<RandomEventItem>> RandomEventItems { get; set; }

		public RandomEventTableObject()
		{
			RandomEventItems = new List<ExternalObject<RandomEventItem>>();
		}
	}
}
