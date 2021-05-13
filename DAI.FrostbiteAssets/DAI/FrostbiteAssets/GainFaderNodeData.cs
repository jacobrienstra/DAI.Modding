using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GainFaderNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Start { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort StartTime { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort FadeTime { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort Amplitude { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(56, 240)]
		public GainFaderFadeType FadeType { get; set; }

		[FieldOffset(60, 244)]
		public SoundGraphPluginRef Plugin { get; set; }
	}
}
