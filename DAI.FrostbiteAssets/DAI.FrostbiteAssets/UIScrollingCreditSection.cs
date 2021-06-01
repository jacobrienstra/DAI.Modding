namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIScrollingCreditSection : LinkObject
	{
		[FieldOffset(0, 0)]
		public LocalizedStringReference Title { get; set; }

		[FieldOffset(4, 24)]
		public LocalizedStringReference Names { get; set; }

		[FieldOffset(8, 48)]
		public uint Columns { get; set; }

		[FieldOffset(12, 52)]
		public float MaxColumnWidth { get; set; }

		[FieldOffset(16, 56)]
		public float FontScale { get; set; }

		[FieldOffset(20, 60)]
		public float BreakSpace { get; set; }

		[FieldOffset(24, 64)]
		public bool IsSectionHeader { get; set; }
	}
}
