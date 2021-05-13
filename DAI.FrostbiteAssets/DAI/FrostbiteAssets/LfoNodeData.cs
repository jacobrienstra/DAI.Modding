namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LfoNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Hz { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Amplitude { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(32, 144)]
		public float Min { get; set; }

		[FieldOffset(36, 148)]
		public float Max { get; set; }

		[FieldOffset(40, 152)]
		public bool StartAtRandomValue { get; set; }
	}
}
