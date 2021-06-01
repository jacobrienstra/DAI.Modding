namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionIsUpdatingSafePoint : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<TacticsTargetEntityProvider> Entity { get; set; }
	}
}
