using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<MixerGraphData> Graph { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<MixerPreset>> Presets { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<MixerPreset> DefaultPreset { get; set; }

		[FieldOffset(24, 96)]
		public bool Bypass { get; set; }

		public MixerAsset()
		{
			Presets = new List<ExternalObject<MixerPreset>>();
		}
	}
}
