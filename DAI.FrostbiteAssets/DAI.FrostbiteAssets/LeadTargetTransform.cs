namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LeadTargetTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TransformProvider> TargetTransform { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<TransformProvider> SourceTransform { get; set; }

		[FieldOffset(16, 48)]
		public ExternalObject<EntityProvider_Partner> VelocityEntity { get; set; }

		[FieldOffset(20, 56)]
		public float Speed { get; set; }
	}
}
