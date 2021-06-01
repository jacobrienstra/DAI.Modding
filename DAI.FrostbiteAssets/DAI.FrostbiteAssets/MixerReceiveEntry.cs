namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerReceiveEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(16, 56)]
		public ExternalObject<AudioGraphParameter> Source { get; set; }

		[FieldOffset(20, 64)]
		public ExternalObject<MixerAsset> Mixer { get; set; }
	}
}
