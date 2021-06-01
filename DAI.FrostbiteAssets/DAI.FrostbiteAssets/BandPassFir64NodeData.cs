namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BandPassFir64NodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Frequency { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Bandwidth { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(40, 176)]
		public SoundGraphPluginRef Plugin { get; set; }
	}
}
