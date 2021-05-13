namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SocketComponentSpawnData : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<SocketAsset> SocketAsset { get; set; }

		[FieldOffset(12, 32)]
		public bool EnableMirroring { get; set; }
	}
}
