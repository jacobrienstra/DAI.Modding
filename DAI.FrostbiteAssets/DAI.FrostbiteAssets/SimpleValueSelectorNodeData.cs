using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SimpleValueSelectorNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public List<float> OutValues { get; set; }

		[FieldOffset(12, 56)]
		public AudioGraphNodePort Index { get; set; }

		[FieldOffset(20, 88)]
		public AudioGraphNodePort Out { get; set; }

		public SimpleValueSelectorNodeData()
		{
			OutValues = new List<float>();
		}
	}
}
