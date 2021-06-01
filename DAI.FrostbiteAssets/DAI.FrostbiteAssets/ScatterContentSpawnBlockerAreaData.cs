using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentSpawnBlockerAreaData : EntityData
	{
		[FieldOffset(16, 96)]
		public float DisableRadius { get; set; }

		[FieldOffset(20, 104)]
		public List<int> Categories { get; set; }

		[FieldOffset(24, 112)]
		public bool Enabled { get; set; }

		[FieldOffset(25, 113)]
		public bool BlockAllCategoriesExceptListed { get; set; }

		public ScatterContentSpawnBlockerAreaData()
		{
			Categories = new List<int>();
		}
	}
}
