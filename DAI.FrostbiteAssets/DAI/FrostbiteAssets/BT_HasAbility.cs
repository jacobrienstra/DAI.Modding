using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_HasAbility : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<BWAbility> Ability { get; set; }

		[FieldOffset(24, 56)]
		public BWAbilityTagRef AbilityTag { get; set; }

		[FieldOffset(28, 72)]
		public bool FilterPartyCanUse { get; set; }
	}
}
