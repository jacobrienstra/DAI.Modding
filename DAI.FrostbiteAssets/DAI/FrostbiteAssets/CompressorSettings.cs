namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CompressorSettings : DataContainer
	{
		[FieldOffset(8, 24)]
		public float Ratio { get; set; }

		[FieldOffset(12, 28)]
		public float Threshold { get; set; }

		[FieldOffset(16, 32)]
		public float Attack { get; set; }

		[FieldOffset(20, 36)]
		public float Release { get; set; }
	}
}
