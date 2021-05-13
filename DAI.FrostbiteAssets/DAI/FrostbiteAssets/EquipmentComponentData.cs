using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EquipmentComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public List<EquipmentSocketInfoMapping> EquipmentSlots { get; set; }

		[FieldOffset(100, 184)]
		public List<ExternalObject<DataContainer>> DefaultEquipment { get; set; }

		[FieldOffset(104, 192)]
		public List<SlotItemPair> PlaceholderItems { get; set; }

		[FieldOffset(108, 200)]
		public List<PotionSlotMapping> DefaultPotions { get; set; }

		public EquipmentComponentData()
		{
			EquipmentSlots = new List<EquipmentSocketInfoMapping>();
			DefaultEquipment = new List<ExternalObject<DataContainer>>();
			PlaceholderItems = new List<SlotItemPair>();
			DefaultPotions = new List<PotionSlotMapping>();
		}
	}
}
