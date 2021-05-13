using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWButtonLegendBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public List<BWButtonLegendEntry> LegendButtons { get; set; }

		[FieldOffset(12, 32)]
		public UIDataSourceInfo DynamicDataSource { get; set; }

		[FieldOffset(28, 64)]
		public ButtonLegendHorizontalAlignment Alignment { get; set; }

		[FieldOffset(32, 68)]
		public ButtonLegendButtonSortMode SortMode { get; set; }

		[FieldOffset(36, 72)]
		public bool UseLegendBackground { get; set; }

		[FieldOffset(37, 73)]
		public bool DestroyContainersOnRefresh { get; set; }

		public BWButtonLegendBinding()
		{
			LegendButtons = new List<BWButtonLegendEntry>();
		}
	}
}
