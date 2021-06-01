namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMSyncReactionSet : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<Dummy> BaseSyncReactionSet { get; set; }
	}
}
