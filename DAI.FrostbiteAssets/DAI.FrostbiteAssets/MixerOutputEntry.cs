namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerOutputEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 56)]
		public ExternalObject<AudioGraphParameter> Target { get; set; }
	}
}
