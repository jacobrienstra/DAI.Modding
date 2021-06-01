using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPlayerUseAbilityEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<BWActivatedAbility> Ability { get; set; }

		[FieldOffset(20, 104)]
		public BWAbilityTagRef AbilityTag { get; set; }

		[FieldOffset(24, 120)]
		public BWAbilityAlias AbilityAlias { get; set; }

		[FieldOffset(28, 124)]
		public BWAbilityActivationMode ActivationMode { get; set; }
	}
}
