namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class UIPotionLoadoutCompData : UITacticalMenuCompBaseData
	{
		[FieldOffset(52, 176)]
		public LocalizedStringReference HerbCostString { get; set; }

		[FieldOffset(56, 200)]
		public double DisabledPotionPopupDurationSec { get; set; }
	}
}
