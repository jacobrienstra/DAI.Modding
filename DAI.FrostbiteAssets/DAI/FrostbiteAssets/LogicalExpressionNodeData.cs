using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LogicalExpressionNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Reset { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<OutputNodeData>> Inputs { get; set; }

		[FieldOffset(20, 88)]
		public AudioGraphNodePort Trigger { get; set; }

		[FieldOffset(28, 120)]
		public LogicalExpressionOperator Operator { get; set; }

		public LogicalExpressionNodeData()
		{
			Inputs = new List<ExternalObject<OutputNodeData>>();
		}
	}
}
