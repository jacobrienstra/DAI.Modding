using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPDataManagerData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<DA3MPItem> DA3MPItems { get; set; }

		[FieldOffset(20, 104)]
		public List<DA3MPItem> DA3MPRecipes { get; set; }

		[FieldOffset(24, 112)]
		public int DataVersion { get; set; }

		public MPDataManagerData()
		{
			DA3MPItems = new List<DA3MPItem>();
			DA3MPRecipes = new List<DA3MPItem>();
		}
	}
}
