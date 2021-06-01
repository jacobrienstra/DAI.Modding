using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MultiCrossfaderNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public List<ExternalObject<OutputNodeData>> CrossfaderGroups { get; set; }

		[FieldOffset(12, 56)]
		public AudioGraphNodePort Start { get; set; }

		[FieldOffset(20, 88)]
		public AudioGraphNodePort Stop { get; set; }

		[FieldOffset(28, 120)]
		public AudioGraphNodePort Control { get; set; }

		[FieldOffset(36, 152)]
		public bool LockControlValue { get; set; }

		public MultiCrossfaderNodeData()
		{
			CrossfaderGroups = new List<ExternalObject<OutputNodeData>>();
		}
	}
}
