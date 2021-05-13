using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyVariationOnEquipment : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public string VariationName { get; set; }

		[FieldOffset(32, 80)]
		public EquipSlot Slot { get; set; }

		[FieldOffset(36, 84)]
		public bool ResetAtEnd { get; set; }

		[FieldOffset(37, 85)]
		public bool UseContextSlot { get; set; }
	}
}
