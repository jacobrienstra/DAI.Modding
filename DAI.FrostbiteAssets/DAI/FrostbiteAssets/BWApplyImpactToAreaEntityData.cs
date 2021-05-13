namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWApplyImpactToAreaEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform SourceTransform { get; set; }

		[FieldOffset(80, 160)]
		public ExternalObject<DA3ImpactDescriptor> Impact { get; set; }

		[FieldOffset(84, 168)]
		public MaterialDecl Material { get; set; }

		[FieldOffset(88, 184)]
		public ExternalObject<Dummy> CasterInputList { get; set; }

		[FieldOffset(92, 192)]
		public ExternalObject<Dummy> PartnerInputList { get; set; }
	}
}
