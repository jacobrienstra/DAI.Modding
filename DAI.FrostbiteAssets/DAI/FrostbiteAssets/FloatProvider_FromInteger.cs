namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_FromInteger : FloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<IntegerProvider> Value { get; set; }
	}
}
