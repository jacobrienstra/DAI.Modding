using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWListBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public BWListRowType RowType { get; set; }

		[FieldOffset(12, 32)]
		public string ScreenItemType { get; set; }

		[FieldOffset(16, 40)]
		public List<BWListItem> StaticItems { get; set; }

		[FieldOffset(20, 48)]
		public UIDataSourceInfo DynamicDataSource { get; set; }

		[FieldOffset(36, 80)]
		public UIDataSourceInfo SelectionDataSource { get; set; }

		public BWListBinding()
		{
			StaticItems = new List<BWListItem>();
		}
	}
}
