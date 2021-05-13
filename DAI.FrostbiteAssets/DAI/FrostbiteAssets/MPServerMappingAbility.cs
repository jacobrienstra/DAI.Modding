namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingAbility : MPServerMappingBase
	{
		[FieldOffset(12, 48)]
		public ExternalObject<BWAbilityUpgrade> Ability { get; set; }
	}
}
