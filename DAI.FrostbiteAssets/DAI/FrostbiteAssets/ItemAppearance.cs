using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemAppearance : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<EquipItemType> ItemType { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<ItemPartAppearance>> Parts { get; set; }

		public ItemAppearance()
		{
			Parts = new List<ExternalObject<ItemPartAppearance>>();
		}
	}
}
