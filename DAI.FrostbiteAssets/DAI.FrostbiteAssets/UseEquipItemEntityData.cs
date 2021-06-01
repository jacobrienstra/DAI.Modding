using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UseEquipItemEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<EquipItemAsset> EquipItem { get; set; }

		[FieldOffset(20, 104)]
		public EquipSlot EquipItemSlot { get; set; }

		[FieldOffset(24, 108)]
		public int PartyMemberID { get; set; }
	}
}
