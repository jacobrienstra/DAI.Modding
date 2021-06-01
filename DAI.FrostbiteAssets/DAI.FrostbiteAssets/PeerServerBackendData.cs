namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PeerServerBackendData : ServerBackendData
	{
		[FieldOffset(16, 80)]
		public PeerCreateGameParameters CreateParameters { get; set; }
	}
}
