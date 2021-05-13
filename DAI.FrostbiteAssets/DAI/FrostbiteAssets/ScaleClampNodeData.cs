namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScaleClampNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort InMin { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort InMax { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort OutMin { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort OutMax { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort Out { get; set; }
	}
}
