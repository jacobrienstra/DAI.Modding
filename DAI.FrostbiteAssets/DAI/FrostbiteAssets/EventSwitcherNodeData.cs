using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EventSwitcherNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public List<ExternalObject<OutputNodeData>> Inputs { get; set; }

		[FieldOffset(12, 56)]
		public AudioGraphNodePort Value { get; set; }

		[FieldOffset(20, 88)]
		public float DefaultValue { get; set; }

		public EventSwitcherNodeData()
		{
			Inputs = new List<ExternalObject<OutputNodeData>>();
		}
	}
}
