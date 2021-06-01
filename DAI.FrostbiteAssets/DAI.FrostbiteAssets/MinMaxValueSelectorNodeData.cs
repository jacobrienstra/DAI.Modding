using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MinMaxValueSelectorNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public List<ExternalObject<DataContainer>> Inputs { get; set; }

		[FieldOffset(12, 56)]
		public AudioGraphNodePort MaxValue { get; set; }

		[FieldOffset(20, 88)]
		public AudioGraphNodePort MaxIndex { get; set; }

		[FieldOffset(28, 120)]
		public AudioGraphNodePort MinValue { get; set; }

		[FieldOffset(36, 152)]
		public AudioGraphNodePort MinIndex { get; set; }

		public MinMaxValueSelectorNodeData()
		{
			Inputs = new List<ExternalObject<DataContainer>>();
		}
	}
}
