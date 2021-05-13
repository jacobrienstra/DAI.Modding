using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicPlayerNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Pitch { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Amplitude { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Buffer { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Start { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort Stop { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort Output { get; set; }

		[FieldOffset(56, 240)]
		public AudioGraphNodePort Overlay { get; set; }

		[FieldOffset(64, 272)]
		public AudioGraphNodePort IsBuffered { get; set; }

		[FieldOffset(72, 304)]
		public AudioGraphNodePort IsFinished { get; set; }

		[FieldOffset(80, 336)]
		public ExternalObject<MusicAsset> Asset { get; set; }

		[FieldOffset(84, 344)]
		public uint DefaultStartEventNameHash { get; set; }

		[FieldOffset(88, 352)]
		public List<ExternalObject<OutputNodeData>> Entries { get; set; }

		[FieldOffset(92, 360)]
		public List<MusicPlayerPlugins> Plugins { get; set; }

		[FieldOffset(96, 368)]
		public List<MusicPlayerRoutedVoice> RoutedVoices { get; set; }

		[FieldOffset(100, 376)]
		public ExternalObject<OutputNodeData> PitchSource { get; set; }

		[FieldOffset(104, 384)]
		public AudioGraphNodePort OnBeat { get; set; }

		[FieldOffset(112, 416)]
		public AudioGraphNodePort OnBar { get; set; }

		[FieldOffset(120, 448)]
		public AudioGraphNodePort OnTransition { get; set; }

		public MusicPlayerNodeData()
		{
			Entries = new List<ExternalObject<OutputNodeData>>();
			Plugins = new List<MusicPlayerPlugins>();
			RoutedVoices = new List<MusicPlayerRoutedVoice>();
		}
	}
}
