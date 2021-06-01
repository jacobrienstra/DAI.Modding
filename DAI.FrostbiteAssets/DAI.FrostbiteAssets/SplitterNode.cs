using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SplitterNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(24, 72)]
		public List<ExternalObject<UINodeData>> Outputs { get; set; }

		public SplitterNode()
		{
			Outputs = new List<ExternalObject<UINodeData>>();
		}
	}
}
