namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_StoreEntity : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<EntityProvider_Self> Target { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<CSMEntityProvider> StoredEntity { get; set; }

		[FieldOffset(36, 88)]
		public int Slot { get; set; }
	}
}
