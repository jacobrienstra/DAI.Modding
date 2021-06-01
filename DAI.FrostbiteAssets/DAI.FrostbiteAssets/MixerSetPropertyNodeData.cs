using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerSetPropertyNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public List<ExternalObject<MixerPreset>> Entries { get; set; }

		public MixerSetPropertyNodeData()
		{
			Entries = new List<ExternalObject<MixerPreset>>();
		}
	}
}
