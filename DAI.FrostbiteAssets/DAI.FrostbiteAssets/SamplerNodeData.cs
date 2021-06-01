using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SamplerNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort ExternalWave { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Variation { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Offset { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Delay { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort Pitch { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort Amplitude { get; set; }

		[FieldOffset(56, 240)]
		public AudioGraphNodePort EnableStep { get; set; }

		[FieldOffset(64, 272)]
		public AudioGraphNodePort ShuffleSegments { get; set; }

		[FieldOffset(72, 304)]
		public AudioGraphNodePort Buffer { get; set; }

		[FieldOffset(80, 336)]
		public AudioGraphNodePort Trigger { get; set; }

		[FieldOffset(88, 368)]
		public AudioGraphNodePort Release { get; set; }

		[FieldOffset(96, 400)]
		public AudioGraphNodePort Step { get; set; }

		[FieldOffset(104, 432)]
		public AudioGraphNodePort Output { get; set; }

		[FieldOffset(112, 464)]
		public AudioGraphNodePort Finished { get; set; }

		[FieldOffset(120, 496)]
		public AudioGraphNodePort Buffered { get; set; }

		[FieldOffset(128, 528)]
		public AudioGraphNodePort Position { get; set; }

		[FieldOffset(136, 560)]
		public AudioGraphNodePort Length { get; set; }

		[FieldOffset(144, 592)]
		public ExternalObject<SoundWaveAsset> Wave { get; set; }

		[FieldOffset(148, 600)]
		public List<SamplerPlugins> Plugins { get; set; }

		[FieldOffset(152, 608)]
		public ExternalObject<OutputNodeData> PitchSource { get; set; }

		[FieldOffset(156, 616)]
		public SamplerNodeVersion Version { get; set; }

		[FieldOffset(160, 620)]
		public bool Looping { get; set; }

		[FieldOffset(161, 621)]
		public bool InstantRelease { get; set; }

		[FieldOffset(162, 622)]
		public byte LeadOut { get; set; }

		public SamplerNodeData()
		{
			Plugins = new List<SamplerPlugins>();
		}
	}
}
