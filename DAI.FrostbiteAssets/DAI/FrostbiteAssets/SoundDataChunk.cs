using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundDataChunk
	{
		[FieldOffset(0, 0)]
		public Guid ChunkId { get; set; }

		[FieldOffset(16, 16)]
		public uint ChunkSize { get; set; }
	}
}
