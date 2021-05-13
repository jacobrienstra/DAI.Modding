using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIGridBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public string GlobalGridItemType { get; set; }

		[FieldOffset(12, 32)]
		public UIDataSourceInfo DynamicDataSource { get; set; }

		[FieldOffset(28, 64)]
		public UIDataSourceInfo DefaultSelectionDataSource { get; set; }

		[FieldOffset(44, 96)]
		public uint ColumnCount { get; set; }

		[FieldOffset(48, 100)]
		public uint MaxRowCount { get; set; }

		[FieldOffset(52, 104)]
		public uint HorizontalSpacing { get; set; }

		[FieldOffset(56, 108)]
		public uint VerticalSpacing { get; set; }

		[FieldOffset(60, 112)]
		public UIGridHorizontalWrapType HorizontalWrapType { get; set; }

		[FieldOffset(64, 116)]
		public uint ScrollbarOffset { get; set; }

		[FieldOffset(68, 120)]
		public bool VerticalWrap { get; set; }

		[FieldOffset(69, 121)]
		public bool IsScrollbarLeft { get; set; }
	}
}
