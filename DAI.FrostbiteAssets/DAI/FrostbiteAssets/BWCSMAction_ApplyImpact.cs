namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyImpact : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<EntityProvider> ImpactSource { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<EntityProvider> ImpactedEntity { get; set; }

		[FieldOffset(36, 88)]
		public ExternalObject<DA3ImpactDescriptor> Impact { get; set; }

		[FieldOffset(40, 96)]
		public bool TakeTargetFromContextPartner { get; set; }
	}
}
