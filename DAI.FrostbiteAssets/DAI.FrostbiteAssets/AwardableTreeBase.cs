using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AwardableTreeBase : TreeBase
	{
		[FieldOffset(12, 72)]
		public ExternalObject<StatCategoryTreeCollection> StatCategoryTreeCollection { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<Dummy>> GeneralCriteria { get; set; }

		[FieldOffset(20, 88)]
		public bool GeneralStatistics { get; set; }

		public AwardableTreeBase()
		{
			GeneralCriteria = new List<ExternalObject<Dummy>>();
		}
	}
}
