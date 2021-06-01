namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JournalEntryTaskPair : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint EntryHash { get; set; }

		[FieldOffset(4, 4)]
		public uint TaskHash { get; set; }
	}
}
