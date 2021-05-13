using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EquipItemType : BaseItemType
	{
		[FieldOffset(48, 160)]
		public ExternalObject<EquipSlotInfo> Slot { get; set; }

		[FieldOffset(52, 168)]
		public List<ExternalObject<ItemPartType>> PartTypes { get; set; }

		[FieldOffset(56, 176)]
		public EquipItemInvCategory InventoryCategory { get; set; }

		[FieldOffset(60, 180)]
		public EquipItemCraftingCategory CraftingCategory { get; set; }

		[FieldOffset(64, 184)]
		public EquipItemModCategory ModificationCategory { get; set; }

		[FieldOffset(68, 192)]
		public ExternalObject<ItemModificationAsset> ItemModifications { get; set; }

		[FieldOffset(72, 200)]
		public int AnimationCategory { get; set; }

		[FieldOffset(76, 204)]
		public bool AOEDamage { get; set; }

		[FieldOffset(77, 205)]
		public bool UseQuiver { get; set; }

		[FieldOffset(78, 206)]
		public bool IsStaff { get; set; }

		public EquipItemType()
		{
			PartTypes = new List<ExternalObject<ItemPartType>>();
		}
	}
}
