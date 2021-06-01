namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(1)]
	public class QualityScalableBool
	{
		[FieldOffset(0, 0)]
		public bool Low { get; set; }

		[FieldOffset(1, 1)]
		public bool Medium { get; set; }

		[FieldOffset(2, 2)]
		public bool High { get; set; }

		[FieldOffset(3, 3)]
		public bool Ultra { get; set; }
	}
}
