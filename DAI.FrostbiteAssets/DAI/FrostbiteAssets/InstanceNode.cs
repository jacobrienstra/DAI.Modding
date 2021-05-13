using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InstanceNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UIGraphAsset> UIGraph { get; set; }

		[FieldOffset(24, 72)]
		public List<ExternalObject<UINodeData>> Inputs { get; set; }

		[FieldOffset(28, 80)]
		public List<ExternalObject<UINodeData>> Outputs { get; set; }

		public InstanceNode()
		{
			Inputs = new List<ExternalObject<UINodeData>>();
			Outputs = new List<ExternalObject<UINodeData>>();
		}
	}
}
