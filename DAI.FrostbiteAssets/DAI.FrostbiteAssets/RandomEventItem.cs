using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomEventItem : DataContainer
	{
		[FieldOffset(8, 24)]
		public float Probability { get; set; }

		[FieldOffset(12, 32)]
		public string ItemName { get; set; }

		[FieldOffset(16, 40)]
		public List<PlotConditionReference> SelectionConditions { get; set; }

		public RandomEventItem()
		{
			SelectionConditions = new List<PlotConditionReference>();
		}
	}
}
