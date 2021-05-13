namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RouteEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort Output { get; set; }

		[FieldOffset(16, 56)]
		public AudioGraphNodePort Amplitude { get; set; }

		[FieldOffset(24, 88)]
		public SoundGraphPluginRef Plugin { get; set; }
	}
}
