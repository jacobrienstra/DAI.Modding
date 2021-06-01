namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_Abs : FloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<FloatProvider_VectorComponent> Value { get; set; }
	}
}
