namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWApplyImpactEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public ExternalObject<DA3ImpactDescriptor> Impact { get; set; }

		[FieldOffset(24, 112)]
		public MaterialDecl Material { get; set; }

		[FieldOffset(28, 128)]
		public ExternalObject<Dummy> CasterInputList { get; set; }

		[FieldOffset(32, 144)]
		public LinearTransform SourceTransform { get; set; }

		[FieldOffset(96, 208)]
		public ExternalObject<Dummy> PartnerInputList { get; set; }

		[FieldOffset(100, 216)]
		public bool ApplyToTriggeringCharacter { get; set; }
	}
}
