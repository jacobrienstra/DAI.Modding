using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DataBindingNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(24, 72)]
		public ExternalObject<UINodePort> Out { get; set; }

		[FieldOffset(28, 80)]
		public ExternalObject<UIMultiplayerFrameTopBinding> DataBinding { get; set; }

		[FieldOffset(32, 88)]
		public UIWidgetEventID WidgetEvent { get; set; }
	}
}
