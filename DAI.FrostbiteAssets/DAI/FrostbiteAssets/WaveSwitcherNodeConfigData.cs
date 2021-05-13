using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WaveSwitcherNodeConfigData : AudioGraphNodeConfigData
	{
		[FieldOffset(12, 32)]
		public List<ExternalObject<AudioGraphNodeConfigData>> Waves { get; set; }

		public WaveSwitcherNodeConfigData()
		{
			Waves = new List<ExternalObject<AudioGraphNodeConfigData>>();
		}
	}
}
