using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBWInventorySimpleChooserEquipType : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<ExternalObject<WidgetNode>> ItemTypes { get; set; }

		[FieldOffset(4, 8)]
		public Vec2 Position { get; set; }

		[FieldOffset(12, 16)]
		public EquipSlot FirstSlot { get; set; }

		[FieldOffset(16, 20)]
		public EquipSlot SecondSlot { get; set; }

		public UIBWInventorySimpleChooserEquipType()
		{
			ItemTypes = new List<ExternalObject<WidgetNode>>();
		}
	}
}
