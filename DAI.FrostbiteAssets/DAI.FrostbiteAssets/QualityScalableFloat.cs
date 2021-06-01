namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class QualityScalableFloat
	{
		[FieldOffset(0, 0)]
		public float Low { get; set; }

		[FieldOffset(4, 4)]
		public float Medium { get; set; }

		[FieldOffset(8, 8)]
		public float High { get; set; }

		[FieldOffset(12, 12)]
		public float Ultra { get; set; }
	}
}
