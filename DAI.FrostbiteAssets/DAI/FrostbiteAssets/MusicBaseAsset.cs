namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicBaseAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<MusicInterfaceAsset> Interface { get; set; }

		[FieldOffset(16, 80)]
		public uint MaxOverlayCount { get; set; }

		[FieldOffset(20, 84)]
		public byte ChannelCount { get; set; }

		[FieldOffset(21, 85)]
		public byte OverlayChannelCount { get; set; }
	}
}
