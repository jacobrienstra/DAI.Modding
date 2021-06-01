using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SlotSoundAction : DataContainer
	{
		[FieldOffset(8, 24)]
		public EquipSlot Slot { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<SoundActionList> Actions { get; set; }
	}
}
