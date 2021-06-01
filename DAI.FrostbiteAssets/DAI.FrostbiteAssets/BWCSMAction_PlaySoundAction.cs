using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_PlaySoundAction : BWCSMAction_PlaySoundBase
	{
		[FieldOffset(44, 96)]
		public EquipSlot Slot { get; set; }

		[FieldOffset(48, 100)]
		public int Action { get; set; }

		[FieldOffset(52, 104)]
		public bool UseContextSlot { get; set; }

		[FieldOffset(53, 105)]
		public bool GetGroundMaterial { get; set; }
	}
}
