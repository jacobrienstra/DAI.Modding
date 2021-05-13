using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CodexEntry : JournalEntryBase
	{
		[FieldOffset(32, 136)]
		public CodexEntryType EntryType { get; set; }

		[FieldOffset(36, 144)]
		public ExternalObject<JournalEntry> AssociatedJournal { get; set; }

		[FieldOffset(40, 152)]
		public string PageTexturePath { get; set; }

		[FieldOffset(44, 160)]
		public bool ShowPopupOnChange { get; set; }
	}
}
