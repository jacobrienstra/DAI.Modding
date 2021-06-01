using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OnlineProviderConfiguration : LinkObject
	{
		[FieldOffset(0, 0)]
		public GamePlatform Platform { get; set; }

		[FieldOffset(4, 8)]
		public string ServiceName { get; set; }

		[FieldOffset(8, 16)]
		public string Client { get; set; }

		[FieldOffset(12, 24)]
		public string SKU { get; set; }

		[FieldOffset(16, 32)]
		public string Version { get; set; }

		[FieldOffset(20, 40)]
		public uint ServerSocketPacketSize { get; set; }

		[FieldOffset(24, 44)]
		public bool IsServer { get; set; }
	}
}
