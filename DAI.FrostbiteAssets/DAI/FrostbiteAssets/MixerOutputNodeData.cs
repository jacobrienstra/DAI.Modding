using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerOutputNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public List<ExternalObject<MixerPreset>> Entries { get; set; }

		public MixerOutputNodeData()
		{
			Entries = new List<ExternalObject<MixerPreset>>();
		}
	}
}
