using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingInputSlot : MPServerMappingBase
	{
		[FieldOffset(12, 48)]
		public BWAbilityAlias AbilityAlias { get; set; }

		[FieldOffset(16, 52)]
		public PotionSlot PotionSlot { get; set; }
	}
}
