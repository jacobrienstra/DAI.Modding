namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_Not : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<BoolProvider> Param { get; set; }
	}
}
