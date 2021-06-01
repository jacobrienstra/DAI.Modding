namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_BWAbilityRanges : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public ExternalObject<BWRange> Value { get; set; }
	}
}
