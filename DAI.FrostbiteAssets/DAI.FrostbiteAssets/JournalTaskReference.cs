namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JournalTaskReference : DataContainer
	{
		[FieldOffset(8, 24)]
		public JournalEntryTaskPair Task { get; set; }
	}
}
