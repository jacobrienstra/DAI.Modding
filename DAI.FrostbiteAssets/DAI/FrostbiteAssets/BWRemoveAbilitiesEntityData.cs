using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWRemoveAbilitiesEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public List<ExternalObject<DataContainer>> Abilities { get; set; }

		public BWRemoveAbilitiesEntityData()
		{
			Abilities = new List<ExternalObject<DataContainer>>();
		}
	}
}
