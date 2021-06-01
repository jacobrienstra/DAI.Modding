namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIJournalSystemDataBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo UIJournalContent { get; set; }

		[FieldOffset(24, 56)]
		public UIDataSourceInfo UICodexContent { get; set; }

		[FieldOffset(40, 88)]
		public UIDataSourceInfo UIJournalInitialContent { get; set; }

		[FieldOffset(56, 120)]
		public UIDataSourceInfo UICodexInitialContent { get; set; }
	}
}
