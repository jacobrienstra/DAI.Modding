namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConfigurableRangeMapperEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort RangeStart { get; set; }

		[FieldOffset(16, 56)]
		public AudioGraphNodePort RangeEnd { get; set; }

		[FieldOffset(24, 88)]
		public AudioGraphNodePort OutputValue { get; set; }
	}
}
