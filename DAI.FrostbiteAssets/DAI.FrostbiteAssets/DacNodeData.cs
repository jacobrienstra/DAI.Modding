namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DacNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort SpeakerCount { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort RealSpeakerCount { get; set; }

		[FieldOffset(32, 144)]
		public SoundGraphPluginRef DelayPlugin { get; set; }

		[FieldOffset(35, 147)]
		public SoundGraphPluginRef VuPlugin { get; set; }

		[FieldOffset(38, 150)]
		public SoundGraphPluginRef GainPlugin { get; set; }

		[FieldOffset(41, 153)]
		public SoundGraphPluginRef DacPlugin { get; set; }
	}
}
