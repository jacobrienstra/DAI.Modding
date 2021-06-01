namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InterpolationNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort X { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Y { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort A { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Output { get; set; }
	}
}
