using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DataGetNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(24, 72)]
		public ExternalObject<UINodePort> Out { get; set; }

		[FieldOffset(28, 80)]
		public UISimpleDataSource DataSource { get; set; }

		[FieldOffset(36, 96)]
		public UIWidgetEventID WidgetEvent { get; set; }
	}
}
