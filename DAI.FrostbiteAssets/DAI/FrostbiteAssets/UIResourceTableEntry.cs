namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class UIResourceTableEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public long Resource { get; set; }

		[FieldOffset(8, 8)]
		public uint Hash { get; set; }
	}
}
