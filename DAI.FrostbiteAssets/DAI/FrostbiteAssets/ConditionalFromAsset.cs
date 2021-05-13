namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConditionalFromAsset : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<DataProviderAsset> Asset { get; set; }
	}
}
