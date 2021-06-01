using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MultipleTransformNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort X { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<ConeOutputNodeData>> Transforms { get; set; }

		[FieldOffset(20, 88)]
		public AudioGraphNodePort Result { get; set; }

		public MultipleTransformNodeData()
		{
			Transforms = new List<ExternalObject<ConeOutputNodeData>>();
		}
	}
}
