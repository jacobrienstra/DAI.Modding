namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IntegerProvider_FromFloat : IntegerProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<FloatProvider_Stat> Value { get; set; }
	}
}
