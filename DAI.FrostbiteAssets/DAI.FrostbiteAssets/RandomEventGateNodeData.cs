namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomEventGateNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Weight { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Out { get; set; }
	}
}
