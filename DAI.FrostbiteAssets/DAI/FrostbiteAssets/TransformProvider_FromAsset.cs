namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransformProvider_FromAsset : TransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<DataProviderAsset> Asset { get; set; }
	}
}
