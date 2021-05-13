using System;
using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StateNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public Guid ScreenPartitionGuid { get; set; }

		[FieldOffset(36, 80)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(40, 88)]
		public ExternalObject<UINodePort> Show { get; set; }

		[FieldOffset(44, 96)]
		public ExternalObject<UINodePort> Hide { get; set; }

		[FieldOffset(48, 104)]
		public List<ExternalObject<UINodeData>> Inputs { get; set; }

		[FieldOffset(52, 112)]
		public List<ExternalObject<UINodeData>> Outputs { get; set; }

		[FieldOffset(56, 120)]
		public int RenderToRootView { get; set; }

		[FieldOffset(60, 124)]
		public bool RenderToTexture { get; set; }

		public StateNode()
		{
			Inputs = new List<ExternalObject<UINodeData>>();
			Outputs = new List<ExternalObject<UINodeData>>();
		}
	}
}
