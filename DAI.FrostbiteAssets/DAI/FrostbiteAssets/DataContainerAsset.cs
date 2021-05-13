namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DataContainerAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<DataContainer> Data { get; set; }
	}
}
