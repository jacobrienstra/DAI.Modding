using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3MPItemStat : LinkObject
	{
		[FieldOffset(0, 0)]
		public int StatId { get; set; }

		[FieldOffset(4, 4)]
		public float StatValue { get; set; }

		[FieldOffset(8, 8)]
		public List<Dummy> Progression { get; set; }

		public DA3MPItemStat()
		{
			Progression = new List<Dummy>();
		}
	}
}
