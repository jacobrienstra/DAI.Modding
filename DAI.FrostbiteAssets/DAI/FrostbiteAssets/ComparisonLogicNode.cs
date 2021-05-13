using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ComparisonLogicNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(24, 72)]
		public List<ExternalObject<UINodeData>> Outputs { get; set; }

		[FieldOffset(28, 80)]
		public UISimpleDataSource DataSourceInfo { get; set; }

		[FieldOffset(36, 96)]
		public bool SkipFractionals { get; set; }

		public ComparisonLogicNode()
		{
			Outputs = new List<ExternalObject<UINodeData>>();
		}
	}
}
