using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PotionSlotMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<PotionItemAsset> Potion { get; set; }

		[FieldOffset(4, 8)]
		public PotionSlot Slot { get; set; }

		[FieldOffset(8, 12)]
		public byte StartingStack { get; set; }
	}
}
