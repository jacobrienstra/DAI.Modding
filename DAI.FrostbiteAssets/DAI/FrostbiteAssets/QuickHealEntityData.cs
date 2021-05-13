using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class QuickHealEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public PotionSlot Slot { get; set; }
	}
}
