namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AdsrNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Trigger { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Release { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort A { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort D { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort S { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort R { get; set; }

		[FieldOffset(56, 240)]
		public AudioGraphNodePort Value { get; set; }

		[FieldOffset(64, 272)]
		public AudioGraphNodePort Finished { get; set; }

		[FieldOffset(72, 304)]
		public float Scale { get; set; }
	}
}
