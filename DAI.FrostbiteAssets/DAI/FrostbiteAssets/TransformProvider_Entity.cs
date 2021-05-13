namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransformProvider_Entity : TransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> Entity { get; set; }
	}
}
