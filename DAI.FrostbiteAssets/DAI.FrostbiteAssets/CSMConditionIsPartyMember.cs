namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionIsPartyMember : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> Entity { get; set; }
	}
}
