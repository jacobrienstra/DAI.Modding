namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_MapAbility : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public BWAbilityAlias AbilityAlias { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<BWActivatedAbility> Ability { get; set; }
	}
}
