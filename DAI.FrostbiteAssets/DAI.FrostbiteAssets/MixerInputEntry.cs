using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerInputEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(16, 56)]
		public ExternalObject<AudioGraphParameter> Source { get; set; }

		[FieldOffset(20, 64)]
		public MixerValueAccumulateMode AccumulateMode { get; set; }

		[FieldOffset(24, 68)]
		public bool KeepValue { get; set; }
	}
}
