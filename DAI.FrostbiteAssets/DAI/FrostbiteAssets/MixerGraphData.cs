using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerGraphData : AudioGraphData
	{
		[FieldOffset(28, 80)]
		public List<ExternalObject<MixerPreset>> Inputs { get; set; }

		[FieldOffset(32, 88)]
		public List<MixerInputInfo> MixerInputInfos { get; set; }

		[FieldOffset(36, 96)]
		public List<ExternalObject<MixerPreset>> Outputs { get; set; }

		public MixerGraphData()
		{
			Inputs = new List<ExternalObject<MixerPreset>>();
			MixerInputInfos = new List<MixerInputInfo>();
			Outputs = new List<ExternalObject<MixerPreset>>();
		}
	}
}
