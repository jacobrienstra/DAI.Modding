namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ModelReverbNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public float MaxSpaceSize { get; set; }

		[FieldOffset(12, 52)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(20, 84)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(28, 116)]
		public AudioGraphNodePort ReverbTime { get; set; }

		[FieldOffset(36, 148)]
		public AudioGraphNodePort SpaceSize { get; set; }

		[FieldOffset(44, 180)]
		public AudioGraphNodePort Brightness { get; set; }

		[FieldOffset(52, 212)]
		public SoundGraphPluginRef ReverbPlugin { get; set; }
	}
}
