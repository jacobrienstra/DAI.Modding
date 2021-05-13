using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMapAbilitiesEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public List<BWMapAbilitiesEntityMapping> Mappings { get; set; }

		[FieldOffset(24, 112)]
		public ExternalObject<FloatProvider_AbilityAutoLevelPriority> MapFreeSlotsPriority { get; set; }

		[FieldOffset(28, 120)]
		public bool RemoveDuplicateMappings { get; set; }

		[FieldOffset(29, 121)]
		public bool MapFreeSlots { get; set; }

		public BWMapAbilitiesEntityData()
		{
			Mappings = new List<BWMapAbilitiesEntityMapping>();
		}
	}
}
