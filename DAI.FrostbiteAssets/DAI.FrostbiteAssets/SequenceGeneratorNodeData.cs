namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SequenceGeneratorNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Trigger { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Reset { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Min { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Max { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort Step { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort Value { get; set; }

		[FieldOffset(56, 240)]
		public bool UpdateValueOnEvents { get; set; }
	}
}
