using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerSimplePresetNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Index { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<Dummy>> Presets { get; set; }

		public MixerSimplePresetNodeData()
		{
			Presets = new List<ExternalObject<Dummy>>();
		}
	}
}
