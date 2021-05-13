namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityProvider_Nearest : EntityProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<CSMEntityListProvider> CandidateEntities { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<EntityProvider_Self> ReferenceEntity { get; set; }
	}
}
