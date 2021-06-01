using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundPatchConfigurationAsset : SoundAsset
	{
		[FieldOffset(20, 88)]
		public ExternalObject<SoundPatchAsset> Sound { get; set; }

		[FieldOffset(24, 96)]
		public float Loudness { get; set; }

		[FieldOffset(28, 100)]
		public float Radius { get; set; }

		[FieldOffset(32, 104)]
		public float DopplerFactor { get; set; }

		[FieldOffset(36, 108)]
		public float MasterPitch { get; set; }

		[FieldOffset(40, 112)]
		public ExternalObject<MixerAsset> Mixer { get; set; }

		[FieldOffset(44, 120)]
		public List<ExternalObject<AudioGraphNodeConfigData>> NodeConfigs { get; set; }

		[FieldOffset(48, 128)]
		public List<ExternalObject<DataContainer>> ParameterConfigs { get; set; }

		[FieldOffset(52, 136)]
		public ExternalObject<Dummy> DebugData { get; set; }

		[FieldOffset(56, 144)]
		public QualityScalableFloat MaxDistance { get; set; }

		[FieldOffset(72, 160)]
		public bool ForceSoundScopeToNull { get; set; }

		[FieldOffset(73, 161)]
		public bool OverrideMaxDistance { get; set; }

		public SoundPatchConfigurationAsset()
		{
			NodeConfigs = new List<ExternalObject<AudioGraphNodeConfigData>>();
			ParameterConfigs = new List<ExternalObject<DataContainer>>();
		}
	}
}
