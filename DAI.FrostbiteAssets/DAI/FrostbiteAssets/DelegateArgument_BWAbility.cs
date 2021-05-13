namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_BWAbility : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public ExternalObject<BWAbilityUpgrade> Value { get; set; }
	}
}
