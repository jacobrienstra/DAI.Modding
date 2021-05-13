using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatCategoriesTree : StatCategoriesBaseTree
	{
		[FieldOffset(28, 120)]
		public List<ExternalObject<StatsCategoryData>> Categories { get; set; }

		public StatCategoriesTree()
		{
			Categories = new List<ExternalObject<StatsCategoryData>>();
		}
	}
}
