namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RangeMapperEntry
	{
		[FieldOffset(0, 0)]
		public float RangeStart { get; set; }

		[FieldOffset(4, 4)]
		public float RangeEnd { get; set; }

		[FieldOffset(8, 8)]
		public float OutputValue { get; set; }
	}
}
