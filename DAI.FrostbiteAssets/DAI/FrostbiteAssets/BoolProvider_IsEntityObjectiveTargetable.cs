namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_IsEntityObjectiveTargetable : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<PartyLeaderEntityProvider> SourceEntityProvider { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<EntityProvider_Self> ObjectiveTargetableEntityProvider { get; set; }
	}
}
