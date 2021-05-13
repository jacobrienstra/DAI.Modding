using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTacticalMenuPotionItem : BWTacticalMenuBaseItem
	{
		[FieldOffset(24, 64)]
		public PotionSlot Slot { get; set; }
	}
}
