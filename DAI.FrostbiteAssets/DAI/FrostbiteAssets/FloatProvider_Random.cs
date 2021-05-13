namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_Random : FloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<FloatProvider> Min { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<FloatProvider> Max { get; set; }

		[FieldOffset(16, 48)]
		public int RandomSeed { get; set; }
	}
}
