using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIPotionCommandEntityData : UICommandEntityData
	{
		[FieldOffset(16, 96)]
		public PotionSlot PotionSlot { get; set; }
	}
}
