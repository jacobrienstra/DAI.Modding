namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityUpgradeTreeItemAlternate : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWAbilityUpgrade> Ability { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<BoolProvider_HasDLC> VisibilityCondition { get; set; }
	}
}
