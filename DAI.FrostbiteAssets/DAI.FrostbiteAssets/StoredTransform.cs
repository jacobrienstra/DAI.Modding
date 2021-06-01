namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StoredTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> Entity { get; set; }

		[FieldOffset(12, 40)]
		public int Slot { get; set; }
	}
}
