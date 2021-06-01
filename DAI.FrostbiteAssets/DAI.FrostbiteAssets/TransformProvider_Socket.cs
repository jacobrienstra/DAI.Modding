namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransformProvider_Socket : TransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> Entity { get; set; }

		[FieldOffset(12, 40)]
		public int Socket { get; set; }
	}
}
