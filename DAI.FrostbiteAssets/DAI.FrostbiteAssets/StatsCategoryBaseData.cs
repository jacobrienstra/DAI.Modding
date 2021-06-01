using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatsCategoryBaseData : TreeNodeBase
	{
		[FieldOffset(8, 32)]
		public List<ExternalObject<StatsCategoryData>> BaseSubCategories { get; set; }

		[FieldOffset(12, 40)]
		public string Code { get; set; }

		[FieldOffset(16, 48)]
		public string Name { get; set; }

		public StatsCategoryBaseData()
		{
			BaseSubCategories = new List<ExternalObject<StatsCategoryData>>();
		}
	}
}
