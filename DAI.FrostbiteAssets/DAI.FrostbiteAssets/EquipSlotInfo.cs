using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EquipSlotInfo : Asset
	{
		[FieldOffset(12, 72)]
		public List<EquipSlot> ValidSlots { get; set; }

		[FieldOffset(16, 80)]
		public bool IsMultiSlot { get; set; }

		public EquipSlotInfo()
		{
			ValidSlots = new List<EquipSlot>();
		}
	}
}
