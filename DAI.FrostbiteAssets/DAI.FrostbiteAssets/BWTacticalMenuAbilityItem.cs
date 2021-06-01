namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTacticalMenuAbilityItem : BWTacticalMenuBaseItem
	{
		[FieldOffset(24, 64)]
		public ExternalObject<Dummy> Ability { get; set; }

		[FieldOffset(28, 72)]
		public BWAbilityAlias AbilityAlias { get; set; }
	}
}
