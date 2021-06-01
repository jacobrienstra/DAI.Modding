namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_FloatProvider : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public ExternalObject<FloatProvider> Value { get; set; }
	}
}
