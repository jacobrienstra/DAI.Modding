namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAoeCollisionShape : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<TransformProvider> Location { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<DA3ImpactDescriptor> Impact { get; set; }
	}
}
