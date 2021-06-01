namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JournalSystemCategory : DataContainer
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference TitleReference { get; set; }

		[FieldOffset(12, 48)]
		public LocalizedStringReference DescriptionReference { get; set; }

		[FieldOffset(16, 72)]
		public string TexturePath { get; set; }

		[FieldOffset(20, 80)]
		public string PageTexturePath { get; set; }

		[FieldOffset(24, 88)]
		public int SortOrder { get; set; }

		[FieldOffset(28, 92)]
		public bool Collection { get; set; }

		[FieldOffset(29, 93)]
		public bool ShouldDisplayInCodex { get; set; }
	}
}
