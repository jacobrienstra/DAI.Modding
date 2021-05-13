using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBattleMenuSlot
	{
		[FieldOffset(0, 0)]
		public BWAbilityAlias AbilityAlias { get; set; }

		[FieldOffset(4, 4)]
		public int InputAction { get; set; }

		[FieldOffset(8, 8)]
		public UIBattleMenuPageIndex PageIndex { get; set; }
	}
}
