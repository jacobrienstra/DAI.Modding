namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DialogSamplerNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Pitch { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Amplitude { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Continue { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Output { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort Triggered { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort Finished { get; set; }

		[FieldOffset(56, 240)]
		public float TailLength { get; set; }

		[FieldOffset(60, 248)]
		public ExternalObject<OutputNodeData> PitchSource { get; set; }

		[FieldOffset(64, 256)]
		public SoundGraphPluginRef SndPlayerPlugin { get; set; }

		[FieldOffset(67, 259)]
		public SoundGraphPluginRef ResamplePlugin { get; set; }

		[FieldOffset(70, 262)]
		public SoundGraphPluginRef PausePlugin { get; set; }

		[FieldOffset(73, 265)]
		public SoundGraphPluginRef GainPlugin { get; set; }
	}
}
