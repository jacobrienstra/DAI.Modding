using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatCategoryTreeCollection : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<StatCategoriesTree>> CategoryTrees { get; set; }

		public StatCategoryTreeCollection()
		{
			CategoryTrees = new List<ExternalObject<StatCategoriesTree>>();
		}
	}
}
