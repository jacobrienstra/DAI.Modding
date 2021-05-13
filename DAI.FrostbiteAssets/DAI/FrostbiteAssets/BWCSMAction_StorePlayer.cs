namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_StorePlayer : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<EntityProvider_Self> Target { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<EntityProvider_Caster> StoredPlayer { get; set; }

		[FieldOffset(36, 88)]
		public int Slot { get; set; }
	}
}
