namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IndexRange
	{
		[FieldOffset(0, 0)]
		public uint First { get; set; }

		[FieldOffset(4, 4)]
		public uint Last { get; set; }
	}
}
