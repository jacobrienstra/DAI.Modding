namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityBoundsCenterTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> Entity { get; set; }
	}
}
