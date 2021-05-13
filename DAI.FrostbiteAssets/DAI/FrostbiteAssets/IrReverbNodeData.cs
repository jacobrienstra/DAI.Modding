namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IrReverbNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Reverb0 { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Amplitude0 { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort Reverb1 { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort Amplitude1 { get; set; }

		[FieldOffset(56, 240)]
		public float MaxReverbLength { get; set; }

		[FieldOffset(60, 244)]
		public SoundGraphPluginRef ReverbPlugin { get; set; }
	}
}
