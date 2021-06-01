using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatCategoriesBaseTree : TreeBase
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<StatsCategoryData>> RootBaseCategories { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<Dummy>> ParamX { get; set; }

		[FieldOffset(20, 88)]
		public List<ExternalObject<Dummy>> ParamY { get; set; }

		[FieldOffset(24, 96)]
		public bool ProcessAllLevelsInTree { get; set; }

		public StatCategoriesBaseTree()
		{
			RootBaseCategories = new List<ExternalObject<StatsCategoryData>>();
			ParamX = new List<ExternalObject<Dummy>>();
			ParamY = new List<ExternalObject<Dummy>>();
		}
	}
}
