using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ValueSelectorNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public List<ExternalObject<DataContainer>> Inputs { get; set; }

		[FieldOffset(12, 56)]
		public AudioGraphNodePort Value { get; set; }

		[FieldOffset(20, 88)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(28, 120)]
		public float DefaultCaseValue { get; set; }

		public ValueSelectorNodeData()
		{
			Inputs = new List<ExternalObject<DataContainer>>();
		}
	}
}
