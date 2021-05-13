using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetCombatState : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public CombatState DesiredCombatState { get; set; }
	}
}
