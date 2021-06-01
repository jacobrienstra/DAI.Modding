namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_FromAsset : FloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<DataProviderAsset> Asset { get; set; }
	}
}
