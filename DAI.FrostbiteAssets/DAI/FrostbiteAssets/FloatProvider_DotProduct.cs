namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProvider_DotProduct : FloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<Vector3Provider> A { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<Vector3Provider> B { get; set; }
	}
}
