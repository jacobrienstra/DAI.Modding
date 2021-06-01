using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WidgetNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public string WidgetAssetName { get; set; }

		[FieldOffset(24, 72)]
		public List<WidgetEventQueryPair> WidgetEvents { get; set; }

		[FieldOffset(28, 80)]
		public int FocusIndex { get; set; }

		[FieldOffset(32, 84)]
		public WidgetVerticalAlignment VerticalAlign { get; set; }

		[FieldOffset(36, 88)]
		public WidgetHorisontalAlignment HorisontalAlign { get; set; }

		[FieldOffset(40, 92)]
		public int ZDepthLevel { get; set; }

		[FieldOffset(44, 96)]
		public ExternalObject<UIDataBinding> DataBinding { get; set; }

		[FieldOffset(48, 104)]
		public string InstanceName { get; set; }

		[FieldOffset(52, 112)]
		public List<UIWidgetProperty> WidgetProperties { get; set; }

		[FieldOffset(56, 120)]
		public List<ExternalObject<UINodeData>> Outputs { get; set; }

		[FieldOffset(60, 128)]
		public List<ExternalObject<UINodeData>> Inputs { get; set; }

		[FieldOffset(64, 136)]
		public bool AlwaysInFocus { get; set; }

		[FieldOffset(65, 137)]
		public bool IsDisabled { get; set; }

		[FieldOffset(66, 138)]
		public bool IsDisabledInDemoMode { get; set; }

		[FieldOffset(67, 139)]
		public bool IsScrollable { get; set; }

		public WidgetNode()
		{
			WidgetEvents = new List<WidgetEventQueryPair>();
			WidgetProperties = new List<UIWidgetProperty>();
			Outputs = new List<ExternalObject<UINodeData>>();
			Inputs = new List<ExternalObject<UINodeData>>();
		}
	}
}
