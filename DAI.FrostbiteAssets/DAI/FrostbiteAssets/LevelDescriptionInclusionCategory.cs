using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LevelDescriptionInclusionCategory : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Category { get; set; }

		[FieldOffset(4, 8)]
		public List<Dummy> Mode { get; set; }

		public LevelDescriptionInclusionCategory()
		{
			Mode = new List<Dummy>();
		}
	}
}
