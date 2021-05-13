namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_BWAbilityTag : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public BWAbilityTagRef Value { get; set; }
	}
}
