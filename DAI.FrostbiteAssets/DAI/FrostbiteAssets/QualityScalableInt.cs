namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class QualityScalableInt
	{
		[FieldOffset(0, 0)]
		public int Low { get; set; }

		[FieldOffset(4, 4)]
		public int Medium { get; set; }

		[FieldOffset(8, 8)]
		public int High { get; set; }

		[FieldOffset(12, 12)]
		public int Ultra { get; set; }
	}
}
