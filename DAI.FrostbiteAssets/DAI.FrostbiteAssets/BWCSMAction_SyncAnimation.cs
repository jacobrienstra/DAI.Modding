namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SyncAnimation : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<CSMStateReference> ReactionStateRef { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<CSMEntityProvider> SyncEntity { get; set; }
	}
}
