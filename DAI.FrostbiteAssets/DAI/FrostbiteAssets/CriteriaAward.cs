namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CriteriaAward : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Dummy> Award { get; set; }

		[FieldOffset(4, 8)]
		public uint Count { get; set; }

		[FieldOffset(8, 16)]
		public LocalizedStringReference LocalizedDescription { get; set; }
	}
}
