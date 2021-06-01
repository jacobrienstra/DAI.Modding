using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatsCategoryData : StatsCategoryBaseData
	{
		[FieldOffset(20, 72)]
		public List<ExternalObject<StatsCategoryData>> Categories { get; set; }

		[FieldOffset(24, 80)]
		public List<string> Members { get; set; }

		public StatsCategoryData()
		{
			Categories = new List<ExternalObject<StatsCategoryData>>();
			Members = new List<string>();
		}
	}
}
