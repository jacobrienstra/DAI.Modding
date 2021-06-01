namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CrossfaderNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In1 { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort In2 { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Ctrl { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(40, 176)]
		public SoundGraphPluginRef Plugin1 { get; set; }

		[FieldOffset(43, 179)]
		public SoundGraphPluginRef Plugin2 { get; set; }
	}
}
