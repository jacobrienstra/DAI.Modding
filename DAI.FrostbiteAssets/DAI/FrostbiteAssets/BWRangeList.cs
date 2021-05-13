using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWRangeList : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<BWRange>> Ranges { get; set; }

		public BWRangeList()
		{
			Ranges = new List<ExternalObject<BWRange>>();
		}
	}
}
