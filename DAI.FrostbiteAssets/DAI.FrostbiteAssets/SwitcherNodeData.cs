using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SwitcherNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public List<ExternalObject<OutputNodeData>> Outputs { get; set; }

		[FieldOffset(12, 56)]
		public AudioGraphNodePort Trigger { get; set; }

		[FieldOffset(20, 88)]
		public AudioGraphNodePort Value { get; set; }

		[FieldOffset(28, 120)]
		public float DefaultCaseValue { get; set; }

		public SwitcherNodeData()
		{
			Outputs = new List<ExternalObject<OutputNodeData>>();
		}
	}
}
