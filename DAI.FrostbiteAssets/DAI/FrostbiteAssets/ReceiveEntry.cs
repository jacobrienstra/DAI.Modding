namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ReceiveEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(16, 56)]
		public ExternalObject<AudioGraphParameter> Source { get; set; }

		[FieldOffset(20, 64)]
		public float Parameter { get; set; }

		[FieldOffset(24, 68)]
		public float SavedValue { get; set; }
	}
}
