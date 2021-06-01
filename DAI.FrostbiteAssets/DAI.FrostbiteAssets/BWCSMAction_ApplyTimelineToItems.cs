using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyTimelineToItems : BWCSMAction_ApplyTimeline
	{
		[FieldOffset(44, 104)]
		public List<EquipSlot> Slots { get; set; }

		public BWCSMAction_ApplyTimelineToItems()
		{
			Slots = new List<EquipSlot>();
		}
	}
}
