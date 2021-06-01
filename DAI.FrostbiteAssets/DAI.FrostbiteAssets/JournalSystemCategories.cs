using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JournalSystemCategories : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<JournalSystemCategory>> Categories { get; set; }

		public JournalSystemCategories()
		{
			Categories = new List<ExternalObject<JournalSystemCategory>>();
		}
	}
}
