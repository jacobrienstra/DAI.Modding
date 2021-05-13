using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioSystemAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<SoundMasterPatchAsset> MasterPatch { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<StreamPoolMapping>> GlobalStreamPools { get; set; }

		[FieldOffset(20, 88)]
		public List<ExternalObject<StreamPoolMapping>> StreamPoolPresets { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<StreamPoolPreset> DefaultStreamPoolPreset { get; set; }

		[FieldOffset(28, 104)]
		public List<ExternalObject<StreamPoolMapping>> DataPolicies { get; set; }

		[FieldOffset(32, 112)]
		public uint SampleRate { get; set; }

		[FieldOffset(36, 120)]
		public ExternalObject<SoundTestAsset> Tests { get; set; }

		[FieldOffset(40, 128)]
		public ExternalObject<MixerSystemAsset> MixerSystem { get; set; }

		[FieldOffset(44, 136)]
		public List<ExternalObject<StreamPoolMapping>> Languages { get; set; }

		[FieldOffset(48, 144)]
		public List<ExternalObject<StreamPoolMapping>> LanguageSettings { get; set; }

		[FieldOffset(52, 152)]
		public ExternalObject<AudioLanguage> DefaultLanguage { get; set; }

		[FieldOffset(56, 160)]
		public List<ExternalObject<StreamPoolMapping>> Scopes { get; set; }

		[FieldOffset(60, 168)]
		public List<ExternalObject<StreamPoolMapping>> ScopeStrategies { get; set; }

		[FieldOffset(64, 176)]
		public List<ExternalObject<Dummy>> ScopeSetups { get; set; }

		[FieldOffset(68, 184)]
		public List<ExternalObject<StreamPoolMapping>> HdrSettings { get; set; }

		[FieldOffset(72, 192)]
		public ExternalObject<HdrSetting> DefaultHdrSetting { get; set; }

		public AudioSystemAsset()
		{
			GlobalStreamPools = new List<ExternalObject<StreamPoolMapping>>();
			StreamPoolPresets = new List<ExternalObject<StreamPoolMapping>>();
			DataPolicies = new List<ExternalObject<StreamPoolMapping>>();
			Languages = new List<ExternalObject<StreamPoolMapping>>();
			LanguageSettings = new List<ExternalObject<StreamPoolMapping>>();
			Scopes = new List<ExternalObject<StreamPoolMapping>>();
			ScopeStrategies = new List<ExternalObject<StreamPoolMapping>>();
			ScopeSetups = new List<ExternalObject<Dummy>>();
			HdrSettings = new List<ExternalObject<StreamPoolMapping>>();
		}
	}
}
