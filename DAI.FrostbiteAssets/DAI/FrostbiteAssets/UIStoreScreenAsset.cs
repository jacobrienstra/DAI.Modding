using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIStoreScreenAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public ExternalObject<UIBWInventoryCategories> Categories { get; set; }

		[FieldOffset(72, 200)]
		public List<UIStoreItemTypeSlotMap> EquipTypeSlotMap { get; set; }

		[FieldOffset(76, 208)]
		public ExternalObject<UIBWInventoryCategories> PartyStorageCategories { get; set; }

		public UIStoreScreenAsset()
		{
			EquipTypeSlotMap = new List<UIStoreItemTypeSlotMap>();
		}
	}
}
