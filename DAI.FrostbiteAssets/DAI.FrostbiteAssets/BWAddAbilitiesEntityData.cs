using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAddAbilitiesEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public List<ExternalObject<DataContainer>> Abilities { get; set; }

		[FieldOffset(24, 112)]
		public AbilityAutoMapping Mapping { get; set; }

		[FieldOffset(28, 116)]
		public bool ConsumeAbilityPoints { get; set; }

		public BWAddAbilitiesEntityData()
		{
			Abilities = new List<ExternalObject<DataContainer>>();
		}
	}
}
