namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelayNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort DelayTime { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Feedback { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(40, 176)]
		public float MaxDelayTime { get; set; }

		[FieldOffset(44, 180)]
		public SoundGraphPluginRef Plugin { get; set; }
	}
}
