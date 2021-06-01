namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundWaveVariationSegment
	{
		[FieldOffset(0, 0)]
		public uint SamplesOffset { get; set; }

		[FieldOffset(4, 4)]
		public uint SeekTableOffset { get; set; }

		[FieldOffset(8, 8)]
		public float SegmentLength { get; set; }
	}
}
