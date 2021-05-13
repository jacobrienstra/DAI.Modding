namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_Negate : FloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<FloatProvider> Value { get; set; }
	}
}
