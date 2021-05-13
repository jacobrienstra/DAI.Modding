namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_LaunchNewProjectile : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<GameProjectileEntityData> ProjectileData { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<GameProjectileLauncherData> LauncherData { get; set; }

		[FieldOffset(36, 88)]
		public Delegate_bool AttackRoll { get; set; }

		[FieldOffset(48, 112)]
		public bool NullTarget { get; set; }
	}
}
