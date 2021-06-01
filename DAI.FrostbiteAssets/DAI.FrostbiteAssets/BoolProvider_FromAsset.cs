namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_FromAsset : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<DataProviderAsset> Asset { get; set; }
	}
}
