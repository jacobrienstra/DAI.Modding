using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentLogicalSurrogateData : EntityData
	{
		[FieldOffset(16, 96)]
		public int SurrogateCount { get; set; }

		[FieldOffset(20, 100)]
		public int SurrogateVarietyCount { get; set; }

		[FieldOffset(24, 104)]
		public List<int> Categories { get; set; }

		public ScatterContentLogicalSurrogateData()
		{
			Categories = new List<int>();
		}
	}
}
