using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SocketComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public Realm Realm { get; set; }

		[FieldOffset(100, 184)]
		public ExternalObject<SocketAsset> SocketAsset { get; set; }

		[FieldOffset(104, 192)]
		public SocketComponentBinding AntBindings { get; set; }

		[FieldOffset(124, 240)]
		public bool EnableMirroring { get; set; }
	}
}
