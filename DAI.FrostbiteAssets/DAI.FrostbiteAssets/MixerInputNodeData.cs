using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerInputNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public List<ExternalObject<MixerPreset>> Entries { get; set; }

		public MixerInputNodeData()
		{
			Entries = new List<ExternalObject<MixerPreset>>();
		}
	}
}
