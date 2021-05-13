using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AwardDataTree : AwardableTreeBase
	{
		[FieldOffset(24, 144)]
		public List<ExternalObject<AwardAchievementData>> FilteredAwards { get; set; }

		public AwardDataTree()
		{
			FilteredAwards = new List<ExternalObject<AwardAchievementData>>();
		}
	}
}
