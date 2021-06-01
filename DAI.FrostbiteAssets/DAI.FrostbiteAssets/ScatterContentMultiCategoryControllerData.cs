using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentMultiCategoryControllerData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<int> Categories { get; set; }

		public ScatterContentMultiCategoryControllerData()
		{
			Categories = new List<int>();
		}
	}
}
