namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundWaveRuntimeVariation
	{
		[FieldOffset(0, 0)]
		public uint PersistentDataSize { get; set; }

		[FieldOffset(4, 4)]
		public short FirstSubtitleIndex { get; set; }

		[FieldOffset(6, 6)]
		public short SubtitleCount { get; set; }

		[FieldOffset(8, 8)]
		public short FirstSegmentIndex { get; set; }

		[FieldOffset(10, 10)]
		public byte SegmentCount { get; set; }

		[FieldOffset(11, 11)]
		public byte ChunkIndex { get; set; }

		[FieldOffset(12, 12)]
		public byte FirstLoopSegmentIndex { get; set; }

		[FieldOffset(13, 13)]
		public byte LastLoopSegmentIndex { get; set; }

		[FieldOffset(14, 14)]
		public byte Weight { get; set; }
	}
}
