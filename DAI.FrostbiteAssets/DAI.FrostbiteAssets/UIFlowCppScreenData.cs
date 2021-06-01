using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIFlowCppScreenData : UIViewAsset
	{
		[FieldOffset(48, 144)]
		public UIScreenRenderingPass RenderPass { get; set; }

		[FieldOffset(52, 152)]
		public ExternalObject<UICppScreenData> ScreenData { get; set; }

		[FieldOffset(56, 160)]
		public ExternalObject<UIWidgetBlueprint> RootWidget { get; set; }

		[FieldOffset(60, 168)]
		public bool RenderTarget { get; set; }
	}
}
