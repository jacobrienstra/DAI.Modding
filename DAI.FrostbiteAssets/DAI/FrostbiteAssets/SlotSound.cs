using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SlotSound : DataContainer
	{
		[FieldOffset(8, 24)]
		public EquipSlot Slot { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<SoundAsset> Asset { get; set; }
	}
}
