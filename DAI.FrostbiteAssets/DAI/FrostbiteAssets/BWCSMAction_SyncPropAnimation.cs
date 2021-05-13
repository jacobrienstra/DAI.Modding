namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SyncPropAnimation : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<EntityProvider_Partner> Entity { get; set; }

		[FieldOffset(32, 80)]
		public AntRef Controller { get; set; }

		[FieldOffset(52, 128)]
		public AntRef PropTimeValueGameState { get; set; }

		[FieldOffset(72, 176)]
		public bool PreserveTransformOnStart { get; set; }
	}
}
