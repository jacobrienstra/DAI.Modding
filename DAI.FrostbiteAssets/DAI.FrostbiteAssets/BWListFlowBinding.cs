using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWListFlowBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public BWListFlowItemType ItemType { get; set; }

		[FieldOffset(12, 32)]
		public string ScreenItemType { get; set; }

		[FieldOffset(16, 40)]
		public List<BWListItem> StaticItems { get; set; }

		[FieldOffset(20, 48)]
		public UIDataSourceInfo DynamicDataSource { get; set; }

		[FieldOffset(36, 80)]
		public UIDataSourceInfo DefaultSelectionDataSource { get; set; }

		[FieldOffset(52, 112)]
		public bool Wrap { get; set; }

		[FieldOffset(53, 113)]
		public bool AnimateOnRefresh { get; set; }

		[FieldOffset(54, 114)]
		public bool MouseClickChangesSelection { get; set; }

		[FieldOffset(55, 115)]
		public bool DelayFlowItemCreation { get; set; }

		public BWListFlowBinding()
		{
			StaticItems = new List<BWListItem>();
		}
	}
}
