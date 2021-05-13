namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_BWStat : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public ExternalObject<BWStat> Value { get; set; }
	}
}
