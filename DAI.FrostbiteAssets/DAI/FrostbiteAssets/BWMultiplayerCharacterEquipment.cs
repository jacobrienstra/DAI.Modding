using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMultiplayerCharacterEquipment : DataContainer
	{
		[FieldOffset(8, 24)]
		public string EquipItemAssetPath { get; set; }

		[FieldOffset(12, 32)]
		public EquipSlot EquipItemSlot { get; set; }
	}
}
