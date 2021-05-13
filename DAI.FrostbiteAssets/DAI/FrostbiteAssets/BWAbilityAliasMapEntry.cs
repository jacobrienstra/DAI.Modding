namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityAliasMapEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public BWAbilityAlias Identifier { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<Dummy> Ability { get; set; }

		[FieldOffset(8, 16)]
		public bool PlayerMappable { get; set; }
	}
}
