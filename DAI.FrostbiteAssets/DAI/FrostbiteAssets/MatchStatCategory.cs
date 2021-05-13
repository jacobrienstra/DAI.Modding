using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchStatCategory : LinkObject
	{
		[FieldOffset(0, 0)]
		public string CategoryName { get; set; }

		[FieldOffset(4, 8)]
		public List<MatchStatItem> MatchStatItems { get; set; }

		public MatchStatCategory()
		{
			MatchStatItems = new List<MatchStatItem>();
		}
	}
}
