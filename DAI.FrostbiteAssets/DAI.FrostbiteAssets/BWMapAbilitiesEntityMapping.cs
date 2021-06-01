namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMapAbilitiesEntityMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public BWAbilityAlias AbilityAlias { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<Dummy> Ability { get; set; }
	}
}
