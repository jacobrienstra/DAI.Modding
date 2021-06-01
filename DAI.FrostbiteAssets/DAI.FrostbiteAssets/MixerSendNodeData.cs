using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerSendNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public List<ExternalObject<OutputNodeData>> Entries { get; set; }

		public MixerSendNodeData()
		{
			Entries = new List<ExternalObject<OutputNodeData>>();
		}
	}
}
