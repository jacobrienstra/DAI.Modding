namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StreamPoolMapping : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<StreamPoolAsset> StreamPool { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<StreamPoolSetup> StreamPoolSetup { get; set; }
	}
}
