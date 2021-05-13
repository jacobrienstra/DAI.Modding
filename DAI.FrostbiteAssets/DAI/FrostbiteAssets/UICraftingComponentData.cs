using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICraftingComponentData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public List<CraftingSlotTypeIconData> SlotTypeIcons { get; set; }

		[FieldOffset(36, 144)]
		public List<CraftingMaterialTypeIconData> MaterialTypeIcons { get; set; }

		[FieldOffset(40, 152)]
		public UITextureAtlasTextureReference MasterworkMaterialTypeIcon { get; set; }

		public UICraftingComponentData()
		{
			SlotTypeIcons = new List<CraftingSlotTypeIconData>();
			MaterialTypeIcons = new List<CraftingMaterialTypeIconData>();
		}
	}
}
