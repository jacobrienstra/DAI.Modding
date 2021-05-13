using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MultiCrossfaderGroup : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort Amplitude { get; set; }

		[FieldOffset(16, 56)]
		public AudioGraphNodePort Start { get; set; }

		[FieldOffset(24, 88)]
		public AudioGraphNodePort Stop { get; set; }

		[FieldOffset(32, 120)]
		public float FadeAmplitude { get; set; }

		[FieldOffset(36, 124)]
		public float FadeBegin { get; set; }

		[FieldOffset(40, 128)]
		public float FadeEnd { get; set; }

		[FieldOffset(44, 132)]
		public FaderType FadeType { get; set; }
	}
}
