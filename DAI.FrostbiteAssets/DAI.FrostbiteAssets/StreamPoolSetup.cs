using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StreamPoolSetup : DataContainer
	{
		[FieldOffset(8, 24)]
		public uint StreamBufferSizeXenon { get; set; }

		[FieldOffset(12, 28)]
		public uint StreamBufferSizePs3 { get; set; }

		[FieldOffset(16, 32)]
		public uint StreamBufferSizeWin32 { get; set; }

		[FieldOffset(20, 36)]
		public uint StreamBufferSizeGen4a { get; set; }

		[FieldOffset(24, 40)]
		public uint StreamBufferSizeGen4b { get; set; }

		[FieldOffset(28, 44)]
		public uint StreamBufferSizeMobile { get; set; }

		[FieldOffset(32, 48)]
		public uint StreamCountXenon { get; set; }

		[FieldOffset(36, 52)]
		public uint StreamCountPs3 { get; set; }

		[FieldOffset(40, 56)]
		public uint StreamCountWin32 { get; set; }

		[FieldOffset(44, 60)]
		public uint StreamCountGen4a { get; set; }

		[FieldOffset(48, 64)]
		public uint StreamCountGen4b { get; set; }

		[FieldOffset(52, 68)]
		public uint StreamCountMobile { get; set; }

		[FieldOffset(56, 72)]
		public uint StreamReadBlockSizeXenon { get; set; }

		[FieldOffset(60, 76)]
		public uint StreamReadBlockSizePs3 { get; set; }

		[FieldOffset(64, 80)]
		public uint StreamReadBlockSizeWin32 { get; set; }

		[FieldOffset(68, 84)]
		public uint StreamReadBlockSizeGen4a { get; set; }

		[FieldOffset(72, 88)]
		public uint StreamReadBlockSizeGen4b { get; set; }

		[FieldOffset(76, 92)]
		public uint StreamReadBlockSizeMobile { get; set; }

		[FieldOffset(80, 96)]
		public StreamStarveMode StreamStarveMode { get; set; }
	}
}
