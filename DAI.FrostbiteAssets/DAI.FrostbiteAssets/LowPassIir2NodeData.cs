namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LowPassIir2NodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Frequency { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(32, 144)]
		public SoundGraphPluginRef Plugin { get; set; }
	}
}
