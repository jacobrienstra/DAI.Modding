using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchStatsConfiguration : SystemSettings
	{
		[FieldOffset(16, 40)]
		public List<MatchStatCategory> MatchStatCategories { get; set; }

		public MatchStatsConfiguration()
		{
			MatchStatCategories = new List<MatchStatCategory>();
		}
	}
}
