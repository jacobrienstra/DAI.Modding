using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIStoreItemTypeSlotMap : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<ExternalObject<WidgetNode>> ItemTypes { get; set; }

		[FieldOffset(4, 8)]
		public EquipSlot FirstSlot { get; set; }

		[FieldOffset(8, 12)]
		public EquipSlot SecondSlot { get; set; }

		public UIStoreItemTypeSlotMap()
		{
			ItemTypes = new List<ExternalObject<WidgetNode>>();
		}
	}
}
