using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DefensiveCollisionList : Asset
	{
		[FieldOffset(12, 72)]
		public List<DefensiveCollisionDefinition> DefensiveCollisionDefinitions { get; set; }

		public DefensiveCollisionList()
		{
			DefensiveCollisionDefinitions = new List<DefensiveCollisionDefinition>();
		}
	}
}
