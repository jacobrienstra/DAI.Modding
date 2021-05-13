using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWUnlockAbilityTreesEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public List<ExternalObject<DataContainer>> AbilityTrees { get; set; }

		[FieldOffset(24, 112)]
		public bool Unlocked { get; set; }

		public BWUnlockAbilityTreesEntityData()
		{
			AbilityTrees = new List<ExternalObject<DataContainer>>();
		}
	}
}
