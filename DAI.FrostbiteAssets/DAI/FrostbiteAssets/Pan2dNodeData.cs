using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Pan2dNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(24, 112)]
		public Pan2dOutputChannelCount OutputChannelCount { get; set; }

		[FieldOffset(28, 116)]
		public AudioGraphNodePort PanAngle { get; set; }

		[FieldOffset(36, 148)]
		public AudioGraphNodePort PanDistance { get; set; }

		[FieldOffset(44, 180)]
		public AudioGraphNodePort PanSize { get; set; }

		[FieldOffset(52, 212)]
		public AudioGraphNodePort PanTwist { get; set; }

		[FieldOffset(60, 244)]
		public AudioGraphNodePort CenterAmplitude { get; set; }

		[FieldOffset(68, 276)]
		public AudioGraphNodePort MainAmplitude { get; set; }

		[FieldOffset(76, 308)]
		public AudioGraphNodePort LfeAmplitude { get; set; }

		[FieldOffset(84, 340)]
		public SoundGraphPluginRef Plugin { get; set; }
	}
}
