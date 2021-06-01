namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_BoolProvider : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public ExternalObject<BoolProvider_PlotBool> Value { get; set; }
	}
}
