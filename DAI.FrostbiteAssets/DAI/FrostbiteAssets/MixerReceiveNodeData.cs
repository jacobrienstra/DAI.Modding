using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerReceiveNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public List<ExternalObject<AudioGraphNodeData>> Entries { get; set; }

		public MixerReceiveNodeData()
		{
			Entries = new List<ExternalObject<AudioGraphNodeData>>();
		}
	}
}
