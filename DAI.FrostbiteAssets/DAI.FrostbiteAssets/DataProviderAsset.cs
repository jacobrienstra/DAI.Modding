namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DataProviderAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<DataProviderBase> Provider { get; set; }
	}
}
